using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductHub_API.Models;


public class ProductsMap : IEntityTypeConfiguration<ProductsModel>
{
    public void Configure(EntityTypeBuilder<ProductsModel> builder)
    {
        builder.ToTable("Products"); 

        builder.HasKey(x => x.Id); 

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(200); 

        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(500); 

        builder.Property(x => x.Price)
            .IsRequired()
            .HasColumnType("decimal(18,2)"); 
    }
}
