namespace electroinc_blood_bank.Models
{
    public class Orders
    {
        public int id {  get; set; }
        public int BloodAmount { get; set;}
        public DateTime OrderAt { get; set; }
        public int BloodID { get; set; }
        public  Status Status  {get; set; }
        public int ReciptionistID { get; set; }
        public int HospitalID { get; set; }
        public virtual Hospital Hospital { get; set; }
        public virtual Blood Blood { get; set; }
        public virtual Reciptionist Reciptionist { get; set; }
    }

    public enum Status
    {
        ordered,
        pending, 
        delivered
    }
}
