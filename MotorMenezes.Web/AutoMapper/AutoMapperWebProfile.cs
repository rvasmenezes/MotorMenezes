using AutoMapper;
using MotorMenezes.Domain.Aggregates.MotorcycleAgg.Entities;
using MotorMenezes.Domain.Aggregates.UserAgg.Dtos;
using MotorMenezes.Domain.Aggregates.UserAgg.Entities;
using MotorMenezes.Web.Models.ViewModels.AccountViewModel;
using MotorMenezes.Web.Models.ViewModels.MotorcyclesViewModel;

namespace MotorMenezes.Web.AutoMapper
{
    public class AutoMapperWebProfile : Profile
    {
        public AutoMapperWebProfile()
        {
            CreateMap<ProfileViewModel, UserDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<MotorcycleCreateOrEditViewModel, Motorcycle>().ReverseMap();            
        }
    }
}
