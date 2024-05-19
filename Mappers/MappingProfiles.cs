using ClassLibary;
using static System.Runtime.InteropServices.JavaScript.JSType;
using SUT23_Projekt___Avancerad_.NET.Dto;
using AutoMapper;

namespace SUT23_Projekt___Avancerad_.NET.Mappers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Customer, CustomerDto>()
             .ForMember(dest => dest.Appointments, opt => opt.MapFrom(src => src.Appointments));
            CreateMap<CustomerDto, Customer>();
            CreateMap<Appointment, AppointmentDto>()
           .ForMember(dest => dest.Company, opt => opt.MapFrom(src => src.Company))
           .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.Customer.CustomerId))
           .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.Company.CompanyId));

            CreateMap<AppointmentDto, Appointment>()
                .ForMember(dest => dest.Customer, opt => opt.Ignore())
                .ForMember(dest => dest.Company, opt => opt.Ignore());
            CreateMap<Company, CompanyDto>();
            CreateMap<CompanyDto, Company>();
            CreateMap<ChangeLog, ChangeLogDto>();
            CreateMap<ChangeLogDto, ChangeLog>();
        }
    }
}
