using HospitalBackend.DataAccess.Configurations;
using Microsoft.EntityFrameworkCore;

namespace HospitalBackend.DataAccess;

/// <summary>
/// Контекст базы данных.
/// </summary>
public class ApplicationDbContext : DbContext
{
    /// <summary>
    /// Создаёт экземпляр <see cref="ApplicationDbContext"/>.
    /// </summary>
    /// <param name="options">Опции.</param>
    public ApplicationDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("uuid-ossp");
        
        modelBuilder.ApplyConfiguration(new AnalysisConfiguration());
        modelBuilder.ApplyConfiguration(new PatientConfiguration());
        modelBuilder.ApplyConfiguration(new AppointmentConfiguration());
        modelBuilder.ApplyConfiguration(new ExaminationConfiguration());
        modelBuilder.ApplyConfiguration(new HistoryConfiguration());
        modelBuilder.ApplyConfiguration(new MarkConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}