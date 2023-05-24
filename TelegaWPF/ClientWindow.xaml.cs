using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Shapes;
using System.Xml.Linq;
using static System.Collections.Specialized.BitVector32;

namespace TelegaWPF
{
    /// <summary>
    /// Логика взаимодействия для ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        private CancellationTokenSource isWorking;
        public ClientWindow()
        {
            InitializeComponent();
            TcpClient.Client();
            isWorking = new CancellationTokenSource();
            RecieveMessage(isWorking.Token);

        }

        private async Task RecieveMessage(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                byte[] bytes = new byte[1024];
                await TcpClient.server.ReceiveAsync(bytes, SocketFlags.None);
                string message = Encoding.UTF8.GetString(bytes);
                int action = Convert.ToInt32(message.Substring(0, 1));
                message = message.Substring(1, message.Length - 1);
                switch (action)
                {
                    case 1:
                        MessageLbx.Items.Add(message);
                        break;
                    case 2:
                        UsersLbx.Items.Clear();
                        string[] userList = message.Split(';');
                        foreach (string user in userList)
                        {
                            UsersLbx.Items.Add(user);
                        }
                        break;
                }
            }
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            if (Message.Text == "/disconnect")
            {
                ExitAction();
            }
            else
            {
                if (Message.Text != "")
                {
                    TcpClient.SendMessage($"[{TcpClient.date}] [{TcpClient.usersname}]: {Message.Text}");
                    Message.Text = "";
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
        private void ExitAction()
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            isWorking.Cancel();
            TcpClient.server.Close();
            this.Close();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            isWorking.Cancel();
            TcpClient.server.Close();
        }
    }
}
