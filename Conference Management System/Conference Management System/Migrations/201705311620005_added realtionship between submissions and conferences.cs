namespace Conference_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedrealtionshipbetweensubmissionsandconferences : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Submissions", "Conference_Id", c => c.Int());
            CreateIndex("dbo.Submissions", "Conference_Id");
            AddForeignKey("dbo.Submissions", "Conference_Id", "dbo.Conferences", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Submissions", "Conference_Id", "dbo.Conferences");
            DropIndex("dbo.Submissions", new[] { "Conference_Id" });
            DropColumn("dbo.Submissions", "Conference_Id");
        }
    }
}
