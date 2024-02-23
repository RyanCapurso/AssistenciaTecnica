using AssistenciaTecnicaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AssistenciaTecnicaApi.Data;

public class AssistenciaContext :DbContext
{
    public AssistenciaContext(DbContextOptions<AssistenciaContext> opts) : base(opts)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
         modelBuilder.Entity<ClienteEndereco>()
            .HasKey(ce => new { ce.IdCliente, ce.IdEndereco });

        modelBuilder.Entity<ClienteEndereco>()
            .HasOne(ce => ce.Cliente)
            .WithMany(c => c.ClienteEndereco)
            .HasForeignKey(ce => ce.IdCliente)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ClienteEndereco>()
            .HasOne(ce => ce.Endereco)
            .WithMany(e => e.ClienteEndereco);

        modelBuilder.Entity<OrdemModel>()
            .HasOne(o => o.Responsavel)
            .WithMany(r => r.Ordens)
            .HasForeignKey(o => o.IdResponsavel);

        modelBuilder.Entity<OrdemModel>()
            .HasOne(o => o.Cliente)
            .WithMany(c => c.Ordens)
            .HasForeignKey(o => o.IdCliente);

        modelBuilder.Entity<OrdemModel>()
            .HasOne(o => o.Aparelho)
            .WithMany(a => a.Ordens)
            .HasForeignKey(o => o.IdAparelho);
            
            base.OnModelCreating(modelBuilder);
    }

        
    
    public DbSet<ClienteEndereco> ClientesEnderecos { get; set; }
    public DbSet<EnderecoModel> Enderecos { get; set; }
    public DbSet<ClienteModel> Clientes { get; set; }
    public DbSet<ResponsavelModel> Responsaveis { get; set; }
    public DbSet<AparelhoModel> Aparelhos { get; set; }
    public DbSet<OrdemModel> Ordens { get; set; }
    
}