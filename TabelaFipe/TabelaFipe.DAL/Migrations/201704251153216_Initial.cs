namespace TabelaFipe.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnoModelos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ano = c.Int(nullable: false),
                        Valor = c.Double(nullable: false),
                        Modelo_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Modelos", t => t.Modelo_Id, cascadeDelete: true)
                .Index(t => t.Modelo_Id);
            
            CreateTable(
                "dbo.Modelos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        Potencia = c.Int(nullable: false),
                        Combustivel = c.String(),
                        QuantPortas = c.Int(nullable: false),
                        Marca_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Marcas", t => t.Marca_Id, cascadeDelete: true)
                .Index(t => t.Marca_Id);
            
            CreateTable(
                "dbo.Marcas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AnoModelos", "Modelo_Id", "dbo.Modelos");
            DropForeignKey("dbo.Modelos", "Marca_Id", "dbo.Marcas");
            DropIndex("dbo.Modelos", new[] { "Marca_Id" });
            DropIndex("dbo.AnoModelos", new[] { "Modelo_Id" });
            DropTable("dbo.Marcas");
            DropTable("dbo.Modelos");
            DropTable("dbo.AnoModelos");
        }
    }
}
