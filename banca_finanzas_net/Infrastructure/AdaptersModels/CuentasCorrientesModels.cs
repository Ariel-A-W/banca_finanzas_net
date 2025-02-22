using banca_finanzas_net.Domain.CuentasCorrientes;
using banca_finanzas_net.Infrastructure.AdaptersModels.Abstrractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace banca_finanzas_net.Infrastructure.AdaptersModels;

public class CuentasCorrientesModels : IEntityTypeConfiguration<CuentaCorriente>
{
    public void Configure(EntityTypeBuilder<CuentaCorriente> builder)
    {
        builder.ToTable("cuentascorrientes");

        builder
            .HasKey(k => k.Cuenta_Corriente_Id)
            .HasName("cuenta_corriente_id");

        builder.Property(p => p.Cuenta_Corriente_UUID);
        builder.Property(p => p.Cliente_Id);
        builder.Property(p => p.Estado);
        builder.Property(p => p.Fecha_Emision);
        builder.Property(p => p.Fecha_Cobro);
        builder.Property(p => p.Debe);
        builder.Property(p => p.Haber);

        builder
            .Property(p => p.Saldo!)
            .HasConversion(
                v => $"{v.Debe}|{v.Haber}",
                o => StandardConversions.ConvertToSaldo(o)
            );

        builder.Property(p => p.Active);
    }
}
