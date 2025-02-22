namespace banca_finanzas_net.Domain.CajaAhorros;

public interface ICajaAhorro
{
    public IEnumerable<CajaAhorro> GetClientesMovsByID(int clienteId);
}
