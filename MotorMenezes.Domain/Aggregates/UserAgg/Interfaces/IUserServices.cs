using Microsoft.AspNetCore.Mvc;
using MotorMenezes.Domain.Aggregates.UserAgg.Dtos;
using MotorMenezes.Domain.Aggregates.UserAgg.Entities;
using MotorMenezes.Domain.Aggregates.UserAgg.Requests;
using MotorMenezes.Domain.Aggregates.UserAgg.Responses;
using MotorMenezes.Domain.Common.Dtos;

namespace MotorMenezes.Domain.Aggregates.UserAgg.Interfaces
{
    public interface IUserServices
    {
        Task<User?> ObterPorId(string id);
        Task<ResponseCreateDto<LoginResponse>> EfetuarLogin(LoginRequest request);
        Task<ResponseCreateDto<LoginResponse>> Create(CreateUserRequest request);
        Task<UserDto> GetProfile();
        Task<ResponseCreateDto<UserRequest>> Update(UserRequest request);
        Task<ResponseCreateDto<FileStreamResult>> DownloadPorId(string id);
    }
}

