using VacationApp.Common.Entities;
using VacationApp.Common.Models;

namespace VacationApp.Common.Services;

public interface IVacationService
{
    Task Create(DateTime from, DateTime to, string reason);
    Task Approve(string id);
    Task Reject(string id, string comment);
    Task<int> AvailableDaysForThisYear();
    
    
    Task<VacationEntity> GetById(string id);
    Task<PagedResult<VacationEntity>> GetPaged(int page, int pageSize);
    Task<PagedResult<VacationEntity>> GetByUserId(int page, int pageSize);
    Task<PagedResult<VacationEntity>> GetByUserId(int page, int pageSize, string userId);
    Task<PagedResult<VacationEntity>> GetByStatusId(string statusId, int page, int pageSize);

    Task<IList<VacationEntity>> GetByUserIdAll();
    Task Delete(string id);
}
