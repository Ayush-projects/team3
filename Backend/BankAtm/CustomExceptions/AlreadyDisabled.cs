namespace BankAtm.CustomExceptions
{
    public class AlreadyDisabled : Exception
    {
        public override string Message
        {
            get { return "Account already disabled"; }
        }
    }
}
