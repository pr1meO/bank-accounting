using System.ComponentModel.DataAnnotations.Schema;

namespace BankAccouting.Models
{
    public class Account
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public string? TypeAccount { get; set; }

        [ForeignKey(nameof(Client))]
        public int? ClientId { get; set; }
        public Client? Client { get; set; }
    }
}
