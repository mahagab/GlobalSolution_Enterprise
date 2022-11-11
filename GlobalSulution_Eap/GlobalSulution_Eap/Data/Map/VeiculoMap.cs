using GlobalSulution_Eap.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GlobalSulution_Eap.Data.Map
{
    public class VeiculoMap : IEntityTypeConfiguration<VeiculoModel>
    {
        public void Configure(EntityTypeBuilder<VeiculoModel> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Tipo).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Status).IsRequired();


        }
    }
}
