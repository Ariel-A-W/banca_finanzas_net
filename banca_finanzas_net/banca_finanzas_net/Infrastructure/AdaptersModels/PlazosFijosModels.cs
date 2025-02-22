using banca_finanzas_net.Domain.PlazosFijos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace banca_finanzas_net.Infrastructure.AdaptersModels;

public class PlazosFijosModels : IEntityTypeConfiguration<PlazoFijo>
{
    public void Configure(EntityTypeBuilder<PlazoFijo> builder)
    {
        builder.ToTable("PlazosFijos");

        builder
            .HasKey(k => k.Plazofijo_Id)
            .HasName("Plazofijo_Id");

        builder.Property(p => p.Plazofijo_UUID);
        builder.Property(p => p.Nrocuenta);
        builder.Property(p => p.Cliente_Id);
        builder.Property(p => p.Monto);
        
        builder.Property(p => p.Plazo)
            .HasConversion(v => v!.Value, v => new Plazo(v));
        
        builder.Property(p => p.Interes);
        
        builder
            .Property(p => p.Capital)
            .HasConversion(                                
                v => new Capital(v!.Monto, v!.Plazo, v!.Interes),
                v => new Capital(v.Monto, v.Plazo, v.Interes)
                //v => $"{v!.Monto};{v!.Plazo};{v!.Interes}",
                //v => 
                //{
                //    var valores = v.Split(';');
                //    return new Capital(
                //        decimal.Parse(valores[0]),
                //        int.Parse(valores[1]),
                //        decimal.Parse(valores[2])
                //    );
                //}
            );

        builder.Property(p => p.Fecha_Inicio);

        builder
            .Property(p => p.Fecha_Vencimiento)
            .HasConversion(v => v!.Value, v => new Fecha_Vencimiento(v));        
        
        builder.Property(p => p.Active);
    }
}
