namespace BankAccouting.Models
{
    public class Credential
    {
        public int Id { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }

        public Staff? Staff { get; set; }
    }
}
