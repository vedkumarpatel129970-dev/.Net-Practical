using Microsoft.EntityFrameworkCore;
using practical11.Models;

namespace practical11.Data;

public class CampusDbContext(DbContextOptions<CampusDbContext> options) : DbContext(options)
{
    public DbSet<ServiceRequest> ServiceRequests => Set<ServiceRequest>();
    public DbSet<CampusEvent> CampusEvents => Set<CampusEvent>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ServiceRequest>(entity =>
        {
            entity.ToTable("ServiceRequests");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.StudentName).HasMaxLength(70).IsRequired();
            entity.Property(e => e.Department).HasMaxLength(60).IsRequired();
            entity.Property(e => e.Issue).HasMaxLength(80).IsRequired();
            entity.Property(e => e.Description).HasMaxLength(500).IsRequired();
            entity.Property(e => e.Status).HasMaxLength(50).IsRequired();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime2").IsRequired();
        });

        modelBuilder.Entity<CampusEvent>(entity =>
        {
            entity.ToTable("CampusEvents");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Title).HasMaxLength(100).IsRequired();
            entity.Property(e => e.Location).HasMaxLength(150).IsRequired();
            entity.Property(e => e.EventDate).HasColumnType("datetime2").IsRequired();
            entity.Property(e => e.Description).HasMaxLength(500).IsRequired();
        });
    }
}
