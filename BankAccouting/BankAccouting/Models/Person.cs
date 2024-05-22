namespace BankAccouting.Models
{
    public class Person
    {
        public virtual int Id { get; set; }
        public string? Lastname { get; set; }
        public string? Firstname { get; set; }
        public string? Middlename { get; set; }
        public string? Gender { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
