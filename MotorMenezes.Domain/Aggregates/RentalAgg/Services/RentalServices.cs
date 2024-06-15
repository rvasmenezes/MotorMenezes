using Microsoft.EntityFrameworkCore;
using MotorMenezes.Core.ApplicationContext;
using MotorMenezes.Domain.Aggregates.RentalAgg.Entities;
using MotorMenezes.Domain.Aggregates.RentalAgg.Interfaces;
using MotorMenezes.Domain.Aggregates.RentalAgg.Requests;
using MotorMenezes.Domain.Aggregates.RentalAgg.Response;
using MotorMenezes.Domain.Common.Dtos;
using MotorMenezes.Domain.Interfaces;

namespace MotorMenezes.Domain.Aggregates.RentalAgg.Services
{
    public class RentalServices : IRentalServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMotorMenezesContext _MotorMenezesContext;

        public RentalServices(
            IUnitOfWork unitOfWork,
            IMotorMenezesContext MotorMenezesContext)
        {
            _MotorMenezesContext = MotorMenezesContext;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Rental>> GetList()
        {
            var list = _unitOfWork.RentalRepository.GetAll()
                        .Include(x => x.Plan)
                        .Include(x => x.User)
                        .AsQueryable();

            if (_MotorMenezesContext.RoleUserLogged.Contains("Motorcyclist"))
                list = list.Where(x => x.UserId == _MotorMenezesContext.UserLoggedId);

            return await list.ToListAsync();

        }

        public async Task<ResponseCreateDto<Rental>> Add(CreateRentalRequest request)
        {
            var response = new ResponseCreateDto<Rental>();

            var rental = new Rental(_MotorMenezesContext.UserLoggedId, request.PlanId, request.EndDate);

            await _unitOfWork.RentalRepository.AddAsync(rental);
            await _unitOfWork.Commit();

            response.Entity = rental;

            return response;
        }

        public async Task<ResponseCreateDto<CalculateResponse>> Calculate(CalculateRequest request)
        {
            var response = new ResponseCreateDto<CalculateResponse>();

            var cost = new CalculateResponse();

            if (request.PlanId == 0)
            {
                response.AddWarningValidation("Selecione um plano para fazer a cotação!");
                return response;
            }

            if (request.EndDate <= DateTime.Now)
            {
                response.AddWarningValidation("Data final do aluguél deve ser maior que hoje!");
                return response;
            }

            var haveCNHTypeA = await _unitOfWork.UsuarioRepository.GetAll()
                        .Include(x => x.CNHType)
                        .Where(x => x.Id == _MotorMenezesContext.UserLoggedId && x.CNHType.Description.Contains("A"))
                        .AnyAsync();

            if(!haveCNHTypeA)
            {
                response.AddWarningValidation("Somente motoristas com a Carteira 'A' podem agendar!");
                return response;
            }

            var plan = await _unitOfWork.PlanRepository.GetEntityByIdAsync(request.PlanId);

            cost.Cost = plan.Day * plan.CostPerDay;
            cost.TotalCost = plan.Day * plan.CostPerDay;
            cost.PercentageFine = plan.PercentageFine;
            cost.DaysRented = (request.EndDate - DateTime.Now.Date).Days;

            if (cost.DaysRented < plan.Day)
            {
                cost.DaysNotRented = plan.Day - cost.DaysRented;

                if (cost.DaysNotRented > 0)
                    cost.CostFine = (cost.DaysNotRented * plan.CostPerDay) * (plan.PercentageFine / 100);
            }
            else if (cost.DaysRented > plan.Day)
            {
                cost.ExtraDaysRented = cost.DaysRented - plan.Day;
                cost.CostFine = (cost.ExtraDaysRented * plan.CostPerDay) + (cost.ExtraDaysRented * 50);
            }

            cost.TotalCost = cost.TotalCost + cost.CostFine;

            response.Entity = cost;

            return response;
        }
    }
}
