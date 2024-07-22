namespace MvcRehber.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class latestupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kisiler", "TBLUserInfo_Id", c => c.Int());
            CreateIndex("dbo.Kisiler", "TBLUserInfo_Id");
            AddForeignKey("dbo.Kisiler", "TBLUserInfo_Id", "dbo.TBLUserInfoes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Kisiler", "TBLUserInfo_Id", "dbo.TBLUserInfoes");
            DropIndex("dbo.Kisiler", new[] { "TBLUserInfo_Id" });
            DropColumn("dbo.Kisiler", "TBLUserInfo_Id");
        }
    }
}
