using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atm
{
    internal interface IatmOperations
    {
        void TakeAction() { }

        void Withdrawal() { }
        void CheckBal() { }
        void Transfer() { }
    }
}
