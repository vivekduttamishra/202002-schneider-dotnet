using System;
using System.Runtime.Serialization;

namespace ConceptArchitect.Finance.V3
{
    public class BankingException : Exception
    {
        public int AccountNumber { get; set; }

        public BankingException(int accountNumber, string message): base(message)
        {
            AccountNumber = accountNumber;
        }

        public override string ToString()
        {
            return string.Format("Error with account number {0} : {1}", AccountNumber, Message);
        }
    }


    [Serializable]
    public class InvalidDenominationException : BankingException
    {
        public InvalidDenominationException(int accountNumber, string message="Insufficient Balance") : base(accountNumber, message)
        {
        }
    }
    

}