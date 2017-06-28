namespace frameQuest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class risposte : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rispostas",
                c => new
                    {
                        IdRisposta = c.Int(nullable: false, identity: true),
                        Testo = c.String(nullable: false),
                        Esatta = c.Boolean(nullable: false),
                        Domanda_IdDomanda = c.Int(),
                    })
                .PrimaryKey(t => t.IdRisposta)
                .ForeignKey("dbo.Domandas", t => t.Domanda_IdDomanda)
                .Index(t => t.Domanda_IdDomanda);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rispostas", "Domanda_IdDomanda", "dbo.Domandas");
            DropIndex("dbo.Rispostas", new[] { "Domanda_IdDomanda" });
            DropTable("dbo.Rispostas");
        }
    }
}
