using electroinc_blood_bank.Models;
using System.ComponentModel.DataAnnotations;

namespace electroinc_blood_bank.Dtos
{
    public class PatientDto
    {
        public int ID { get; set; }
        [Required]
        public string NameEn { get; set; }

        [Required]

        public string NameAr { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        [StringLength(11)]
        public string Phone { get; set; }

        public int BloodID { get; set; }
    }
}
