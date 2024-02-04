namespace electroinc_blood_bank.Models
{
    public class DonorHistory
    {
        public int ID { get; set; }
        public DateTime DateOfDonation { get; set;}
        public string type { get; set; }

        public int DonationAmout { get;set;}
        public int BloodBankID { get; set; }
        public virtual BloodBank BloodBank { get; set; }    
        public int BloodID { get; set; }
        public virtual Blood Blood { get; set; }

       
    }
}
