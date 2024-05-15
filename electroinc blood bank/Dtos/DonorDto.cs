using electroinc_blood_bank.Models;
using System.ComponentModel.DataAnnotations;

namespace electroinc_blood_bank.Dtos
{
    public class DonorDto
    {
        public int? ID { get; set; }
       
        public string NameEn { get; set; }

        public string NameAr { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        public string Phone { get; set; }

        public int BloodID { get; set; }
        //    public BloodRh bloodRh { get; set; }
    }
}
