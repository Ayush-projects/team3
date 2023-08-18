namespace BankAPI.DTOS
{
    public class CustomerDTO
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string? City { get; set; }
        public string? Email { get; set;}
        public int Pincode { get; set;}
    }
}
