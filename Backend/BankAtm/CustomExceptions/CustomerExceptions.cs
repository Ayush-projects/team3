namespace BankAtm.CustomExceptions
{
    public class CustomerExceptions : Exception
    {
        public override string Message
        {
            get { return "Invalid Customer ID"; }
        }
    }
}
