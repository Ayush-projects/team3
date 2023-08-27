namespace BankAtm.CustomExceptions
{
    public class AccountDisabled : Exception
    {
        public override string Message
        {
            get { return "Account is disabled"; }
        }
    }
}
