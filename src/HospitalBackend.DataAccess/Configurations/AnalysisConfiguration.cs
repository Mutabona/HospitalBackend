using HospitalBackend.Domain.Analyzes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalBackend.DataAccess.Configurations;

public class AnalysisConfiguration : IEntityTypeConfiguration<Analysis>
{
    public void Configure(EntityTypeBuilder<Analysis> builder)
    {
        builder.ToTable("Analyzes");
        
        builder.HasKey(x => x.Id);
        
        builder
            .Property(x => x.Type)
            .IsRequired();
        
        builder
            .Property(x => x.Date)
            .IsRequired();
        
        builder
            .Property(x => x.Result)
            .IsRequired();
        
        builder
            .Property(x => x.HistoryId)
            .IsRequired();

        builder
            .Property(x => x.AppointmentId);
    }
}