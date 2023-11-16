using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VacationApp.Common.Entities;
using VacationApp.Common.Repositories;
using VacationApp.Data.Context;

namespace VacationApp.Data.Repositories;

public class VacationRepository : IVacationRepository
{
    private readonly AppDbContext _context;
    private readonly ILogger<VacationRepository> _logger;
    
    public VacationRepository(AppDbContext context, ILogger<VacationRepository> logger)
    {
        _context = context;
        _logger = logger;
    }


    public async Task<VacationEntity?> GetById(string id)
    {
        return await _context.Vacations
            .Include(v => v.Status).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IQueryable<VacationEntity>> GetPaged(int page, int pageSize)
    {
        return _context.Vacations
            .Include(v => v.Status)
            .Skip((page - 1) * pageSize)
            .Take(pageSize);
    }
    
    public async Task<IQueryable<VacationEntity>> GetByUserIdAll(string userId)
    {
        return _context.Vacations
            .Include(v => v.Status).Where(x => x.UserId == userId);
    }

    public int Count()
    {
        return _context.Vacations.Count();
    }

    public async Task<IQueryable<VacationEntity>> GetByUserId(string userId, int page, int pageSize)
    {
        return _context.Vacations.Where(x => x.UserId == userId)
            .Skip((page - 1) * pageSize)
            .Take(pageSize);
    }

    public async Task<IQueryable<VacationEntity>> GetByStatusId(string statusId, int page, int pageSize)
    {
        return _context.Vacations.Where(x => x.VacationStatusId == statusId)
            .Include(v => v.Status)
            .Skip((page - 1) * pageSize)
            .Take(pageSize);
    }

    public async Task Add(VacationEntity vacation)
    {
        try
        {
            vacation.Id = vacation.Id ?? Guid.NewGuid().ToString();
            await _context.Vacations.AddAsync(vacation);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while adding vacation");
            throw new Exception(e.Message);
        }
    }

    public async Task Update(VacationEntity vacation)
    {
        try
        {
            _context.Vacations.Update(vacation);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            throw;
        }
    }

    public async Task Delete(VacationEntity vacation)
    {
        try
        {
            _context.Vacations.Remove(vacation);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            throw;
        }
    }
}