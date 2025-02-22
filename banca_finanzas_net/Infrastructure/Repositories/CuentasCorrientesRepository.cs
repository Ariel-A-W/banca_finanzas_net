using banca_finanzas_net.Domain.Abstractions;
using banca_finanzas_net.Domain.CuentasCorrientes;
using banca_finanzas_net.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace banca_finanzas_net.Infrastructure.Repositories;

public class CuentasCorrientesRepository : ICRUD<CuentaCorriente>, ICuentaCorriente
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

    public IEnumerable<CuentaCorriente> GetClienteMovsByID(int clienteId)
    {
        return _dbSet!.ToList().Where(x => x.Cliente_Id == clienteId);
    }

    public CuentaCorriente GetById(int value)
    {
        return _dbSet.SingleOrDefault(x => x.Cuenta_Corriente_Id == value)!;
    }

    public CuentaCorriente GetByUUID(Guid value)
    {
        return _dbSet.SingleOrDefault(x => x.Cuenta_Corriente_UUID == value)!;
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
