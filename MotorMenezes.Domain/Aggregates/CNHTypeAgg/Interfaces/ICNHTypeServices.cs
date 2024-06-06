using MotorMenezes.Domain.Aggregates.CNHTypeAgg.Entity;

namespace MotorMenezes.Domain.Aggregates.CNHTypeAgg.Interfaces
{
    public interface ICNHTypeServices
    {
        Task<List<CNHType>> GetList();
    }
}

