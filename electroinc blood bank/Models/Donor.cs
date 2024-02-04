using System.ComponentModel.DataAnnotations;

namespace electroinc_blood_bank.Models
{
    public class Donor
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [StringLength(11)]
        public string Phone { get; set; }

        public int BloodID { get; set; }
        public virtual Blood blood { get; set; }
        public virtual List<DonorHistory> History { get; set; }

        


    }



    public enum Gender
    {
        Male=1,
        Female=2
    }
}
