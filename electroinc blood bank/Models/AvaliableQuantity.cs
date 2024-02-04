using System.ComponentModel.DataAnnotations;

namespace electroinc_blood_bank.Models
{
    public class BloodQuantity
    {
        public int ID {  get; set; }
       
        public string type { get; set; }
        public int quantity { get; set; } 
        public int BloodID { get; set; }
        public virtual Blood Blood { get; set; }
        public int BloodBankID { get; set; }
        public virtual BloodBank BloodBank { get; set; }



    }
    /*
    public enum Type
    {
        plasma,
        platelets,
        PRBCS
    }
    */
}
