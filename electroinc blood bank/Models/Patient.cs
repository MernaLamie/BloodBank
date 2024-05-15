using System.ComponentModel.DataAnnotations;

namespace electroinc_blood_bank.Models
{
    public class Patient
    {
        public int ID { get; set; }
        [Required]
        public string NameEn { get; set; }


        [Required]
        public string NameAr { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Gender  { get; set; }

        [Required]
        [StringLength(11)]
        public string Phone { get; set; }

        public int BloodID { get;set; }
        public virtual Blood Blood { get; set; }


    }
}
