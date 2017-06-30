namespace frameQuest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sessione : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sessiones",
                c => new
                    {
                        IdSessione = c.Int(nullable: false, identity: true),
                        Nominativo = c.String(),
                        Punteggio = c.Int(nullable: false),
                        IdTest = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdSessione)
                .ForeignKey("dbo.Tests", t => t.IdTest, cascadeDelete: true)
                .Index(t => t.IdTest);
            
            CreateTable(
                "dbo.SessioneRispostas",
                c => new
                    {
                        IdSessioneRisposta = c.Int(nullable: false, identity: true),
                        IdSessione = c.Int(nullable: false),
                        IdDomanda = c.Int(nullable: false),
                        IdRisposta = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdSessioneRisposta)
                .ForeignKey("dbo.Domandas", t => t.IdDomanda, cascadeDelete: true)
                .ForeignKey("dbo.Rispostas", t => t.IdRisposta, cascadeDelete: true)
                .Index(t => t.IdSessione)
                .Index(t => t.IdDomanda)
                .Index(t => t.IdRisposta);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sessiones", "IdTest", "dbo.Tests");
            DropForeignKey("dbo.SessioneRispostas", "IdSessione", "dbo.Sessiones");
            DropForeignKey("dbo.SessioneRispostas", "IdRisposta", "dbo.Rispostas");
            DropForeignKey("dbo.SessioneRispostas", "IdDomanda", "dbo.Domandas");
            DropIndex("dbo.SessioneRispostas", new[] { "IdRisposta" });
            DropIndex("dbo.SessioneRispostas", new[] { "IdDomanda" });
            DropIndex("dbo.SessioneRispostas", new[] { "IdSessione" });
            DropIndex("dbo.Sessiones", new[] { "IdTest" });
            DropTable("dbo.SessioneRispostas");
            DropTable("dbo.Sessiones");
        }
    }
}
