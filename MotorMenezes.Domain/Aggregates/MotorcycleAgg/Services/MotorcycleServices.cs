using Microsoft.EntityFrameworkCore;
using MotorMenezes.Core.RabbitMQ;
using MotorMenezes.Domain.Aggregates.MotorcycleAgg.Dtos;
using MotorMenezes.Domain.Aggregates.MotorcycleAgg.Entities;
using MotorMenezes.Domain.Aggregates.MotorcycleAgg.Interfaces;
using MotorMenezes.Domain.Aggregates.MotorcycleAgg.Requests;
using MotorMenezes.Domain.Common.Dtos;
using MotorMenezes.Domain.Common.Validators;
using MotorMenezes.Domain.Interfaces;
using System.Text.Json;

namespace MotorMenezes.Domain.Aggregates.MotorcycleAgg.Services
{
    public class MotorcycleServices : IMotorcycleServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly RabbitMQServices _rabbitMQService;

        public MotorcycleServices(
            IUnitOfWork unitOfWork,
            RabbitMQServices rabbitMQService)
        {
            _unitOfWork = unitOfWork;
            _rabbitMQService = rabbitMQService;
        }

        public async Task<List<Motorcycle>> GetList(FilterMotorcycleDto filterMotorcycleDto)
            => await _unitOfWork.MotorcycleRepository.GetAll()
                .Where(x => string.IsNullOrEmpty(filterMotorcycleDto.Plate) || 
                            x.Plate.ToUpper().Contains(filterMotorcycleDto.Plate.ToUpper()))
                .OrderByDescending(x => x.Id)
                .ToListAsync();

        public async Task<Motorcycle?> GetById(string id)
            => await _unitOfWork.MotorcycleRepository.GetAll().Where(x => x.Id == id).FirstAsync();

        public async Task Add(Motorcycle motorcycle)
        {
            await _unitOfWork.MotorcycleRepository.AddAsync(motorcycle);
            await _unitOfWork.Commit();
        }

        public async Task<ResponseCreateDto<Motorcycle>> SendMessageAdd(CreateOrEditMotorcycleRequest request)
        {
            var response = new ResponseCreateDto<Motorcycle>();

            if(await _unitOfWork.MotorcycleRepository.GetAll().AnyAsync(x => x.Plate.Contains(request.Plate)))
            {
                response.AddWarningValidation(ConstantMessages.PLACA_CADASTRADA);
                return response;
            }

            var motorcycle = new Motorcycle(request.Year, request.Model, request.Plate);

            var message = JsonSerializer.Serialize(motorcycle);
            _rabbitMQService.SendMessage("add_motorcycle", message);

            if(request.Year == 2024)
                _rabbitMQService.SendMessage("add_motorcycle_year_2024", message);

            response.Entity = motorcycle;

            return response;
        }

        public async Task<ResponseCreateDto<Motorcycle>> Update(CreateOrEditMotorcycleRequest request)
        {
            var response = new ResponseCreateDto<Motorcycle>();

            if (await _unitOfWork.MotorcycleRepository.GetAll()
                .AnyAsync(x => x.Plate.Contains(request.Plate) && x.Id != request.Id))
            {
                response.AddWarningValidation(ConstantMessages.PLACA_CADASTRADA);
                return response;
            }

            var motorcycle = await GetById(request.Id);

            motorcycle.SetPlate(request.Plate);
            
            _unitOfWork.MotorcycleRepository.Update(motorcycle);
            await _unitOfWork.Commit();

            response.Entity = motorcycle;

            return response;
        }

        public async Task<ResponseCreateDto<Motorcycle>> Delete(string id)
        {
            var response = new ResponseCreateDto<Motorcycle>();

            var motorcycle = await GetById(id);

            _unitOfWork.MotorcycleRepository.Delete(motorcycle);
            await _unitOfWork.Commit();

            return response;
        }
    }
}
