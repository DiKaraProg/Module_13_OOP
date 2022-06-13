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
using System.Windows.Shapes;

namespace MOdule13_OOP
{
    /// <summary>
    /// Логика взаимодействия для TransferMoney.xaml
    /// </summary>
    public partial class TransferMoney : Window
    {
        public TransferMoney()
        {
            InitializeComponent();
            
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in Bank_A.AllClientsInfo)
            {
                if (item.Id == Convert.ToInt32(SenderUserId.Text))
                {
                    foreach (var item1 in item.Listaccount)
                    {
                        if (item1.AccountId == Convert.ToInt32(SenderAccountId.Text))
                        {
                            item1.Sum -= Convert.ToInt32(Sum.Text);
                        }
                        
                        
                    }
                }
                //else MessageBox.Show($"Отправителя с id-{SenderUserId.Text} не существует");return;
            }
            foreach (var item in Bank_A.AllClientsInfo)
            {
                if (item.Id == Convert.ToInt32(RecipientUserId.Text))
                {
                    foreach (var item1 in item.Listaccount)
                    {
                        if (item1.AccountId == Convert.ToInt32(RecipientAccountId.Text))
                        {
                            item1.Sum += Convert.ToInt32(Sum.Text);
                        }
                        //MessageBox.Show($"У gjkexfntkz нет счета с таким id-{RecipientAccountId.Text}"); return;
                    }
                    //MessageBox.Show($"Получаетля с id-{RecipientUserId.Text} не существует"); return;
                }
            }
        }
    }
}
