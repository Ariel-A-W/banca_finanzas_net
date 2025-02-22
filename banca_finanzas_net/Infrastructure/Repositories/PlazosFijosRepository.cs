using banca_finanzas_net.Domain.Abstractions;
using banca_finanzas_net.Domain.PlazosFijos;
using banca_finanzas_net.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace banca_finanzas_net.Infrastructure.Repositories;

public class PlazosFijosRepository : ICRUD<PlazoFijo>
{
    private readonly AppDBContext _dbContext;
    private readonly IUnitOfWork _unitOfWork;
    private readonly DbSet<PlazoFijo> _dbSet;

    public PlazosFijosRepository(AppDBContext dbContext, IUnitOfWork unitOfWork)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<PlazoFijo>();
        _unitOfWork = unitOfWork;
    }

    public IEnumerable<PlazoFijo> GetList()
    {
        return _dbSet.ToList();
    }

    public PlazoFijo GetById(int value)
    {
        throw new NotImplementedException();
    }

    public PlazoFijo GetByUUID(Guid value)
    {
        throw new NotImplementedException();
    }

    public Task<int> Add(PlazoFijo entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<int> Delete(int value, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<int> Update(PlazoFijo entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
