namespace FINAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dalloz : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Tasks", newName: "TaskModels");
            DropForeignKey("dbo.Tasks", "Task_Id", "dbo.Tasks");
            DropIndex("dbo.TaskModels", new[] { "Task_Id" });
            DropColumn("dbo.TaskModels", "Task_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TaskModels", "Task_Id", c => c.Int());
            CreateIndex("dbo.TaskModels", "Task_Id");
            AddForeignKey("dbo.Tasks", "Task_Id", "dbo.Tasks", "Id");
            RenameTable(name: "dbo.TaskModels", newName: "Tasks");
        }
    }
}
