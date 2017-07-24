using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Cotal.App.Model.Models;
using Cotal.Core.Common.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cotal.App.Business.ViewModels.System
{
    public class FunctionViewModel
    {
        public string Id { set; get; }

        [Required]
        [MaxLength(50)]
        public string Name { set; get; }

        [Required]
        [MaxLength(256)]
        public string URL { set; get; }

        public int DisplayOrder { set; get; }

        public string ParentId { set; get; }

        public FunctionViewModel Parent { set; get; }

        public ICollection<FunctionViewModel> ChildFunctions { set; get; }


        public bool Status { set; get; }

        public string IconCss { get; set; }
        public FunctionType FunctionType { get; set; }
        public string FunctionTypeName { get; set; }
    }
}