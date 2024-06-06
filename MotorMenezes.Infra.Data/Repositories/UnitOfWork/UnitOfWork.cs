using MotorMenezes.Domain.Aggregates.CNHTypeAgg.Entity;
using MotorMenezes.Domain.Aggregates.MotorcycleAgg.Entities;
using MotorMenezes.Domain.Aggregates.PlanAgg.Entites;
using MotorMenezes.Domain.Aggregates.RentalAgg.Entities;
using MotorMenezes.Domain.Aggregates.UserAgg.Entities;
using MotorMenezes.Domain.Interfaces;
using MotorMenezes.Infra.Data.Context;
using MotorMenezes.Infra.Data.Repositories.EntityFramework;

namespace MotorMenezes.Infra.Data.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public EFContext _context { get; }

        private BaseEFRepository<User>? _usuarioRepository;
        private BaseEFRepository<Rental>? _rentalRepository;
        private BaseEFRepository<Plan>? _planRepository;
        private BaseEFRepository<CNHType>? _cNHTypeRepository;
        private BaseEFRepository<Motorcycle>? _motorcycleRepository;

        public UnitOfWork(EFContext context) => _context = context;

        public IBaseEFRepository<Rental> RentalRepository
            => _rentalRepository ??= new BaseEFRepository<Rental>(_context);

        public IBaseEFRepository<Plan> PlanRepository
            => _planRepository ??= new BaseEFRepository<Plan>(_context);

        public IBaseEFRepository<CNHType> CNHTypeRepository
            => _cNHTypeRepository ??= new BaseEFRepository<CNHType>(_context);

        public IBaseEFRepository<Motorcycle> MotorcycleRepository
            => _motorcycleRepository ??= new BaseEFRepository<Motorcycle>(_context);

        public IBaseEFRepository<User> UsuarioRepository
            => _usuarioRepository ??= new BaseEFRepository<User>(_context);

        public Task<int> Commit() => _context.SaveChangesAsync();

        public void Rollback() { }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}