namespace Conference_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class madefeeperconference : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Conferences", "AuthorFee", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Conferences", "ListenerFee", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Fees", "Conference_Id", c => c.Int());
            CreateIndex("dbo.Fees", "Conference_Id");
            AddForeignKey("dbo.Fees", "Conference_Id", "dbo.Conferences", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fees", "Conference_Id", "dbo.Conferences");
            DropIndex("dbo.Fees", new[] { "Conference_Id" });
            DropColumn("dbo.Fees", "Conference_Id");
            DropColumn("dbo.Conferences", "ListenerFee");
            DropColumn("dbo.Conferences", "AuthorFee");
        }
    }
}
