using CleanArchMVC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMVC.Infra.Data.EntitiesConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=> x.Name).HasMaxLength(100).IsRequired();

            builder.HasData(
            new { Id = 1, Name = "Material Escolar" },
            new { Id = 2, Name = "Eletrônicos" },
            new { Id = 3, Name = "Acessórios" }
        );

        }
    }
}
