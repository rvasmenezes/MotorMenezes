using Microsoft.EntityFrameworkCore;
using MotorMenezes.Domain.Aggregates.PlanAgg.Entites;
using MotorMenezes.Domain.Aggregates.PlanAgg.Interfaces;
using MotorMenezes.Domain.Interfaces;

namespace MotorMenezes.Domain.Aggregates.PlanAgg.Services
{
    public class PlanServices : IPlanServices
    {
        protected readonly IUnitOfWork _unitOfWork;

        public PlanServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Plan>> GetList()
            => await _unitOfWork.PlanRepository.GetAll().ToListAsync();
    }
}
