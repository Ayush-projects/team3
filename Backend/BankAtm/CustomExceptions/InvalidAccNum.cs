namespace BankAtm.CustomExceptions
{
    public class InvalidAccNum : Exception
    {
        public override string Message
        {
            get { return "Invalid Account Number"; }
        }
    }
}
