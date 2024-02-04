using System.ComponentModel.DataAnnotations;

namespace electroinc_blood_bank.Models
{
    public class Hospital
    {
        public int ID { get; set; } 
        public string Name { get; set; }
        public string Location { get; set; }

        [Required]
        [StringLength(10)]
        public string Phone { get; set; }

        public virtual List<Orders> Orders { get; set; }
       
    }
}
