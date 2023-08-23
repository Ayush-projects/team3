using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BankAtm.DTOS
{
    public class CustomerDetailsDTO
    {
        public string Name { get; set; }

        public string ContactNo { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }
    }
}
