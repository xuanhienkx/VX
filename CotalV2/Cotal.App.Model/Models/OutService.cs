using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Cotal.App.Model.Abstract;

namespace Cotal.App.Model.Models
{
    public class OutService : Auditable
    {
        [Required]
        [MaxLength(256)]
        public string Name { set; get; }

        [Required]
        [MaxLength(256)]
        [Column(TypeName = "varchar(2000)")]
        public string Alias { set; get; } 

        [MaxLength(256)]
        public string Image { set; get; }

        [MaxLength(4000)]
        public string Description { set; get; }

        public string Content { set; get; }
        [MaxLength(100)]
        public string IconCss { get; set; } 
        public bool? HomeFlag { set; get; }
        public bool? HotFlag { set; get; }

    }
}