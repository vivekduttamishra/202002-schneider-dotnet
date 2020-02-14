namespace ConceptArchitect.Finance.V3
{
    public class InvalidCredentialsException : BankingException
    {
        public InvalidCredentialsException(int accountNumber, string message="Invalid Credentials") : base(accountNumber, message)
        {
        }
    }


}