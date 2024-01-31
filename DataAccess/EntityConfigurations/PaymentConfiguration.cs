using Entities.Concretes.CoursesFolder;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payments").HasKey(p => p.Id); 

            builder.Property(p => p.StudentCourseId)
                .IsRequired()
                .HasColumnName("StudentCourseId");

            builder.Property(p => p.Amount)
                .IsRequired()
                .HasColumnName("Amount");

            builder.Property(p => p.PaymentDate)
                .IsRequired()
                .HasColumnName("PaymentDate"); 

            builder.Property(p => p.Status)
                .HasColumnName("Status"); 

            builder.HasOne(p => p.StudentCourse)
                .WithMany(sc => sc.Payments)
                .HasForeignKey(p => p.StudentCourseId);

            builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
        }
    }

}
