using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using UserRegistrationAndGameLibrary.Domain.Entities;

namespace UserRegistrationAndGameLibrary.Infra.Configuration;
public class UserAuthorizationConfiguration : IEntityTypeConfiguration<UserAuthorization>
{
    public void Configure(EntityTypeBuilder<UserAuthorization> builder)
    {
        builder.ToTable("userAuthorizations");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        builder.HasOne(ua => ua.User)
            .WithOne(u => u.Authorization)
            .HasForeignKey<UserAuthorization>(ua => ua.UserId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder.Property(u => u.Permission)
           .HasColumnName("permission")
           .HasConversion<string>()
           .IsRequired();
    }
}
