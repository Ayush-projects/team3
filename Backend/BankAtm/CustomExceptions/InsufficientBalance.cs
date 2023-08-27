namespace BankAtm.CustomExceptions
{
    public class InsufficientBalance : Exception
    {
        public override string Message
        {
            get { return "Insufficient Balance"; }
        }
    }
}
