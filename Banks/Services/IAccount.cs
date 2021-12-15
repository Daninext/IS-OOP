using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banks.Services
{
    public interface IAccount
    {
        public void DepositMoney(long money);
        public void WithdrawMoney(long money);
        public void Transaction(long money, IAccount account);
    }
}
