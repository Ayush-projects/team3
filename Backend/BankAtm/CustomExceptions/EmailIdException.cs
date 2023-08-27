namespace BankAtm.CustomExceptions
{
    public class EmailIdException : Exception
    {
        public override string Message
        {
            get { return "Email ID is already used by another customer"; }
        }

    }
}
