namespace Conference_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usersectionmtm : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Section_Id", "dbo.Sections");
            DropIndex("dbo.Users", new[] { "Section_Id1" });
            DropColumn("dbo.Users", "Section_Id");
            RenameColumn(table: "dbo.Users", name: "Section_Id1", newName: "Section_Id");
            CreateTable(
                "dbo.UserSections",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Section_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Section_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Sections", t => t.Section_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Section_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserSections", "Section_Id", "dbo.Sections");
            DropForeignKey("dbo.UserSections", "User_Id", "dbo.Users");
            DropIndex("dbo.UserSections", new[] { "Section_Id" });
            DropIndex("dbo.UserSections", new[] { "User_Id" });
            DropTable("dbo.UserSections");
            RenameColumn(table: "dbo.Users", name: "Section_Id", newName: "Section_Id1");
            AddColumn("dbo.Users", "Section_Id", c => c.Int());
            CreateIndex("dbo.Users", "Section_Id1");
            AddForeignKey("dbo.Users", "Section_Id", "dbo.Sections", "Id");
        }
    }
}
