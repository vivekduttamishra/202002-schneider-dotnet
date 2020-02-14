namespace ConceptArchitect.Finance.V3
{
    public class InvalidAccountException : BankingException
    {
        public InvalidAccountException(int accountNumber, string message ="No Such Account") : base(accountNumber, message)
        {
        }
    }


}