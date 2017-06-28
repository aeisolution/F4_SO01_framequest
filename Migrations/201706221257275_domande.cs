namespace frameQuest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class domande : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Domandas",
                c => new
                    {
                        IdDomanda = c.Int(nullable: false, identity: true),
                        IdTest = c.Int(nullable: false),
                        Testo = c.String(nullable: false),
                        Punti = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdDomanda)
                .ForeignKey("dbo.Tests", t => t.IdTest, cascadeDelete: true)
                .Index(t => t.IdTest);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Domandas", "IdTest", "dbo.Tests");
            DropIndex("dbo.Domandas", new[] { "IdTest" });
            DropTable("dbo.Domandas");
        }
    }
}
