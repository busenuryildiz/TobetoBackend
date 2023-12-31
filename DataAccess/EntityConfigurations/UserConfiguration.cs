﻿using Entities.Concretes.Clients;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users").HasKey(u => u.Id); 
            builder.Property(u => u.FirstName).IsRequired().HasMaxLength(255);
            builder.Property(u => u.LastName).IsRequired().HasMaxLength(255);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(255);
            builder.Property(u => u.Password).IsRequired();
            builder.Property(u => u.NationalIdentity).IsRequired();
            builder.Property(u => u.BirthDate).IsRequired().HasColumnType("date");
            builder.Property(u => u.PhoneNumber).HasMaxLength(20);


            builder.HasMany(u => u.EducationInformations)
                .WithOne(ei => ei.User)
                .HasForeignKey(ei => ei.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.Addresses)
                .WithOne(ei => ei.User)
                .HasForeignKey(ei => ei.UserId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasMany(u => u.Certificates)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.SocialMediaAccounts)
                .WithOne(sma => sma.User)
                .HasForeignKey(sma => sma.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.UserExperiences)
                .WithOne(ue => ue.User)
                .HasForeignKey(ue => ue.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.UserLanguages)
                .WithOne(ue => ue.User)
                .HasForeignKey(ue => ue.UserId)
                .OnDelete(DeleteBehavior.Cascade);
                

            builder.HasQueryFilter(u => !u.DeletedDate.HasValue);
        }
    }

}
