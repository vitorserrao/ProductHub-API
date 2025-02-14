using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductHub_API.Models;

public class UsersMap : IEntityTypeConfiguration<UsersModel>
{
    public void Configure(EntityTypeBuilder<UsersModel> builder)
    {
        builder.ToTable("Users"); 

        builder.HasKey(x => x.Id); 

        builder.Property(x => x.UserName)
            .IsRequired()
            .HasMaxLength(100); 

        builder.Property(x => x.PasswordHash)
            .IsRequired()
            .HasMaxLength(255); 
    }
}
