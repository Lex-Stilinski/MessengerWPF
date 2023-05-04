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
        public static string ip;
        DateTime date = DateTime.Now;
        public static string usersname;
        private Socket server;
        public ClientWindow()
        {
            InitializeComponent();
            isWorking = new CancellationTokenSource();
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Connect(ip, 8888);
            SendName(usersname);
            RecieveMessage();

        }

        private async Task RecieveMessage()
        {
            while (!isWorking.IsCancellationRequested)
            {
                byte[] bytes = new byte[1024];
                await server.ReceiveAsync(bytes, SocketFlags.None);
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

        private async Task SendName(string usersname)
        {
            byte[] bytes = Encoding.UTF8.GetBytes($"0[{usersname}]");
            await server.SendAsync(bytes, SocketFlags.None);
        }

        private async Task SendMessage(string message)
        {
            byte[] bytes = Encoding.UTF8.GetBytes($"1{message}");
            await server.SendAsync(bytes, SocketFlags.None);
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            if (Message.Text != "")
            {
                SendMessage($"[{date}] [{usersname}]: {Message.Text}");
                Message.Text = "";
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

        private void Window_Closed(object sender, EventArgs e)
        {
            isWorking.Cancel();
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
