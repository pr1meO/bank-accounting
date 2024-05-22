using System.ComponentModel.DataAnnotations.Schema;

namespace BankAccouting.Models
{
    public class Contract
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }

        [ForeignKey(nameof(Staff))]
        public int? StaffId { get; set; }
        public Staff? Staff { get; set; }

        [ForeignKey(nameof(Client))]
        public int? ClientId { get; set; }
        public Client? Client { get; set; }

        public Contract()
        {
            Date = DateTime.UtcNow.ToString("dd/MM/yyyy");
            Time = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
