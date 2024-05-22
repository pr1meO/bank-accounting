namespace BankAccouting.Models
{
    public class Client : Person
    {
        private static int counter = 20221855; 

        public override int Id { get; set; }
        public int AccountNumber { get; set; }

        public List<Contract>? Contracts { get; set; }
        public List<Account>? Accounts { get; set; }

        public Client() => AccountNumber = counter++;
    }
}
