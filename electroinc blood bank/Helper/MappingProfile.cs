using AutoMapper;
using Azure.Core;
using electroinc_blood_bank.Dtos;
using electroinc_blood_bank.Models;
using System.Net.Http.Headers;
using System.Text;

namespace electroinc_blood_bank.Helper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
           CreateMap<BloodBankDto,BloodBank>();
            CreateMap<BloodBank, BloodBankDto>();

            CreateMap<HospitalDto, Hospital>();
            CreateMap<Hospital, HospitalDto>();

            CreateMap<OrderDto, Orders>();
            CreateMap<Orders, OrderDto>();

            CreateMap<DonorHistory, DonorHistoryDto>();
            CreateMap<DonorHistoryDto, DonorHistory>();

            CreateMap<Donor, DonorDto>();
            CreateMap<DonorDto, Donor>();

            CreateMap<Patient, PatientDto>();
            CreateMap<PatientDto, Patient>();

            CreateMap<Blood, BloodDto>();
            CreateMap<BloodDto, Blood>();

            CreateMap<BloodQuantity, BloodQuantityDto>();
            CreateMap<BloodQuantityDto, BloodQuantity>();

            CreateMap<EventDto, Event>();
            CreateMap<Event, EventDto>();

            CreateMap<ReturnedOrderDto, Orders>();
            CreateMap<Orders, ReturnedOrderDto>();
            CreateMap<Reciptionist, ReciptionistDto>();
            CreateMap<ReciptionistDto, Reciptionist>();


          

        }

        public class  ConvertFormFileToString : IValueConverter<IFormFile, string>
        {



            public string Convert(IFormFile source, ResolutionContext context)
            {
                // Convert the IFormFile to a string
                // You can use any method or library to perform the conversion
                // For example, you can read the contents of the file and convert it to a string
                using (StreamReader reader = new StreamReader(source.OpenReadStream()))
                {
                    string fileContent = reader.ReadToEnd();
                    return fileContent;
                }/*
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                {
                    var files = Request.Form.Files;
                    string imagesPath ;

                    foreach (var file in files)
                    {

                        if (file.Length > 0)
                        {
                            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                            var fullPath = Path.Combine(pathToSave, fileName);
                            var dbPath = Path.Combine(folderName, fileName); //you can add this path to a list and then return all dbPaths to the client if require
                            imagesPath.Add(dbPath);
                            using (var stream = new FileStream(fullPath, FileMode.Create))
                            {
                                file.CopyTo(stream);
                            }
                        }
                    }
                    return imagesPath;
                */







                }
            }

        public class StringToFormFileConverter : IValueConverter<string, IFormFile>
        {
            public IFormFile Convert(string source, ResolutionContext context)
            {
                // Convert the string to a byte array
                byte[] fileBytes = Encoding.UTF8.GetBytes(source);

                // Create a MemoryStream from the byte array
                using (MemoryStream memoryStream = new MemoryStream(fileBytes))
                {
                    // Create an instance of FormFile using the MemoryStream
                    IFormFile formFile = new FormFile(memoryStream, 0, fileBytes.Length, "fileName", "fileName.jpg");

                    return formFile;
                }
            }
        }
    }
}
