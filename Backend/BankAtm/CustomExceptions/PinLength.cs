namespace BankAtm.CustomExceptions
{
    public class PinLength : Exception
    {
        public override string Message
        {
            get { return "Pin must be 4 digits"; }
        }
    }
}
