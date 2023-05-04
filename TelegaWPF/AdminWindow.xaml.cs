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
        private Socket socket;
        private CancellationTokenSource isWorking;
        private Dictionary<Socket, string> clients = new Dictionary<Socket, string>();
        private bool isPageOpen = false;
        public static List<string> logList = new List<string>();
        public static string usersname;
        DateTime date = DateTime.Now;
        public AdminWindow()
        {
            InitializeComponent();
            isWorking = new CancellationTokenSource();
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Any, 8888);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(ipPoint);
            socket.Listen(1000);
            clients.Add(socket, $"[{usersname}]");
            logList.Add($"[{date}] \nНовый юзер: {usersname} ");
            UpdateUsers();
            ListenToClients();
        }

        private async Task ListenToClients()
        {
            while (!isWorking.IsCancellationRequested)
            {
                var client = await socket.AcceptAsync();
                RecieveMessage(client);
            }
        }

        private async Task RecieveMessage(Socket client)
        {
            while (!isWorking.IsCancellationRequested)
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
                        clients.Add(client, message);
                        UpdateUsers();
                        logList.Add($"[{date}] \nНовый юзер: [{message}] ");
                        string allUsers = "";
                        foreach (var item in clients)
                        {
                            allUsers += $"{item.Value};";
                        }
                        foreach (var item in clients)
                        {
                            SendUsers(item.Key, allUsers);
                        }

                        break;
                    case 1:
                        MessageLbx.Items.Add(message);

                        foreach (var item in clients)
                        {
                            SendMessage(item.Key, message);
                        }
                        break;
                }
            }
        }

        private async Task SendMessage(Socket client, string message)
        {
            byte[] bytes = Encoding.UTF8.GetBytes($"1{message}");
            await client.SendAsync(bytes, SocketFlags.None);
        }
        private async Task SendUsers(Socket client, string allUsers)
        {
            byte[] bytes = Encoding.UTF8.GetBytes($"2{allUsers}");
            await client.SendAsync(bytes, SocketFlags.None);
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
            if (Name.Text != "")
            {
                MessageLbx.Items.Add($"[{date}] [{usersname}]: {Name.Text}");

                foreach (var item in clients)
                {
                    SendMessage(item.Key, $"[{date}] [{usersname}]: {Name.Text}");
                }
                Name.Text = "";
            }
            else
            {
                MessageBox.Show("Сообщение пустое!");
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            isWorking.Cancel();
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
        private void UpdateUsers()
        {
            UsersLbx.Items.Clear();
            foreach (var item in clients)
            {
                UsersLbx.Items.Add(item.Value);
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            isWorking.Cancel();
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
