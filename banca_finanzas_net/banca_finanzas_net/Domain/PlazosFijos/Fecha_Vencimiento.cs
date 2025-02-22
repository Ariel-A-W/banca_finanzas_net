namespace banca_finanzas_net.Domain.PlazosFijos;

public record Fecha_Vencimiento(
    int Value    
)
{
    public DateTime GetFechaVencimiento() => DateTime.Now.AddDays(Value);
}