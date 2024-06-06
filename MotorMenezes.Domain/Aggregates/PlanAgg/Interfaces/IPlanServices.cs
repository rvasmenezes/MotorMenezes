using MotorMenezes.Domain.Aggregates.PlanAgg.Entites;

namespace MotorMenezes.Domain.Aggregates.PlanAgg.Interfaces
{
    public interface IPlanServices
    {
        Task<List<Plan>> GetList();
    }
}

