using banca_finanzas_net.Domain.Abstractions;
using banca_finanzas_net.Domain.CajaAhorros;
using banca_finanzas_net.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace banca_finanzas_net.Infrastructure.Repositories;

public class CajaAhorrosRepository : ICRUD<CajaAhorro>
{
    private readonly AppDBContext _dbContext;
    private readonly IUnitOfWork _unitOfWork;
    private readonly DbSet<CajaAhorro> _dbSet;

    public CajaAhorrosRepository(AppDBContext dbContext, IUnitOfWork unitOfWork)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<CajaAhorro>();
        _unitOfWork = unitOfWork;
    }

    public IEnumerable<CajaAhorro> GetList()
    {
        return _dbSet!.ToList();
    }

    public CajaAhorro GetById(int value)
    {
        throw new NotImplementedException();
    }

    public CajaAhorro GetByUUID(Guid value)
    {
        throw new NotImplementedException();
    }

    public Task<int> Add(CajaAhorro entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<int> Delete(int value, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<int> Update(CajaAhorro entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
