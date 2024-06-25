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
       A_Positive=1,
       A_Negative=2,
       B_positive=3,
       B_negative=4,
       O_positive=5,
       O_negative=6,
       AB_positive=7,
       AB_negative=8,
    }

     public enum BloodRhAr
    {
        A_Positive = 1,
        A_Negative = 2,
        B_positive = 3,
        B_negative = 4,
        O_positive = 5,
        O_negative = 6,
        AB_positive = 7,
        AB_negative = 8,
    }
}
