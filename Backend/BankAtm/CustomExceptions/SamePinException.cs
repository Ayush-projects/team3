namespace BankAtm.CustomExceptions
{
    public class SamePinException : Exception
    {
        public override string Message
        {
            get { return "New pin is same as old pin"; }
        }
    }
}
