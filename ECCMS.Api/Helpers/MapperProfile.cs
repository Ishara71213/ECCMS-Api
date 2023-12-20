using AutoMapper;
using ECCMS.Api.Dtos;
using ECCMS.Core.Entities;

namespace ECCMS.Api.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            CreateMap<InstitutionDto, Institution>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<RolePostDto, Role>().ReverseMap();
            CreateMap<RoleDto, Role>().ReverseMap();
            CreateMap<CityDto, City>().ReverseMap();

            CreateMap<Employee, EmployeeDto>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.RoleId))
            .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src!.Role!.Name))
            .ForMember(dest => dest.Designation, opt => opt.MapFrom(src => src.Designation))
            .ForMember(dest => dest.ChangePassword, opt => opt.MapFrom(src => src.ChangePassword))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src!.User!.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src!.User!.LastName))
            .ForMember(dest => dest.Nic, opt => opt.MapFrom(src => src!.User!.Nic))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src!.User!.Gender))
            .ForMember(dest => dest.BranchId, opt => opt.MapFrom(src => src.BranchId))
            .ForMember(dest => dest.MobileNo, opt => opt.MapFrom(src => src!.User!.MobileNo))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src!.User!.Email))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src!.User!.Status))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src!.User!.Type))
            .ForMember(dest => dest.Dob, opt => opt.MapFrom(src => src!.User!.Dob));

            CreateMap<EmployeeDto, Employee>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.BranchId, opt => opt.MapFrom(src => src.BranchId))
            .ForMember(dest => dest.Designation, opt => opt.MapFrom(src => src.Designation))
            .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.RoleId))
            .ForMember(dest => dest.ChangePassword, opt => opt.MapFrom(src => src.ChangePassword));

            CreateMap<User, EmployeeDto>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.Nic, opt => opt.MapFrom(src => src.Nic))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
            .ForMember(dest => dest.MobileNo, opt => opt.MapFrom(src => src.MobileNo))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
            .ForMember(dest => dest.Dob, opt => opt.MapFrom(src => src.Dob));

            CreateMap<EmployeeDto,User> ()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.Nic, opt => opt.MapFrom(src => src.Nic))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
            .ForMember(dest => dest.MobileNo, opt => opt.MapFrom(src => src.MobileNo))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
            .ForMember(dest => dest.Dob, opt => opt.MapFrom(src => src.Dob));

            CreateMap<BranchDto, Branch>();
            CreateMap<Branch, BranchDto>();

            CreateMap<CrimeTypeDto, CrimeType>().ReverseMap();
            CreateMap<CrimeTypePostDto, CrimeType>().ReverseMap();

            CreateMap<InquiryPostDto, Inquiry>().ReverseMap();
            CreateMap<Inquiry, InquiryDto>()
            .ForMember(dest => dest.CrimeTypeName, opt => opt.MapFrom(src => src.CrimeType!.Name));
            CreateMap<InquiryDto, Inquiry>();

            CreateMap<ProvinceDto, Province>().ReverseMap();
        }

       
    }
}
