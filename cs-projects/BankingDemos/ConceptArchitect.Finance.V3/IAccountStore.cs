using System.Collections.Generic;

namespace ConceptArchitect.Finance.V3
{
    public interface IAccountStore
    {
        int AddAccount(int accountNumber, BankAccount account);
        BankAccount GetAccount(int accountNumber);
        List<BankAccount> GetAllAccounts();
        void RemoveAccount(int accountNumber);
    }
}