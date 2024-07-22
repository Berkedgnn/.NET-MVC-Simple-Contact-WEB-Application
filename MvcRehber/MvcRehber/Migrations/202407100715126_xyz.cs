namespace MvcRehber.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class xyz : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TBLUserInfoes", "Username", c => c.String(nullable: false));
            AlterColumn("dbo.TBLUserInfoes", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TBLUserInfoes", "Password", c => c.String());
            AlterColumn("dbo.TBLUserInfoes", "Username", c => c.String());
        }
    }
}
