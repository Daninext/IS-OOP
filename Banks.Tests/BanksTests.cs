using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Linq;
using Banks.Tools;
using Banks.Services;

namespace Banks.Tests
{
    public class BanksTests
    {
        public class Tests
        {
            private ICentralBank _centralBank;

            [SetUp]
            public void Setup()
            {
                _centralBank = null;
            }

            [Test]
            public void AddNewClientToNewBank()
            {
                _centralBank = new CentralBank();

                Bank bank = _centralBank.RegBank("Sberbank");
                Client client = bank.RegClient(new RegForm("Daniil", "Arsentev", "123456", "+123232", "Hell"));

                Assert.AreEqual(bank, _centralBank.FindBank("Sberbank"));
                Assert.AreEqual(client, bank.FindClient("123456"));
            }

            [Test]
            public void RegNewAcc_AndWait365Days()
            {
                _centralBank = new CentralBank();

                Bank bank = _centralBank.RegBank("Sberbank");
                Client client = bank.RegClient(new RegForm("Daniil", "Arsentev", "123456", "+123232", "Hell"));

                bank.CreateDebitAc(client, 100000);
                bank.ChangeDebitPers(3.65f);

                _centralBank.CapTime(365);

                Assert.AreEqual(103650, client.DebitAc.Money);
            }

            [Test]
            public void TransferMoney_AndCancelIt()
            {
                _centralBank = new CentralBank();

                Bank bank = _centralBank.RegBank("Sberbank");
                Client client = bank.RegClient(new RegForm("Daniil", "Arsentev", "123456", "+123232", "Hell"));

                bank.CreateDebitAc(client, 100000);

                Client client2 = bank.RegClient(new RegForm("Artem", "Tutov", "122563", "+1232232", "Hell 2"));

                bank.CreateDebitAc(client2, 1000);

                _centralBank.TransactionMoney(client.DebitAc, client2.DebitAc, 5000);
                Assert.AreEqual(6000, client2.DebitAc.Money);

                _centralBank.CancelLastTransaction(client.DebitAc);
                Assert.AreEqual(1000, client2.DebitAc.Money);
            }

            [Test]
            public void WithdrawMoreThanHave_CatchException()
            {
                _centralBank = new CentralBank();

                Bank bank = _centralBank.RegBank("Sberbank");
                Client client = bank.RegClient(new RegForm("Daniil", "Arsentev", "123456", "+123232", "Hell"));

                bank.CreateDebitAc(client, 1000);

                Assert.Catch<InvalidMoneyCountBanksException>(() => { bank.Withdraw(client.DebitAc, 10000); });

                Client client2 = bank.RegClient(new RegForm("Artem", "Tutov", "122563"));

                bank.CreateDebitAc(client2, 100000);

                Assert.Catch<OutOfLimitBanksException>(() => { bank.Withdraw(client2.DebitAc, 10000); });
            }
        }
    }
}
