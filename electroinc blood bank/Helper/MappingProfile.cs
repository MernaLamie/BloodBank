using AutoMapper;
using electroinc_blood_bank.Dtos;
using electroinc_blood_bank.Models;

namespace electroinc_blood_bank.Helper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
           CreateMap<BloodBankDto,BloodBank>();
            CreateMap<BloodBank, BloodBankDto>();

            CreateMap<HospitalDto, Hospital>();
            CreateMap<HospitalDto, Hospital>();

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


            CreateMap<Reciptionist, ReciptionistDto>();
            CreateMap<ReciptionistDto, Reciptionist>();
        }
    }
}
