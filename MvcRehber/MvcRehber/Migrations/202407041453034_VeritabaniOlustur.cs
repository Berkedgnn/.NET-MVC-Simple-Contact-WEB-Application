namespace MvcRehber.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VeritabaniOlustur : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kisiler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                        Soyad = c.String(),
                        EvTelefon = c.String(),
                        CepTelefon = c.String(),
                        IsTelefon = c.String(),
                        EmailAdres = c.String(),
                        Adres = c.String(),
                        SehirId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sehirler", t => t.SehirId, cascadeDelete: true)
                .Index(t => t.SehirId);
            
            CreateTable(
                "dbo.Sehirler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SehirAdi = c.String(),
                        PlakaKodu = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Kisiler", "SehirId", "dbo.Sehirler");
            DropIndex("dbo.Kisiler", new[] { "SehirId" });
            DropTable("dbo.Sehirler");
            DropTable("dbo.Kisiler");
        }
    }
}
