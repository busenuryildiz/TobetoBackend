﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concretes.Courses;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Context.EntityConfigurations
{
    public class ExamConfiguration: IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.ToTable("Exams").HasKey(b => b.Id);
            builder.Property(b => b.Id).HasColumnName("ExamId").IsRequired();
            builder.Property(b => b.Title).HasColumnName("Title").IsRequired();
            builder.Property(b => b.Description).HasColumnName("Description");
            builder.Property(b => b.ExamDuration).HasColumnName("ExamDuration");
            builder.Property(b => b.Point).HasColumnName("Point");

            builder.HasIndex(indexExpression: b => b.Title, name: "UK_Exams_Title").IsUnique();
            builder.HasMany(b => b.Questions);
            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}
