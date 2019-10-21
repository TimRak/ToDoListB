namespace FINAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "Status", c => c.String(unicode: false));
            AddColumn("dbo.Tasks", "Votes", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tasks", "Votes");
            DropColumn("dbo.Tasks", "Status");
        }
    }
}
