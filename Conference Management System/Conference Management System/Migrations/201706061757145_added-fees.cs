namespace Conference_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedfees : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fees", "User_Id", "dbo.Users");
            DropIndex("dbo.Fees", new[] { "User_Id" });
            DropTable("dbo.Fees");
        }
    }
}
