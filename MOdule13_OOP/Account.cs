using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOdule13_OOP
{
      public class Account<T>
    {
        T Value = default(T);
        
        double sum;
        int accountId;
        
        
        public double Sum { get { return sum; } set { sum = value; } }
        
        
        public int AccountId { get { return accountId; } set { accountId = value; } }
        public Account(double Sum)
        {
            this.sum = Sum;
           
            
            foreach (var item in Bank_A.AllClientsInfo)
            {
                this.accountId = item.Listaccount.Count;
                this.accountId++;
            }

        }
        public Account()
        {

        }
       
        

        

       
       
    }
}
