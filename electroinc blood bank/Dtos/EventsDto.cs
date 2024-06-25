using electroinc_blood_bank.Helper;

namespace electroinc_blood_bank.Dtos;

    public class EventDto
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
   
    
    
    private IFormFile _file;
    public IFormFile eventImage
    {
        get => _file;
        set
        {
            _file = value;
            if (value != null)
            {
                Image = Upload.UploadImage(value);

            }
        }
    }

    public string? Image { get; private set; }
    public int BloodBankId { get; set; }
}
