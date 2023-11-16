using VacationApp.Common.Entities;

namespace VacationApp.Common.Repositories;

public interface IVacationRepository
{
    Task<VacationEntity> GetById(string id);
    Task<IQueryable<VacationEntity>> GetPaged(int page, int pageSize);
    Task<IQueryable<VacationEntity>> GetByUserId(string userId, int page, int pageSize);
    Task<IQueryable<VacationEntity>> GetByStatusId(string statusId, int page, int pageSize);

    Task<IQueryable<VacationEntity>> GetByUserIdAll(string userId);
    
    int Count();
    
    Task Add(VacationEntity vacation);
    Task Update(VacationEntity vacation);
    Task Delete(VacationEntity vacation);
}