using System.ComponentModel.DataAnnotations;

namespace electroinc_blood_bank.Dtos
{
    public class OrderDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
    }
}
