using HospitalBackend.Domain.Histories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalBackend.DataAccess.Configurations;

public class HistoryConfiguration : IEntityTypeConfiguration<History>
{
    public void Configure(EntityTypeBuilder<History> builder)
    {
        builder.ToTable("Histories");
        
        builder.HasKey(x => x.Id);
        
        builder
            .Property(x => x.ArriveDate)
            .IsRequired();
        
        builder
            .Property(x => x.PatientId)
            .IsRequired();
        
        builder
            .Property(x => x.LifeAnamnesis)
            .IsRequired();
        
        builder
            .Property(x => x.DiseaseAnamnesis)
            .IsRequired();
        
        builder
            .Property(x => x.Complaints)
            .IsRequired();
        
        builder
            .HasMany(x => x.Analyzes)
            .WithOne(x => x.History)
            .HasForeignKey(x => x.HistoryId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder
            .HasMany(x => x.Examinations)
            .WithOne(x => x.History)
            .HasForeignKey(x => x.HistoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}