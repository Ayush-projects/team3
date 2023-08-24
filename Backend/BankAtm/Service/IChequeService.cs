using BankAtm.Entities;

namespace BankAtm.Service
{
    public interface IChequeService
    {
        List<Cheque> GetChequesByAccNum(long accNum);
    }
}
