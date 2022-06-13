using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOdule13_OOP
{
    internal class DepositAccount : Account
    {
       
        Bank_A.TypeAccounts typeAccount = Bank_A.TypeAccounts.DepositAccount;
        public Bank_A.TypeAccounts TypeAccount { get { return typeAccount; } set { typeAccount = value; } }


        public DepositAccount(double Sum) : base(Sum)
        {
            this.typeAccount = TypeAccount;
        }
        
    }
}
