using MotorMenezes.Domain.Aggregates.RentalAgg.Entities;
using MotorMenezes.Domain.Aggregates.RentalAgg.Requests;
using MotorMenezes.Domain.Aggregates.RentalAgg.Response;
using MotorMenezes.Domain.Common.Dtos;

namespace MotorMenezes.Domain.Aggregates.RentalAgg.Interfaces
{
    public interface IRentalServices
    {
        Task<List<Rental>> GetList();
        Task<ResponseCreateDto<Rental>> Add(CreateRentalRequest request);
        Task<ResponseCreateDto<CalculateResponse>> Calculate(CalculateRequest request);
    }
}

