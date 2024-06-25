using System.ComponentModel.DataAnnotations;

namespace electroinc_blood_bank.Models
{
    public class Hospital
    {
        public int ID { get; set; } 
        public string NameEn { get; set; }
        public string NameAr { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string Location { get; set; }

        [Required]
        [StringLength(11)]
        public string Phone { get; set; }

        public virtual List<Orders> Orders { get; set; }
       
    }
}
