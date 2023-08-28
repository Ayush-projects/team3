namespace BankAtm.CustomExceptions
{
    public class AlreadyEnabled : Exception
    {
    
        public override string Message
        { 
            get { return "Account already enabled"; }
        }
    }
}
