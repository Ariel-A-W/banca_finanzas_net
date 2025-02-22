using banca_finanzas_net.Domain.Abstractions;
using banca_finanzas_net.Domain.CuentasCorrientes;
using banca_finanzas_net.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace banca_finanzas_net.Infrastructure.Repositories;

public class CuentasCorrientesRepository : ICRUD<CuentaCorriente>
{
    private readonly AppDBContext _dbContext;
    private readonly IUnitOfWork _unitOfWork;
    private readonly DbSet<CuentaCorriente> _dbSet;

    public CuentasCorrientesRepository(AppDBContext dbContext, IUnitOfWork unitOfWork)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<CuentaCorriente>();
        _unitOfWork = unitOfWork;
    }

    public IEnumerable<CuentaCorriente> GetList()
    {
        return _dbSet!.ToList();
    }

    public CuentaCorriente GetById(int value)
    {
        throw new NotImplementedException();
    }

    public CuentaCorriente GetByUUID(Guid value)
    {
        throw new NotImplementedException();
    }

    public Task<int> Add(CuentaCorriente entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<int> Delete(int value, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<int> Update(CuentaCorriente entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
