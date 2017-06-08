namespace Conference_Management_System.Models
{
    using System.Data.Entity;

    public class CMS : DbContext
    {
        // Your context has been configured to use a 'CMS' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Conference_Management_System.Models.CMS' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'CMS' 
        // connection string in the application configuration file.
        public CMS()
            : base("name=CMS")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Bid> Bids { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Conference> Conferences { get; set; }
        public virtual DbSet<Qualifier> Qualifiers { get; set; }
        public virtual DbSet<Recommendation> Recommendatons { get; set; }
        public virtual DbSet<Submission> Submissions { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<Fee> Fees { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}