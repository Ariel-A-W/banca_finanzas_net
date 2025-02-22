using banca_finanzas_net.Application.Abstractions;
using banca_finanzas_net.Domain.Abstractions;
using banca_finanzas_net.Domain.Clientes;

namespace banca_finanzas_net.Application.Clientes;

public class ClientesUseCase : ICRUDUsesCases
    <
        ClientesResponse,
        ClientesAddRequest,
        ClientesDeleteRequest,
        ClientesUpdateRequest
    >
{
    private readonly ICRUD<Cliente> _cliente;

    public ClientesUseCase(ICRUD<Cliente> cliente)
    {
        _cliente = cliente;
    }

    public IEnumerable<ClientesResponse> GetAll()
    {
        // programar de otro modo... no así
        return (IEnumerable<ClientesResponse>)_cliente.GetList();
    }

    public ClientesResponse GetByIb(int id)
    {
        throw new NotImplementedException();
    }

    public ClientesResponse GetByUUID(Guid guid)
    {
        throw new NotImplementedException();
    }

    public Task<int> Add(ClientesAddRequest entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<int> Delete(ClientesDeleteRequest entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<int> Update(ClientesUpdateRequest entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
