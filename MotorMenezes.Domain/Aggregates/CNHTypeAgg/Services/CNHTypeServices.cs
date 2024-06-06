using Microsoft.EntityFrameworkCore;
using MotorMenezes.Domain.Aggregates.CNHTypeAgg.Entity;
using MotorMenezes.Domain.Aggregates.CNHTypeAgg.Interfaces;
using MotorMenezes.Domain.Interfaces;

namespace MotorMenezes.Domain.Aggregates.CNHTypeAgg.Services
{
    public class CNHTypeServices : ICNHTypeServices
    {
        protected readonly IUnitOfWork _unitOfWork;

        public CNHTypeServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<CNHType>> GetList()
            => await _unitOfWork.CNHTypeRepository.GetAll().ToListAsync();
    }
}
