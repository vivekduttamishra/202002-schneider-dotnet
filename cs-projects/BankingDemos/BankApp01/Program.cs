using ConceptArchitect.Finance;
using ConceptArchitect.Finance.V3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp01
{
    class Program
    {
        static void Main(string[] args)
        {
            //var store = new ListAccountStore();
            var store = new PersistentAccountStore(@"c:\temp\bankaccounts.dat");
            Bank icici = new Bank("ICICI", 12, store);
            

            ATM atm = new ATM(icici);
            atm.Boot();
            store.Save();
        }

        private static Bank GetBank()
        {
            //icici.OpenAccount("SavingsAccount", "Sanjay", "1234", 20000);
            //icici.OpenAccount("CurrentAccount", "Chetan", "1234", 20000);
            //icici.OpenAccount("OverdraftAccount", "Om", "1234", 20000);
            //return icici;
            return null;
        }
    }
}
