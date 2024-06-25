using electroinc_blood_bank.Models;
using System.ComponentModel.DataAnnotations;

namespace electroinc_blood_bank.Dtos
{
    public class OrderDto
    {
        public int id { get; set; }
        public int BloodAmount { get; set; }
        public DateTime OrderAt { get; set; }
        public DonationType type { get; set; }
        public OrderFor orderFor { get; set; }
        public int orderForID { get; set; }
        public Decimal Cost { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public int BloodID { get; set; }
        public bool Avaliable { get; set; }
    
        public Status Status { get; set; }
        public int ReciptionistID { get; set; }
        
    }
}
