using electroinc_blood_bank.Models;

namespace electroinc_blood_bank.Dtos
{
    public class BloodQuantityDto
    {
        public int ID { get; set; }

        public DonationType type { get; set; }
        public int quantity { get; set; }
        public int BloodID { get; set; }
        public int BloodBankID { get; set; }
     
    }
}
