using MotorMenezes.Domain.Aggregates.MotorcycleAgg.Dtos;
using MotorMenezes.Domain.Aggregates.MotorcycleAgg.Entities;
using MotorMenezes.Domain.Aggregates.MotorcycleAgg.Requests;
using MotorMenezes.Domain.Common.Dtos;

namespace MotorMenezes.Domain.Aggregates.MotorcycleAgg.Interfaces
{
    public interface IMotorcycleServices
    {
        Task<List<Motorcycle>> GetList(FilterMotorcycleDto filterMotorcycleDto);
        Task<Motorcycle?> GetById(int id);
        Task Add(Motorcycle motorcycle);
        Task<ResponseCreateDto<Motorcycle>> SendMessageAdd(CreateOrEditMotorcycleRequest request);
        Task<ResponseCreateDto<Motorcycle>> Update(CreateOrEditMotorcycleRequest request);
        Task<ResponseCreateDto<Motorcycle>> Delete(int id);
    }
}

