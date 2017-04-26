using System.Data.Entity.ModelConfiguration;

namespace TabelaFipe.DAL.Configurations
{
    public class AnoModeloConfig : EntityTypeConfiguration<AnoModelo>
    {
        public AnoModeloConfig()
        {
            ToTable("AnoModelos");

            HasRequired(a => a.Modelo)
                .WithMany(m => m.AnosModelos)
                .HasForeignKey(x => x.Modelo_Id);
        }
    }
}
