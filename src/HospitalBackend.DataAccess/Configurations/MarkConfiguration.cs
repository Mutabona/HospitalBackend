using HospitalBackend.Domain.Marks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalBackend.DataAccess.Configurations;

public class MarkConfiguration : IEntityTypeConfiguration<Mark>
{
    public void Configure(EntityTypeBuilder<Mark> builder)
    {
        builder.ToTable("Marks");
        
        builder.HasKey(m => m.Id);
        
        builder
            .Property(x => x.IsDone)
            .IsRequired();
        
        builder
            .Property(x => x.UserId)
            .IsRequired();
        
        //Сюда триггер
        builder
            .Property(x => x.Date)
            .IsRequired();
    }
}