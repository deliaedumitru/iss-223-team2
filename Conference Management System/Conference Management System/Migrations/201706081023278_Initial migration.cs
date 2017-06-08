namespace Conference_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bids",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                        Reviewer_Id = c.Int(),
                        Submission_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Reviewer_Id)
                .ForeignKey("dbo.Submissions", t => t.Submission_Id)
                .Index(t => t.Reviewer_Id)
                .Index(t => t.Submission_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Role = c.Int(nullable: false),
                        Name = c.String(),
                        Email = c.String(),
                        Affiliation = c.String(),
                        Section_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sections", t => t.Section_Id)
                .Index(t => t.Section_Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Date = c.DateTime(nullable: false),
                        Reviewer_Id = c.Int(),
                        Submission_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Reviewer_Id)
                .ForeignKey("dbo.Submissions", t => t.Submission_Id)
                .Index(t => t.Reviewer_Id)
                .Index(t => t.Submission_Id);
            
            CreateTable(
                "dbo.Submissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Meta = c.String(),
                        Type = c.String(),
                        Status = c.Int(nullable: false),
                        Conference_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Conferences", t => t.Conference_Id)
                .Index(t => t.Conference_Id);
            
            CreateTable(
                "dbo.Conferences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.DateTime(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        SubmissionDeadline = c.DateTime(nullable: false),
                        Location = c.String(),
                        AuthorFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ListenerFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Qualifiers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                        Paper_Id = c.Int(),
                        Reviewer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Submissions", t => t.Paper_Id)
                .ForeignKey("dbo.Users", t => t.Reviewer_Id)
                .Index(t => t.Paper_Id)
                .Index(t => t.Reviewer_Id);
            
            CreateTable(
                "dbo.Recommendations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        ReviewerId = c.Int(nullable: false),
                        SubmissionId = c.Int(nullable: false),
                        Rewiever_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Rewiever_Id)
                .ForeignKey("dbo.Submissions", t => t.SubmissionId, cascadeDelete: true)
                .Index(t => t.SubmissionId)
                .Index(t => t.Rewiever_Id);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Room = c.String(),
                        SeatNumber = c.Int(nullable: false),
                        Conference_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Conferences", t => t.Conference_Id)
                .Index(t => t.Conference_Id);
            
            CreateTable(
                "dbo.Fees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Conference_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Conferences", t => t.Conference_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Conference_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.SubmissionUsers",
                c => new
                    {
                        Submission_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Submission_Id, t.User_Id })
                .ForeignKey("dbo.Submissions", t => t.Submission_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Submission_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.SubmissionUser1",
                c => new
                    {
                        Submission_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Submission_Id, t.User_Id })
                .ForeignKey("dbo.Submissions", t => t.Submission_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Submission_Id)
                .Index(t => t.User_Id);
            
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
            DropForeignKey("dbo.Fees", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Fees", "Conference_Id", "dbo.Conferences");
            DropForeignKey("dbo.UserSections", "Section_Id", "dbo.Sections");
            DropForeignKey("dbo.UserSections", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "Section_Id", "dbo.Sections");
            DropForeignKey("dbo.Sections", "Conference_Id", "dbo.Conferences");
            DropForeignKey("dbo.SubmissionUser1", "User_Id", "dbo.Users");
            DropForeignKey("dbo.SubmissionUser1", "Submission_Id", "dbo.Submissions");
            DropForeignKey("dbo.Recommendations", "SubmissionId", "dbo.Submissions");
            DropForeignKey("dbo.Recommendations", "Rewiever_Id", "dbo.Users");
            DropForeignKey("dbo.Qualifiers", "Reviewer_Id", "dbo.Users");
            DropForeignKey("dbo.Qualifiers", "Paper_Id", "dbo.Submissions");
            DropForeignKey("dbo.Submissions", "Conference_Id", "dbo.Conferences");
            DropForeignKey("dbo.Comments", "Submission_Id", "dbo.Submissions");
            DropForeignKey("dbo.Bids", "Submission_Id", "dbo.Submissions");
            DropForeignKey("dbo.SubmissionUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.SubmissionUsers", "Submission_Id", "dbo.Submissions");
            DropForeignKey("dbo.Comments", "Reviewer_Id", "dbo.Users");
            DropForeignKey("dbo.Bids", "Reviewer_Id", "dbo.Users");
            DropIndex("dbo.UserSections", new[] { "Section_Id" });
            DropIndex("dbo.UserSections", new[] { "User_Id" });
            DropIndex("dbo.SubmissionUser1", new[] { "User_Id" });
            DropIndex("dbo.SubmissionUser1", new[] { "Submission_Id" });
            DropIndex("dbo.SubmissionUsers", new[] { "User_Id" });
            DropIndex("dbo.SubmissionUsers", new[] { "Submission_Id" });
            DropIndex("dbo.Fees", new[] { "User_Id" });
            DropIndex("dbo.Fees", new[] { "Conference_Id" });
            DropIndex("dbo.Sections", new[] { "Conference_Id" });
            DropIndex("dbo.Recommendations", new[] { "Rewiever_Id" });
            DropIndex("dbo.Recommendations", new[] { "SubmissionId" });
            DropIndex("dbo.Qualifiers", new[] { "Reviewer_Id" });
            DropIndex("dbo.Qualifiers", new[] { "Paper_Id" });
            DropIndex("dbo.Submissions", new[] { "Conference_Id" });
            DropIndex("dbo.Comments", new[] { "Submission_Id" });
            DropIndex("dbo.Comments", new[] { "Reviewer_Id" });
            DropIndex("dbo.Users", new[] { "Section_Id" });
            DropIndex("dbo.Bids", new[] { "Submission_Id" });
            DropIndex("dbo.Bids", new[] { "Reviewer_Id" });
            DropTable("dbo.UserSections");
            DropTable("dbo.SubmissionUser1");
            DropTable("dbo.SubmissionUsers");
            DropTable("dbo.Fees");
            DropTable("dbo.Sections");
            DropTable("dbo.Recommendations");
            DropTable("dbo.Qualifiers");
            DropTable("dbo.Conferences");
            DropTable("dbo.Submissions");
            DropTable("dbo.Comments");
            DropTable("dbo.Users");
            DropTable("dbo.Bids");
        }
    }
}
