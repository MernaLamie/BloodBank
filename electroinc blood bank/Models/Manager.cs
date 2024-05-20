using System.ComponentModel.DataAnnotations;

namespace electroinc_blood_bank.Models
{
    public class Manager
    {
        public int ID { get; set; }
        [Required]
        public string nameEn { get; set; }

        [Required]
        public string nameAr { get; set; }

        [Required]
        [StringLength(13)]
        public string phone { get; set; }

        
        public int BloodBankID { get; set; }
        public virtual BloodBank BloodBank { get; set; }    
    }
}
