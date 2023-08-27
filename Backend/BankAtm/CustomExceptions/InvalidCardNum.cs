namespace BankAtm.CustomExceptions
{
    public class InvalidCardNum : Exception
    {
        public override string Message
        {
            get { return "Invalid Card Number"; }
        }
    }
}
