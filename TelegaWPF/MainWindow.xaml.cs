using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace TelegaWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text != "")
            {
                TcpAdmin.usersname = Name.Text.ToString();
                AdminWindow admin = new AdminWindow();
                admin.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Пустое поле!");
            }
        }

        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text != "" && IP.Text != "")
            {
                TcpClient.usersname = Name.Text.ToString();
                TcpClient.ip = IP.Text.ToString();
                ClientWindow client = new ClientWindow();
                client.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Заполните поля!");
            }
        }
    }
}
