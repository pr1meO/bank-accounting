namespace BankAccouting.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<Staff>? Staffs { get; set; }
    }
}
