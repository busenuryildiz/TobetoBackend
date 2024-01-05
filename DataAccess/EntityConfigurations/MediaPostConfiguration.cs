using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Context.EntityConfigurations
{
    public class MediaPostConfiguration: IEntityTypeConfiguration<MediaPost>
    {
        public void Configure(EntityTypeBuilder<MediaPost> builder)
        {
            builder.ToTable("MediaPosts").HasKey(b => b.Id);
            builder.Property(b => b.Id).HasColumnName("MediaPostId").IsRequired();
            builder.Property(b => b.Title).HasColumnName("Title").IsRequired();
            builder.Property(b => b.Description).HasColumnName("Description");
            builder.Property(b => b.Content).HasColumnName("Content");
            builder.Property(b => b.ImagePath).HasColumnName("ImagePath");
            builder.Property(b => b.Date).HasColumnName("Date");

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);

   

    }
}
}
