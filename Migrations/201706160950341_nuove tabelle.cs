namespace frameQuest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nuovetabelle : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Argomentoes",
                c => new
                    {
                        IdArgomento = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdArgomento);
            
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        IdClasse = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Materia = c.String(),
                        IdDocente = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdClasse)
                .ForeignKey("dbo.Docentes", t => t.IdDocente, cascadeDelete: true)
                .Index(t => t.IdDocente);
            
            CreateTable(
                "dbo.Docentes",
                c => new
                    {
                        IdDocente = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Cognome = c.String(nullable: false, maxLength: 100),
                        CodiceFiscale = c.String(maxLength: 16),
                        Indirizzo = c.String(),
                        Comune = c.String(),
                        Provincia = c.String(maxLength: 2),
                        Cap = c.String(maxLength: 5),
                        Telefono = c.String(),
                        Cellulare = c.String(),
                        Email = c.String(),
                        DataInserimento = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdDocente);
            
            CreateTable(
                "dbo.Fases",
                c => new
                    {
                        IdFase = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdFase);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        IdTest = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Descrizione = c.String(),
                        IdArgomento = c.Int(nullable: false),
                        IdFase = c.Int(nullable: false),
                        IdDocente = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdTest)
                .ForeignKey("dbo.Argomentoes", t => t.IdArgomento, cascadeDelete: true)
                .ForeignKey("dbo.Docentes", t => t.IdDocente, cascadeDelete: true)
                .ForeignKey("dbo.Fases", t => t.IdFase, cascadeDelete: true)
                .Index(t => t.IdArgomento)
                .Index(t => t.IdFase)
                .Index(t => t.IdDocente);
            
            AddColumn("dbo.Alunnoes", "Classe_IdClasse", c => c.Int());
            CreateIndex("dbo.Alunnoes", "Classe_IdClasse");
            AddForeignKey("dbo.Alunnoes", "Classe_IdClasse", "dbo.Classes", "IdClasse");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tests", "IdFase", "dbo.Fases");
            DropForeignKey("dbo.Tests", "IdDocente", "dbo.Docentes");
            DropForeignKey("dbo.Tests", "IdArgomento", "dbo.Argomentoes");
            DropForeignKey("dbo.Classes", "IdDocente", "dbo.Docentes");
            DropForeignKey("dbo.Alunnoes", "Classe_IdClasse", "dbo.Classes");
            DropIndex("dbo.Tests", new[] { "IdDocente" });
            DropIndex("dbo.Tests", new[] { "IdFase" });
            DropIndex("dbo.Tests", new[] { "IdArgomento" });
            DropIndex("dbo.Classes", new[] { "IdDocente" });
            DropIndex("dbo.Alunnoes", new[] { "Classe_IdClasse" });
            DropColumn("dbo.Alunnoes", "Classe_IdClasse");
            DropTable("dbo.Tests");
            DropTable("dbo.Fases");
            DropTable("dbo.Docentes");
            DropTable("dbo.Classes");
            DropTable("dbo.Argomentoes");
        }
    }
}
