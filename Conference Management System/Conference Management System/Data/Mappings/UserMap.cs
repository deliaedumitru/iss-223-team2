using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using Conference_Management_System.Models;
using System.Data.Entity.Infrastructure.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Conference_Management_System.Data.Mappings
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("Users");
            HasKey(m => m.Id);
            Property(m => m.Username)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(
                    new IndexAttribute("IX_Username", 1) { IsUnique = true }));
            Property(m => m.Password).IsRequired();
            Property(m => m.Name).IsRequired();
            Property(m => m.Email).IsRequired();
            Property(m => m.Affiliation);
            Property(m => m.Role).IsRequired();


            
        }
    }
}