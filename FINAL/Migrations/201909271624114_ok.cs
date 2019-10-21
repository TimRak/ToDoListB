namespace FINAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ok : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "Type", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tasks", "Type");
        }
    }
}
