using Microsoft.EntityFrameworkCore;
using MotorMenezes.Core.Helpers;
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

        public async Task<Motorcycle?> GetById(int id)
            => await _unitOfWork.MotorcycleRepository.GetEntityByIdAsync(id);

        public async Task Add(Motorcycle motorcycle)
        {
            await _unitOfWork.MotorcycleRepository.AddAsync(motorcycle);
            await _unitOfWork.Commit();
        }

        public async Task<ResponseCreateDto<Motorcycle>> SendMessageAdd(CreateOrEditMotorcycleRequest request)
        {
            var response = new ResponseCreateDto<Motorcycle>();

            if (string.IsNullOrEmpty(request.Model))
            {
                response.AddWarningValidation(ConstantMessages.MODELO_OBRIGATORIO);
                return response;
            }

            if (string.IsNullOrEmpty(request.Plate) || !Utilidades.ValidarPlaca(request.Plate))
            {
                response.AddWarningValidation(ConstantMessages.VEICULO_PLACA_INVALIDA);
                return response;
            }

            if(await _unitOfWork.MotorcycleRepository.GetAll().AnyAsync(x => x.Plate.Contains(request.Plate)))
            {
                response.AddWarningValidation(ConstantMessages.PLACA_CADASTRADA);
                return response;
            }

            if (request.Year < 2000 || request.Year > DateTime.Now.AddYears(1).Year)
            {
                response.AddWarningValidation("O ano deve ser entre 2000 e " + DateTime.Now.AddYears(1).Year);
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

            if (!Utilidades.ValidarPlaca(request.Plate))
            {
                response.AddWarningValidation(ConstantMessages.VEICULO_PLACA_INVALIDA);
                return response;
            }

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

        public async Task<ResponseCreateDto<Motorcycle>> Delete(int id)
        {
            var response = new ResponseCreateDto<Motorcycle>();

            var motorcycle = await GetById(id);

            _unitOfWork.MotorcycleRepository.Delete(motorcycle);
            await _unitOfWork.Commit();

            return response;
        }
    }
}
