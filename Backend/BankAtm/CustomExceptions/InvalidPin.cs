namespace BankAtm.CustomExceptions
{
    public class InvalidPin : Exception
    {
        public override string Message
        {
            get { return "Wrong PIN"; }
        }
    }
}
