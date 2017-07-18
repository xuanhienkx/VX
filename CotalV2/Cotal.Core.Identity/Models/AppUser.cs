using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Cotal.Core.Identity.Models
{
    // Add profile data for application users by adding properties to the AppUser class
    public class AppUser : IdentityUser<int>
    {
        [MaxLength(256)]
        public string FullName { set; get; }

        [MaxLength(256)]
        public string Address { set; get; }

        public string Avatar { get; set; }

        public DateTime? BirthDay { set; get; }

        public bool? Status { get; set; }

        public bool? Gender { get; set; }

        [MaxLength(10)] 
        public string AppCode { get; set; } = "COTAL";



    }

    [Table("AppRoles")]
    public class AppRole : IdentityRole<int>
    {
        public AppRole() : base()
        {

        }


        public AppRole(string name, string description) : base(name)
        {
            this.Description = description; 
        }
        public virtual string Description { get; set; }

        [MaxLength(10)]
        public string AppCode { get; set; } = "COTAL";

    }

    public class Application
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(10)]
        public string AppCode { get; set; }
        [MaxLength(300)]
        public string AppName { get; set; }
        public string Description { get; set; }
    }
}
