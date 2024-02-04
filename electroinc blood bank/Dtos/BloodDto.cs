using electroinc_blood_bank.Models;

namespace electroinc_blood_bank.Dtos
{
    public class BloodDto
    {
        public int ID { get; set; }
        public string  BloodRh { get; set; }
        public int DonorID { get; set; }
    }
}
