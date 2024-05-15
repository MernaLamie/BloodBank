namespace electroinc_blood_bank.Models
{
    public class DonorHistory
    {
        public int ID { get; set; }
        public DateTime DateOfDonation { get; set;}
        public DonationType type { get; set; }

        public int DonationAmout { get;set;}
        public int BloodBankID { get; set; }
        public virtual BloodBank BloodBank { get; set; }    
        public int BloodID { get; set; }
        public virtual Blood Blood { get; set; }
        public int DonorID { get; set; }
        public virtual Donor Donor { get; set; }

    }

    public enum DonationType
    {
        Plasma=1,
        platelets=2,
        PRBCS=3
    }
}
