using electroinc_blood_bank.Models;

namespace electroinc_blood_bank.Dtos
{
    public class DonorHistoryDto
    {
        public int ID { get; set; }
        public DateTime DateOfDonation { get; set; }
        public DonationType type { get; set; }

        public bool? IsExpire {  get; set; }
        public int DonationAmout { get; set; }
        public int BloodBankID { get; set; }
        public int BloodID { get; set; }
        public string? bloodRh { get; set; }
        public int DonorID { get; set; }


    }
}
