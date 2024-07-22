namespace MvcRehber.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kisiler", "CurrentId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Kisiler", "CurrentId");
        }
    }
}
