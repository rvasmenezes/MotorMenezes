using MotorMenezes.Domain.Aggregates.CNHTypeAgg.Entity;
using MotorMenezes.Domain.Aggregates.MotorcycleAgg.Entities;
using MotorMenezes.Domain.Aggregates.PlanAgg.Entites;
using MotorMenezes.Domain.Aggregates.RentalAgg.Entities;
using MotorMenezes.Domain.Aggregates.UserAgg.Entities;

namespace MotorMenezes.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IBaseEFRepository<User> UsuarioRepository { get; }
        IBaseEFRepository<Rental> RentalRepository { get; }
        IBaseEFRepository<Plan> PlanRepository { get; }
        IBaseEFRepository<CNHType> CNHTypeRepository { get; }
        IBaseEFRepository<Motorcycle> MotorcycleRepository { get; }

        Task<int> Commit();
        void Rollback();
    }
}
