using System.ComponentModel.DataAnnotations;

namespace electroinc_blood_bank.Dtos
{
    public class HospitalDto
    {

        public int ID { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string Location { get; set; }

        [Required]
        [StringLength(11)]
        public string Phone { get; set; }
    }
}
