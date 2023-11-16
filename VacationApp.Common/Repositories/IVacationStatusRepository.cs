using VacationApp.Common.Entities;

namespace VacationApp.Common.Repositories;

public interface IVacationStatusRepository
{
    Task<VacationStatus> GetByName(string name);
    Task<VacationStatus> GetById(string id);
    Task<IEnumerable<VacationStatus>> GetAll();
}