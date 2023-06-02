using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public UserMap()
        {            
        }

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(prop => prop.Username)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired();
        }
    }
}