using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOdule13_OOP
{
    internal class DemandAccount : Account
    {
        
        Bank_A.TypeAccounts typeAccount = Bank_A.TypeAccounts.DemandAccount;
        public Bank_A.TypeAccounts TypeAccount { get { return typeAccount; } set { typeAccount = value; } }

        

        public DemandAccount(double Sum) : base(Sum)
        {
            this.typeAccount = TypeAccount;
        }
    }
}
