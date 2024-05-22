using System.ComponentModel.DataAnnotations.Schema;

namespace BankAccouting.Models
{
    public class Staff : Person
    {
        public override int Id { get; set; }

        [ForeignKey(nameof(Role))]
        public int RoleId { get; set; }
        public Role? Role { get; set; }

        [ForeignKey(nameof(Credential))]
        public int CredentialId { get; set; }
        public Credential? Credential { get; set; }

        public List<Contract>? Contracts { get; set; }
    }
}
