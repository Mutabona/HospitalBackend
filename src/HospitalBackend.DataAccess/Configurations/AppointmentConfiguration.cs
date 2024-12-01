using HospitalBackend.Domain.Analyzes;
using HospitalBackend.Domain.Appointments;
using HospitalBackend.Domain.Marks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalBackend.DataAccess.Configurations;

public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.ToTable("Appointments");
        
        builder.HasKey(x => x.Id);
        
        builder
            .Property(x => x.Content)
            .IsRequired();
        
        builder
            .Property(x => x.ExaminationId)
            .IsRequired();

        builder
            .HasOne(x => x.Analysis)
            .WithOne(x => x.Appointment)
            .HasForeignKey<Analysis>(x => x.AppointmentId);
        
        builder
            .HasOne(x => x.Mark)
            .WithOne(x => x.Appointment)
            .HasForeignKey<Mark>(x => x.AppointmentId);
        
        builder
            .Property(x => x.Date)
            .IsRequired();
    }
}