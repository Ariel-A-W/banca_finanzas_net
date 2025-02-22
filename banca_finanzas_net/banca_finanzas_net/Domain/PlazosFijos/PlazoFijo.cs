using banca_finanzas_net.Domain.Clientes;

namespace banca_finanzas_net.Domain.PlazosFijos;

public class PlazoFijo 
{ 
    public int Plazofijo_Id { get; set; }
    public Guid Plazofijo_UUID { get; set; }
    public string? Nrocuenta { get; set; }
    public int Cliente_Id { get; set; }
    public decimal Monto { get; set; }
    public Plazo? Plazo { get; set; }
    public decimal Interes { get; set; }
    public Capital? Capital { get; set; }
    public DateTime Fecha_Inicio { get; set; }
    public Fecha_Vencimiento? Fecha_Vencimiento { get; set; }
    public int Active { get; set; }

    public ICollection<Cliente>? Clientes { get; set; }
}