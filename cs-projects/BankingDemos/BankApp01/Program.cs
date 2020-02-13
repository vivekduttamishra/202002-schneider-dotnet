using ConceptArchitect.Finance;
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
            Bank icici = GetBank();

            ATM atm = new ATM(icici);
            atm.Boot();
        }

        private static Bank GetBank()
        {
            Bank icici = new Bank("ICICI", 12);
            icici.OpenAccount("SavingsAccount", "Sanjay", "1234", 20000);
            icici.OpenAccount("CurrentAccount", "Chetan", "1234", 20000);
            icici.OpenAccount("OverdraftAccount", "Om", "1234", 20000);
            return icici;
        }
    }
}
