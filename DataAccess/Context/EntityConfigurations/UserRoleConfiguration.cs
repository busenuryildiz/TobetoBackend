using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context.EntityConfigurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRoles");

            builder.HasKey(ur => ur.Id);

            // Diğer konfigürasyonları ekleyin

            // UserRole ve User arasındaki ilişki
            builder.HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();

            // UserRole ve Role arasındaki ilişki
            builder.HasOne(ur => ur.Role)
                .WithMany() // .WithMany() içerisine koleksiyon belirtilmez
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();
        }
    }



}
