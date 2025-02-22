using banca_finanzas_net.Domain.CuentasCorrientes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace banca_finanzas_net.Infrastructure.AdaptersModels;

public class CuentasCorrientesModels : IEntityTypeConfiguration<CuentaCorriente>
{
    public void Configure(EntityTypeBuilder<CuentaCorriente> builder)
    {
        builder.ToTable("CuentasCorrientes");

        builder
            .HasKey(k => k.Cuenta_Corriente_Id)
            .HasName("Cuenta_Corriente_Id");

        builder.Property(p => p.Cuenta_Corriente_UUID);
        builder.Property(p => p.Estado);
        builder.Property(p => p.Fecha_Emision);
        builder.Property(p => p.Fecha_Cobro);
        builder.Property(p => p.Debe);
        builder.Property(p => p.Haber);
        builder.Property(p => p.Saldo);
        builder.Property(p => p.Active);
    }
}
