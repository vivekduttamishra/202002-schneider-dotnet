using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Finance.V3
{
    public class ListAccountStore : IAccountStore
    {
        List<BankAccount> accounts = new List<BankAccount>();
        int lastId;
        public int AddAccount(int accountNumber, BankAccount account)
        {
            //accounts[accountNumber] = account;
            accounts.Add(account);
            lastId = accountNumber;
            return accountNumber;
        }
        public void RemoveAccount(int accountNumber)
        {
            //accounts[accountNumber] = null;
            var account = GetAccount(accountNumber);
            accounts.Remove(account);
        }

        public BankAccount GetAccount(int accountNumber)
        {
            foreach (var account in accounts)
                if (account.AccountNumber == accountNumber)
                    return account;
            throw new InvalidAccountException(accountNumber);
        }

        public List<BankAccount> GetAllAccounts()
        {
            return accounts;
        }
    }
}
