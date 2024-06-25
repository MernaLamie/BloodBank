namespace electroinc_blood_bank.Models
{
    public class Event
    {
        public int Id { get; set; } 
        public string titleEn { get; set; }
        public string? titleAr { get; set; }
        public string DescriptionEn { get; set; }
        public string? DescriptionAr { get; set; }
        public string AddressEn { get; set; }
        public string? AddressAr { get; set; }

        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public string? Image { get; set; }
        public int BloodBankId {  get; set; }
        public virtual BloodBank BloodBank { get; set; }
    }
}
