using HospitalBackend.Domain.Patients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalBackend.DataAccess.Configurations;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder
            .ToTable("Patients");
        
        builder
            .HasKey(x => x.Id);
        
        builder
            .Property(x => x.FIO)
            .IsRequired();
        
        builder
            .Property(x => x.Telephone)
            .IsRequired();
        
        builder
            .Property(x => x.Passport)
            .IsRequired();
        
        builder
            .Property(x => x.BirthDate)
            .IsRequired();
        
        builder
            .Property(x => x.Address)
            .IsRequired();
        
        builder
            .HasMany(x => x.Histories)
            .WithOne(x => x.Patient)
            .HasForeignKey(x => x.PatientId);
    }
}