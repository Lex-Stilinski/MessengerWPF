using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace TelegaWPF
{
    public partial class AdminWindow : Window
    {
        
        private CancellationTokenSource isWorking;
        private bool isPageOpen = false;
        DateTime date = DateTime.Now;
        public AdminWindow()
        {
            InitializeComponent();

            TcpAdmin.Server();
            isWorking = new CancellationTokenSource();
            UpdateUsers();
            ListenToClients(isWorking.Token);
        }

        private async Task ListenToClients(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                var client = await TcpAdmin.socket.AcceptAsync();
                RecieveMessage(client);
            }
        }

        private async Task RecieveMessage(Socket client)
        {
            while (true)
            {
                byte[] bytes = new byte[1024];
                await client.ReceiveAsync(bytes, SocketFlags.None);
                string message = Encoding.UTF8.GetString(bytes);
                int action = Convert.ToInt32(message.Substring(0, 1));
                message = message.Substring(1, message.Length - 1);
                switch (action)
                {
                    case 0:
                        message = message.Substring(0, message.LastIndexOf(']') + 1);
                        TcpAdmin.clients.Add(client, message);
                        UpdateUsers();
                        TcpAdmin.logList.Add($"[{date}] \nНовый юзер: [{message}] ");
                        string allUsers = "";
                        foreach (var item in TcpAdmin.clients)
                        {
                            allUsers += $"{item.Value};";
                        }
                        foreach (var item in TcpAdmin.clients)
                        {
                            TcpAdmin.SendUsers(item.Key, allUsers);
                        }

                        break;
                    case 1:
                        MessageLbx.Items.Add(message);

                        foreach (var item in TcpAdmin.clients)
                        {
                            TcpAdmin.SendMessage(item.Key, message);
                        }
                        break;
                }
            }
        }

        private void ShowLogs_Click(object sender, RoutedEventArgs e)
        {
            if (!isPageOpen)
            {
                Frame.Content = new LogPage();
                isPageOpen = true;
                ShowLogs.Content = "Посмотреть пользователей чата"; 
            }
            else
            {
                Frame.Content = null;
                isPageOpen = false;
                ShowLogs.Content = "Посмотреть логи чата"; 
            }
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text == "/disconnect")
            {
                ExitAction();
            }
            else
            {
                if (Name.Text != "")
                {
                    MessageLbx.Items.Add($"[{date}] [{TcpAdmin.usersname}]: {Name.Text}");

                    foreach (var item in TcpAdmin.clients)
                    {
                        TcpAdmin.SendMessage(item.Key, $"[{date}] [{TcpAdmin.usersname}]: {Name.Text}");
                    }
                    Name.Text = "";
                }
                else
                {
                    MessageBox.Show("Сообщение пустое!");
                }
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            ExitAction();
        }
        private void UpdateUsers()
        {
            UsersLbx.Items.Clear();
            foreach (var item in TcpAdmin.clients)
            {
                UsersLbx.Items.Add(item.Value);
            }
        }

        private void ExitAction()
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            isWorking.Cancel();
            TcpAdmin.socket.Close();
            TcpAdmin.clients = new Dictionary<Socket, string>();
            TcpAdmin.logList = new List<string>();
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            isWorking.Cancel();
            TcpAdmin.socket.Close();
            TcpAdmin.clients = new Dictionary<Socket, string>();
            TcpAdmin.logList = new List<string>();
        }
    }
}
