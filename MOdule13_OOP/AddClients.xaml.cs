using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace MOdule13_OOP
{
    /// <summary>
    /// Логика взаимодействия для AddClients.xaml
    /// </summary>
    public partial class AddClients : Window
    {
        public AddClients()
        {
            InitializeComponent();
        }
        private void Button_Click_Add_New_Client(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Client> clients = new ObservableCollection<Client>();
            int num;
            if (LastName.Text.Length != 0 && FirstName.Text.Length != 0 &&
                FatherName.Text.Length != 0 && PhoneNumber.Text.Length != 0 && Passport.Text.Length != 0 && Email.Text.Length!=0)//Проверка все ли поля заполнены
            {
                if (Bank_A.AllClientsInfo == null)//проверка пустая ли коллекция всех клиентов
                {
                    num = 1;
                    
                    clients.Add(new Client(num, FirstName.Text, LastName.Text,
                    FatherName.Text, PhoneNumber.Text, Passport.Text, Email.Text));
                    Bank_A.AllClientsInfo = clients;
                    Bank_A.SerialiseAllClientInfo();

                    MessageBox.Show("Успешно сохранено");
                }
                else
                {
                    
                    num = Bank_A.AllClientsInfo.Count + 1;
                
                    
                    Bank_A.AllClientsInfo.Add(new Client(num, FirstName.Text, LastName.Text,
                    FatherName.Text, PhoneNumber.Text, Passport.Text, Email.Text));
                    Bank_A.SerialiseAllClientInfo();

                    MessageBox.Show("Успешно сохранено");
                    
                }
            }
            else
            {
                MessageBox.Show("Не все поля заполнены");
                
            }
            
        }

        private void Button_Click_Return(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }
    }
}
