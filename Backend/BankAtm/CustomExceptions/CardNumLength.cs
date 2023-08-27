namespace BankAtm.CustomExceptions
{
    public class CardNumLength : Exception
    {
        public override string Message
        {
            get { return "Card Number must be 16 digits"; }
        }
    }
}
