using Microsoft.EntityFrameworkCore;
using VacationApp.Common.Entities;
using VacationApp.Common.Repositories;
using VacationApp.Data.Context;

namespace VacationApp.Data.Repositories;

public class VacationStatusRepository : IVacationStatusRepository
{
    private readonly AppDbContext _context;
    
    public VacationStatusRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<VacationStatus> GetByName(string name)
    {
        return await _context.VacationStatuses.FirstOrDefaultAsync(x => x.Name == name);
    }

    public async Task<VacationStatus> GetById(string id)
    {
        return await _context.VacationStatuses.FindAsync(id);
    }

    public Task<IEnumerable<VacationStatus>> GetAll()
    {
        return Task.FromResult(_context.VacationStatuses.AsEnumerable());
    }
}