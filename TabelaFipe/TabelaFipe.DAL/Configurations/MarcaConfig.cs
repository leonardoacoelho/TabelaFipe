using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabelaFipe.DAL.Configurations
{
    public class MarcaConfig : EntityTypeConfiguration<Marca>
    {
        public MarcaConfig()
        {
            ToTable("Marcas");
        }
    }
}
