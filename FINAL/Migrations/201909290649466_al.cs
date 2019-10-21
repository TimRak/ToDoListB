namespace FINAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class al : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tasks", "Votes", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tasks", "Votes", c => c.String(unicode: false));
        }
    }
}
