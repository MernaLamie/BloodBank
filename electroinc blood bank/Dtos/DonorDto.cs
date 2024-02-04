using electroinc_blood_bank.Models;
using System.ComponentModel.DataAnnotations;

namespace electroinc_blood_bank.Dtos
{
    public class DonorDto
    {
        public int ID { get; set; }
       
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

       
  //      public Sex Sex { get; set; }

       
        public string Phone { get; set; }

    //    public BloodRh bloodRh { get; set; }
    }
}
