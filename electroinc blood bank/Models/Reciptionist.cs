using System.ComponentModel.DataAnnotations;

namespace electroinc_blood_bank.Models
{
    public class Reciptionist
    {
        public int ID {  get; set; }
        public string EmployeeName { get; set; }

        [Required]
        [StringLength(11)]
        public string Phone { get; set; }

        public Guid Password { get; set; }  
        public int BloodBankId { get; set; }
        public virtual BloodBank BloodBank { get; set; }

    }
}
