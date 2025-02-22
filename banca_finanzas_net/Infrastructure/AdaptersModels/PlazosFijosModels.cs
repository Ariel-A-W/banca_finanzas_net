using banca_finanzas_net.Domain.PlazosFijos;
using banca_finanzas_net.Infrastructure.AdaptersModels.Abstrractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace banca_finanzas_net.Infrastructure.AdaptersModels;

public class PlazosFijosModels : IEntityTypeConfiguration<PlazoFijo>
{
    public void Configure(EntityTypeBuilder<PlazoFijo> builder)
    {
        builder.ToTable("plazosfijos");

        builder
            .HasKey(k => k.Plazofijo_Id)
            .HasName("plazofijo_id");

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
               v => $"{v.Monto}|{v.Plazo}|{v.Interes}", 
               o => StandardConversions.ConvertToCapital(o)
            );

        builder.Property(p => p.Fecha_Inicio);

        builder
            .Property(p => p.Fecha_Vencimiento)
            .HasConversion(v => v!.Value, v => new Fecha_Vencimiento(v));        
        
        builder.Property(p => p.Active);
    }
}
