using HospitalBackend.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalBackend.DataAccess.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        
        builder.HasKey(x => x.Id);
        
        builder
            .Property(x => x.Login)
            .IsRequired();
        
        builder
            .Property(x => x.Password)
            .IsRequired();
        
        builder
            .Property(x => x.FIO)
            .IsRequired();
        
        builder
            .Property(x => x.Telephone)
            .IsRequired();

        builder
            .Property(x => x.Role)
            .IsRequired()
            .HasConversion<int>();
        
        builder
            .HasMany(x => x.Histories)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId);
        
        builder
            .HasMany(x => x.Marks)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId);
        
        builder
            .HasMany(x => x.Examinations)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId);
    }
}