using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBankAccouting.Struct;

namespace TestBankAccouting.Model
{
    public class Contract
    {
        [Key]
        public int ID { get; set; }
        public int ClientID { get; set; }
        public int StaffID { get; set; }

        [NotMapped]
        public Date DateСonclusion { get; set; }
        [NotMapped]
        public Time TimeСonclusion { get; set; }

        public Contract()
        {
            
        }

        public Contract(int clientID, int staffID, Date dateСonclusion, Time timeСonclusion)
        {
            ClientID = clientID;
            StaffID = staffID;
            DateСonclusion = dateСonclusion;
            TimeСonclusion = timeСonclusion;
        }
    }
}
