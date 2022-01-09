using System;
using NUnit.Framework;
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

                Bank bank = _centralBank.RegBank("Sberbank", new DynamicPercentages());
                Client client = bank.RegClient(new RegFormBuilder("Daniil", "Arsentev", "123456"));
                client.FormBuilder.AddAdress("Hell");

                Assert.AreEqual(bank, _centralBank.FindBank("Sberbank"));
                Assert.AreEqual(client, bank.FindClient("123456"));
            }

            [Test]
            public void RegNewAcc_AndWait365Days()
            {
                _centralBank = new CentralBank();

                Bank bank = _centralBank.RegBank("Sberbank", new DynamicPercentages());
                Client client = bank.RegClient(new RegFormBuilder("Daniil", "Arsentev", "123456"));

                bank.CreateDebitAc(client, 100000);
                bank.ChangeDebitPers(3.65f);

                _centralBank.CapTime(new DateTime(2021, 1, 1).AddYears(1)); // Date changed for the test

                Assert.AreEqual(104426, client.Accounts[0].ShowMoney());
            }

            [Test]
            public void TransferMoney_AndCancelIt()
            {
                _centralBank = new CentralBank();

                Bank bank = _centralBank.RegBank("Sberbank", new DynamicPercentages());
                Client client = bank.RegClient(new RegFormBuilder("Daniil", "Arsentev", "123456"));

                bank.CreateDebitAc(client, 100000);

                Client client2 = bank.RegClient(new RegFormBuilder("Artem", "Tutov", "122563"));

                bank.CreateDebitAc(client2, 1000);

                _centralBank.TransactionMoney(client.Accounts[0], client2.Accounts[0], 5000);
                Assert.AreEqual(6000, client2.Accounts[0].ShowMoney());

                _centralBank.CancelLastTransaction(client.Accounts[0]);
                Assert.AreEqual(1000, client2.Accounts[0].ShowMoney());
            }

            [Test]
            public void WithdrawMoreThanHave_CatchException()
            {
                _centralBank = new CentralBank();

                Bank bank = _centralBank.RegBank("Sberbank", new DynamicPercentages());
                Client client = bank.RegClient(new RegFormBuilder("Daniil", "Arsentev", "123456"));
                client.FormBuilder.AddAdress("Hell");
                client.FormBuilder.AddTelephone("+7541684");

                bank.CreateDebitAc(client, 1000);

                Assert.Catch<InvalidMoneyCountBanksException>(() => { bank.Withdraw(client.Accounts[0], 10000); });

                Client client2 = bank.RegClient(new RegFormBuilder("Artem", "Tutov", "122563"));

                bank.CreateDebitAc(client2, 100000);

                Assert.Catch<OutOfLimitBanksException>(() => { bank.Withdraw(client2.Accounts[0], 10000); });
            }
        }
    }
}
