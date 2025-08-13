using BookStore.Core.Models;
using BookStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.DataAccess.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<BookEntity>
    {
        public void Configure(EntityTypeBuilder<BookEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title)
                .IsRequired().HasMaxLength(Book.Max_Length_Title);
            builder.Property(x => x.Author).IsRequired().HasMaxLength(Book.Max_Length_Author);
            builder.Property(x => x.Description).HasMaxLength(Book.Max_Length_Description);  
            builder.Property(x => x.CreatAt).IsRequired();

        }
    }
}
