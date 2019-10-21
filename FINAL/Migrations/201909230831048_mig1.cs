namespace FINAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User = c.String(unicode: false),
                        Title = c.String(unicode: false),
                        Date = c.DateTime(nullable: false, precision: 0),
                        Description = c.String(unicode: false),
                        Task_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tasks", t => t.Task_Id)
                .Index(t => t.Task_Id);
            
            CreateTable(
                "dbo.Utilisateurs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, unicode: false),
                        MotDePasse = c.String(nullable: false, unicode: false),
                        ConfirmMotDePasse = c.String(unicode: false),
                        Email = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "Task_Id", "dbo.Tasks");
            DropIndex("dbo.Tasks", new[] { "Task_Id" });
            DropTable("dbo.Utilisateurs");
            DropTable("dbo.Tasks");
        }
    }
}
