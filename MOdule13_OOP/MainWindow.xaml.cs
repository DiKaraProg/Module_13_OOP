using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace MOdule13_OOP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Bank_A.AllClientsInfo= Bank_A.DeserialiseAllClientInfo();
            ListView.ItemsSource = Bank_A.AllClientsInfo;
           
           
        }

        private void Button_Click_Add_Clients(object sender, RoutedEventArgs e)
        {

            AddClients addClients = new AddClients();
            addClients.Show();
            this.Close();
        }


        private void CreateDemandAccount_Click(object sender, RoutedEventArgs e)
        {
            
            foreach (var item in Bank_A.AllClientsInfo)
            {
                if (item.Id == Convert.ToInt32(SelectedId.Text))
                {
                    
                    item.Listaccount.Add(new DemandAccount(Convert.ToDouble(sum.Text)));
                    ListViewAccount.ItemsSource = null;
                    ListViewAccount.ItemsSource = item.Listaccount;
                    break;
                }
                
            }
            Bank_A.SerialiseAllClientInfo();
            
        }
        private void CreateDepositAccount_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedId.Text != string.Empty)
            {
                if (sum.Text != string.Empty && Convert.ToDouble(sum.Text)>=100 )
                {




                    foreach (var item in Bank_A.AllClientsInfo)
                    {
                        if (item.Id == Convert.ToInt32(SelectedId.Text))
                        {

                            item.Listaccount.Add(new DepositAccount(Convert.ToDouble(sum.Text)));
                            ListViewAccount.ItemsSource = null;
                            ListViewAccount.ItemsSource = item.Listaccount;
                            break;
                        }

                    }
                    Bank_A.SerialiseAllClientInfo();
                }
                else
                {
                    MessageBox.Show("Для создание счета необходим взнос от 100$");
                }
            }
            else
            {
                MessageBox.Show("Выберите клиента");
            }
            
                
        }

        
        private void ViewAccount_Click(object sender, RoutedEventArgs e)
        {
            
            List<Account> accounts = new List<Account>();
            if (SelectedId.Text != string.Empty)
            {


                foreach (var item in Bank_A.AllClientsInfo)
                {
                    if (item.Id == Convert.ToInt32(SelectedId.Text))
                    {
                        foreach (var item1 in item.Listaccount)
                        {

                            accounts.Add(item1);
                        }
                        ListViewAccount.ItemsSource = accounts;
                    }
                }
            }
        }


        private void Button_Click_Transfer(object sender, RoutedEventArgs e)
        {
            TransferMoney transferMoney = new TransferMoney();
            transferMoney.Show();
        }

        private void Button_Click_Close_Account(object sender, RoutedEventArgs e)
        {
            if (idUser.Text==String.Empty|| Idaccount.Text==String.Empty)
            {
                MessageBox.Show("Не все поля заполнены");return;
            }
            foreach (var item in Bank_A.AllClientsInfo)
            {
                if (item.Id == Convert.ToInt32(idUser.Text))
                {
                    foreach (var item1 in item.Listaccount)
                    {
                        if (item1.AccountId == Convert.ToInt32(Idaccount.Text))
                        {
                            item.Listaccount.Remove(item1);
                            Bank_A.SerialiseAllClientInfo();
                            ListViewAccount.ItemsSource = null;
                            ListViewAccount.ItemsSource = item.Listaccount;
                            MessageBox.Show("Счет закрыт");
                            return;
                        }
                    }
                }
                
            }
            Bank_A.SerialiseAllClientInfo();

        }
    }
}
