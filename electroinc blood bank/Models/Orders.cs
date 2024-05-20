using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Text.Json.Serialization;

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
        public OrderFor orderFor { get; set; } 
        public int orderForID { get; set; }
        public DonationType type { get; set; }

        public bool Avaliable { get; set; }
        public virtual Blood Blood { get; set; }
        public virtual Reciptionist Reciptionist { get; set; }
    }

    public enum OrderFor
    {
        Patient=1,
        Hospital=2
    }

    public enum Status
    {
        ordered=1,
        pending=2, 
        delivered=3
    }
}
