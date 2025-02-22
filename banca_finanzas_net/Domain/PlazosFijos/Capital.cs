namespace banca_finanzas_net.Domain.PlazosFijos;

public record Capital(
    decimal Monto, int Plazo, decimal Interes    
)
{
    // (Monto x TNA % x Cantidad de días)/(365 x 100).
    public decimal GetCapital() => (Monto * Interes * Plazo) / 365000; 
}