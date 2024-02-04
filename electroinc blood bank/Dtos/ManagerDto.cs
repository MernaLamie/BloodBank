using System.ComponentModel.DataAnnotations;

namespace electroinc_blood_bank.Dtos
{
    public class ManagerDto
    {
        public int ID { get; set; }
        [Required]
        public string name { get; set; }

        [Required]
        [StringLength(11)]
        public string phone { get; set; }


        public int BloodBankID { get; set; }
    }
}
