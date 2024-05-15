namespace electroinc_blood_bank.Models
{
    public class BloodBank
    {
        public int ID { get; set; }
        public string NameEn { get; set; }

        public string NameAr { get; set; }

        public string Address { get; set; }

        public virtual List<BloodQuantity> BloodQuantity { get; set;}
    }
}
