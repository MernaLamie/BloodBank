using AutoMapper;
using electroinc_blood_bank.Dtos;
using electroinc_blood_bank.Models;
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

            CreateMap<EventDto, Event>().ForMember(e => e.Image, opt => opt.Ignore());
            CreateMap<Event, EventDto>().ForMember(e=>e.Image,opt=>opt.Ignore());


            CreateMap<Reciptionist, ReciptionistDto>();
            CreateMap<ReciptionistDto, Reciptionist>();


          

        }


    }
}
