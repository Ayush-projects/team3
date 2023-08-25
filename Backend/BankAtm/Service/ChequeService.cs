using BankAtm.Entities;

namespace BankAtm.Service
{
    public class ChequeService : IChequeService
    {
        CustomerContext _customerContext;
        public ChequeService(CustomerContext customerContext) {
            _customerContext = customerContext;
        }
        public List<Cheque> GetChequesByAccNum(long accNum)
        {
            Account acc = _customerContext.Accounts.Find(accNum);
            if (acc == null)
            {
                throw new Exception("Invalid AccNum");
            }
            if(acc.AccStatus==0)
            {
                throw new Exception("Account disabled");
            }
            return (from cheque in _customerContext.Cheques where cheque.AccNum== accNum select cheque).ToList();

        }
    }
}
