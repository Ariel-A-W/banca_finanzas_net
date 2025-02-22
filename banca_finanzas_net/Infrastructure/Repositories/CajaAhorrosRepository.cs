using banca_finanzas_net.Domain.Abstractions;
using banca_finanzas_net.Domain.CajaAhorros;
using banca_finanzas_net.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace banca_finanzas_net.Infrastructure.Repositories;

public class CajaAhorrosRepository : ICRUD<CajaAhorro>, ICajaAhorro
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

    public IEnumerable<CajaAhorro> GetClientesMovsByID(int clienteId)
    {
        return _dbSet!.ToList().Where(x => x.Cliente_Id == clienteId);
    }

    public CajaAhorro GetById(int value)
    {
        return _dbSet.SingleOrDefault(x => x.Caja_Ahorro_Id == value)!;
    }

    public CajaAhorro GetByUUID(Guid value)
    {
        return _dbSet.SingleOrDefault(x => x.Caja_Ahorro_UUID == value)!; 
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
