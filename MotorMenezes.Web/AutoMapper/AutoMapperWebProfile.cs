using AutoMapper;
using MotorMenezes.Domain.Aggregates.MotorcycleAgg.Entities;
using MotorMenezes.Domain.Aggregates.MotorcycleAgg.Requests;
using MotorMenezes.Domain.Aggregates.UserAgg.Dtos;
using MotorMenezes.Domain.Aggregates.UserAgg.Entities;
using MotorMenezes.Domain.Aggregates.UserAgg.Requests;
using MotorMenezes.Web.Models.ViewModels.AccountViewModel;
using MotorMenezes.Web.Models.ViewModels.MotorcyclesViewModel;

namespace MotorMenezes.Web.AutoMapper
{
    public class AutoMapperWebProfile : Profile
    {
        public AutoMapperWebProfile()
        {
            CreateMap<ProfileViewModel, UserDto>().ReverseMap();
            CreateMap<ProfileViewModel, UserRequest>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<MotorcycleCreateViewModel, Motorcycle>().ReverseMap();
            CreateMap<MotorcycleCreateViewModel, CreateOrEditMotorcycleRequest>().ReverseMap();
            CreateMap<MotorcycleEditViewModel, CreateOrEditMotorcycleRequest>().ReverseMap();
        }
    }
}
