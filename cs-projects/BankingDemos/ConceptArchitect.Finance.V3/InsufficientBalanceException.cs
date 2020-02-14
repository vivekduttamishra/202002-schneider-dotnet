namespace ConceptArchitect.Finance.V3
{
    public class InsufficientBalanceException : BankingException
    {
        public InsufficientBalanceException(int accountNumber, double deficit, string message="Insufficient Balance") : base(accountNumber, message)
        {
            Deficit = deficit;
        }

        public double Deficit { get; set; }

    }
    

}