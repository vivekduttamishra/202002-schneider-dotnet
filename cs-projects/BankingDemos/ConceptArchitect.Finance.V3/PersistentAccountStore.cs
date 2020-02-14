using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Finance.V3
{
    public class PersistentAccountStore : IAccountStore
    {
        Dictionary<int, BankAccount> accounts;

        public int AddAccount(int accountNumber, BankAccount account)
        {
            accounts[accountNumber] = account;
            return accountNumber;
        }

        public BankAccount GetAccount(int accountNumber)
        {
            ValidateAccountNumber(accountNumber);
            return accounts[accountNumber];
        }

        private void ValidateAccountNumber(int accountNumber)
        {
            if (!accounts.ContainsKey(accountNumber))
                throw new InvalidAccountException(accountNumber);
        }

        public List<BankAccount> GetAllAccounts()
        {
            return accounts.Values.ToList();
        }

        public void RemoveAccount(int accountNumber)
        {
            ValidateAccountNumber(accountNumber);
            accounts.Remove(accountNumber);
            
        }

        string path;
        public void Save()
        {
            using(var writer=new StreamWriter(path))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(writer.BaseStream,accounts);
            }
        }

        public PersistentAccountStore(string path)
        {
            this.path = path;
            try
            {
                using (var reader = new StreamReader(path))
                {
                    var formatter = new BinaryFormatter();
                    this.accounts = (Dictionary<int,BankAccount>)formatter.Deserialize(reader.BaseStream);
                } 

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                this.accounts = new Dictionary<int, BankAccount>();
            }
        }
    }
}
