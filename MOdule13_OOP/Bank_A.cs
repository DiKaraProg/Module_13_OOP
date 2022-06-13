using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOdule13_OOP
{
    public class Bank_A
    {

        public static ObservableCollection<Client> AllClientsInfo = new ObservableCollection<Client>();


        public enum TypeAccounts
        {
            DemandAccount,
            DepositAccount
        }


        public static void SerialiseAllClientInfo()
        {
            
            
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            };
            using ( StreamWriter sw = new StreamWriter("Data.json"))
            {
                string json = JsonConvert.SerializeObject(Bank_A.AllClientsInfo,Formatting.Indented,settings);
                sw.WriteLine(json);
            }
            
            
        }
        public static ObservableCollection<Client> DeserialiseAllClientInfo()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            };
            ObservableCollection<Client> clients = new ObservableCollection<Client>();
            using (StreamReader sr = new StreamReader("Data.json"))
            {
                string json = sr.ReadToEnd();
                clients = JsonConvert.DeserializeObject<ObservableCollection<Client>>(json,settings);

            }
            return clients;

        }
       
    }
}
