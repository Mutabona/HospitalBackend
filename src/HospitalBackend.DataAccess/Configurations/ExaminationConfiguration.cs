using HospitalBackend.Domain.Examinations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalBackend.DataAccess.Configurations;

public class ExaminationConfiguration : IEntityTypeConfiguration<Examination>
{
    public void Configure(EntityTypeBuilder<Examination> builder)
    {
        builder.ToTable("Examinations");
        
        builder.HasKey(x => x.Id);
        
        builder
            .Property(x => x.Date)
            .IsRequired();
        
        builder
            .Property(x => x.HistoryId)
            .IsRequired();
        
        builder
            .Property(x => x.UserId)
            .IsRequired();

        builder
            .HasMany(x => x.Appointments)
            .WithOne(x => x.Examination)
            .HasForeignKey(x => x.ExaminationId);
    }
}