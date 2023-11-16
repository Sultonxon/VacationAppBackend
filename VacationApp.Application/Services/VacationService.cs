using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using VacationApp.Common.Entities;
using VacationApp.Common.Models;
using VacationApp.Common.Repositories;
using VacationApp.Common.Services;

namespace VacationApp.Application.Services;

public class VacationService : IVacationService
{
    private readonly IVacationRepository _vacationRepository;
    private readonly IVacationStatusRepository _vacationStatusRepository;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly ILogger<VacationService> _logger;
    private readonly IConfigurationSection _vacationSettings;
    
    public VacationService(IVacationRepository vacationRepository, 
        IVacationStatusRepository vacationStatusRepository, 
        IHttpContextAccessor contextAccessor,
        ILogger<VacationService> logger,
        IConfiguration configuration)
    {
        _vacationRepository = vacationRepository;
        _vacationStatusRepository = vacationStatusRepository;
        _contextAccessor = contextAccessor;
        _logger = logger;
        _vacationSettings = configuration.GetSection("Vacation");
    }

    public async Task Create(DateTime from, DateTime to, string reason)
    {
        var available = await AvailableDaysForThisYear();
        
        if (available < (to - from).Days)
        {
            throw new Exception("Not enough days");
        }
        
        var vacation = new VacationEntity();
        vacation.Id = Guid.NewGuid().ToString();
        vacation.DateFrom = from;
        vacation.DateTo = to;
        vacation.Reason = reason;
        vacation.VacationStatusId = (await _vacationStatusRepository.GetByName("Pending")).Id;
        vacation.UserId = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        await _vacationRepository.Add(vacation);
    }

    public async Task Approve(string id)
    {
        try
        {
            var vacation = await _vacationRepository.GetById(id);
            vacation.VacationStatusId = (await _vacationStatusRepository.GetByName("Approved")).Id;
            await _vacationRepository.Update(vacation);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            throw;
        }
    }

    public async Task Reject(string id, string comment)
    {
        try
        {
            var vacation = await _vacationRepository.GetById(id);
            vacation.VacationStatusId = (await _vacationStatusRepository.GetByName("Rejected")).Id;
            await _vacationRepository.Update(vacation);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            throw;
        }
    }

    public async Task<int> AvailableDaysForThisYear()
    {
        var max = Convert.ToInt32(_vacationSettings["AllovedVacationDays"]);
        var userId = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        var vacations = await _vacationRepository.GetByUserIdAll(userId);
        var available = max - vacations.Where(x => x.DateFrom.Year == DateTime.Now.Year).Sum(x => (x.DateTo - x.DateFrom).Days);
        return available >= 0 ? available : 0;
    }

    public async Task<VacationEntity> GetById(string id)
    {
        return await _vacationRepository.GetById(id);
    }

    public async Task<PagedResult<VacationEntity>> GetPaged(int page, int pageSize)
    {
        var items = (await _vacationRepository.GetPaged(page, pageSize)).ToList();
        return new PagedResult<VacationEntity>
        {
            Items = items,
            Page = page,
            PageSize = pageSize,
            TotalCount = _vacationRepository.Count()
        };
    }

    public async Task<PagedResult<VacationEntity>> GetByUserId(int page, int pageSize)
    {
        var userId = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        var vacations = (await _vacationRepository.GetByUserId(userId, page, pageSize)).ToList();
        return new PagedResult<VacationEntity>
        {
            Items = vacations,
            Page = page,
            PageSize = pageSize,
            TotalCount = _vacationRepository.Count()
        };
    }
    
    public async Task<PagedResult<VacationEntity>> GetByUserId(int page, int pageSize, string userId)
    {
        var vacations = (await _vacationRepository.GetByUserId(userId, page, pageSize)).ToList();
        return new PagedResult<VacationEntity>
        {
            Items = vacations,
            Page = page,
            PageSize = pageSize,
            TotalCount = _vacationRepository.Count()
        };
    }

    public async Task<PagedResult<VacationEntity>> GetByStatusId(string statusId, int page, int pageSize)
    {
        var vacations = (await _vacationRepository.GetByStatusId(statusId, page, pageSize)).ToList();
        return new PagedResult<VacationEntity>
        {
            Items = vacations,
            Page = page,
            PageSize = pageSize,
            TotalCount = _vacationRepository.Count()
        };
    }

    public async Task<IList<VacationEntity>> GetByUserIdAll()
    {
        var userId = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return (await _vacationRepository.GetByUserIdAll(userId)).ToList();
    }
    
    public async Task Delete(string id)
    {
        VacationEntity vacation = null;
        if(!_contextAccessor.HttpContext.User.IsInRole("Admin") && !_contextAccessor.HttpContext.User.IsInRole("SuperAdmin"))
        {
            var userId = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            vacation = await _vacationRepository.GetById(id);
            if (vacation.UserId != userId)
            {
                throw new Exception("You can't delete this vacation");
            }
            
            
        }
        
        await _vacationRepository.Delete(vacation?? new VacationEntity{Id = id});
    }
}