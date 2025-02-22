using banca_finanzas_net.Application.Clientes;

namespace banca_finanzas_net.Application.PlazosFijos;

public class PlazosFijosResponse
{
    public Guid Plazofijo_UUID { get; set; }
    public string? Nrocuenta { get; set; }
    public int Cliente_Id { get; set; }
    public decimal Monto { get; set; }
    public int Plazo { get; set; }
    public decimal Capital { get; set; }
    public DateTime Fecha_Inicio { get; set; }
    public DateTime Fecha_Vencimiento { get; set; }
    public int Active { get; set; }

    public ClientesResponse? Clientes { get; set; }
}
