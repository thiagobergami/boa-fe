using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Clients> Clients { get; set; }
    public DbSet<Units> Units { get; set; }
    public DbSet<Condominiums> Condominiums { get; set; }

    public DbSet<Maintenances> Maintenances { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Units>()
            .HasOne(c => c.TenantClient)
            .WithMany(client => client.RentUnits)
            .HasForeignKey(c => c.TenantClientId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Units>()
            .HasOne(u => u.Condominium)
            .WithMany(c => c.Units)
            .HasForeignKey(u => u.CondominiumId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Maintenances>()
            .HasOne(main => main.Unity)
            .WithMany(unity => unity.Maintenances)
            .HasForeignKey(main => main.UnitID)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Properties>()
            .HasKey(p => new { p.ClientId, p.UnitId });

        modelBuilder.Entity<Properties>()
            .HasOne(property => property.Client)
            .WithMany(client => client.Properties)
            .HasForeignKey(property => property.ClientId);

        modelBuilder.Entity<Properties>()
            .HasOne(property => property.Unit)
            .WithMany(unit => unit.Properties)
            .HasForeignKey(property => property.UnitId);
    }
}
