using System.Data.Entity.ModelConfiguration;

namespace TabelaFipe.DAL.Configurations
{
    public class ModeloConfig : EntityTypeConfiguration<Modelo>
    {
        public ModeloConfig()
        {
            ToTable("Modelos");

            HasRequired(mod => mod.Marca)
                .WithMany(m => m.Modelos)
                .HasForeignKey(x => x.Marca_Id);
        }
    }
}
