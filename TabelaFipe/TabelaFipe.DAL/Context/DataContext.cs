namespace TabelaFipe.DAL.Context
{
    using Configurations;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new AnoModeloConfig());
            modelBuilder.Configurations.Add(new MarcaConfig());
            modelBuilder.Configurations.Add(new ModeloConfig());
        }

        public DbSet<AnoModelo> AnoModelos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
    }
}