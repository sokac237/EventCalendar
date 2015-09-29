namespace EventCalendar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventMjestoVrsta : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VrstaId = c.Int(nullable: false),
                        Datum = c.DateTime(nullable: false),
                        Napomena = c.String(maxLength: 100),
                        MjestoId = c.Int(nullable: false),
                        Cijena = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Mjestoes", t => t.MjestoId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Vrstas", t => t.VrstaId, cascadeDelete: true)
                .Index(t => t.VrstaId)
                .Index(t => t.MjestoId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.Mjestoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vrstas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "VrstaId", "dbo.Vrstas");
            DropForeignKey("dbo.Events", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Events", "MjestoId", "dbo.Mjestoes");
            DropIndex("dbo.Events", new[] { "ApplicationUserId" });
            DropIndex("dbo.Events", new[] { "MjestoId" });
            DropIndex("dbo.Events", new[] { "VrstaId" });
            DropTable("dbo.Vrstas");
            DropTable("dbo.Mjestoes");
            DropTable("dbo.Events");
        }
    }
}
