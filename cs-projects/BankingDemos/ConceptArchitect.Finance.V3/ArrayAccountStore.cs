using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Finance.V3
{
    public class ArrayAccountStore : IAccountStore
    {
        BankAccount[] accounts = new BankAccount[100];
        int lastId;
        public int AddAccount(int accountNumber, BankAccount account)
        {
            accounts[accountNumber] = account;
            lastId = accountNumber;
            return accountNumber;
        }
        public void RemoveAccount(int accountNumber)
        {
            accounts[accountNumber] = null;
        }

        public BankAccount GetAccount(int accountNumber)
        {
            if (accountNumber < 1 || accountNumber > lastId)
                //return null;
                throw new InvalidAccountException(accountNumber);

            return accounts[accountNumber];
        }

        public List<BankAccount> GetAllAccounts()
        {
            List<BankAccount> result = new List<BankAccount>();
            foreach (var account in accounts)
                if (account != null)
                    result.Add(account);
            return result;
        }
    }
}
