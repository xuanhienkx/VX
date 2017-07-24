using System;
using System.ComponentModel.DataAnnotations;

namespace Cotal.App.Business.ViewModels.Common
{
    public class OutServiceModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên không được trống")]
        public string Name { set; get; }

        public string Alias { set; get; }
        public string Image { set; get; }
        public string Description { set; get; }

        public string Content { set; get; }
        public string IconCss { get; set; }
        public bool Status { get; set; }
        public bool? HomeFlag { set; get; }
        public bool? HotFlag { set; get; }

        public DateTime? CreatedDate { set; get; }

        public string CreatedBy { set; get; }

        public DateTime? UpdatedDate { set; get; }

        public string UpdatedBy { set; get; }

        public string MetaKeyword { set; get; }

        public string MetaDescription { set; get; }

    }
}