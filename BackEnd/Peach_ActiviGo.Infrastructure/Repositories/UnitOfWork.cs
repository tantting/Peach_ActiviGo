using AutoMapper;
using Peach_ActiviGo.Core.Interface;
using Peach_ActiviGo.Infrastructure.Data;

namespace Peach_ActiviGo.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    //private IMapper _mapper;
    
    public UnitOfWork(AppDbContext context, IMapper mapper)
    {
        _context = context;
        //_mapper = mapper;
    }
    
    public async Task<int> SaveChangesAsync(CancellationToken ct)
    {
        return await _context.SaveChangesAsync(ct);
    }
}