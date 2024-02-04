using System.ComponentModel.DataAnnotations;

namespace electroinc_blood_bank.Dtos
{
    public class ReciptionistDto
    {
        public int ID { get; set; }
        public string EmployeeName { get; set; }
        public int Phone { get; set; }
        public Guid Password { get; set; }
        public int BloodBankId { get; set; }
    }
}
