namespace electroinc_blood_bank.Models
{
    public class Blood
    {
        public int ID { get; set; } 
        public BloodRh  BloodRhEn { get; set; }
        public BloodRhAr BloodRhAr { get; set; }


    }

    public enum BloodRh
    {
       A_Positive,
       A_Negative,
       B_positive,
       B_negative,
       O_positive,
       O_negative,
       AB_positive,
       AB_negative,
    }

     public enum BloodRhAr
    {
       A_Positive,
       A_Negative,
       B_positive,
       B_negative,
       O_positive,
       O_negative,
       AB_positive,
       AB_negative,
    }
}
