using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MSMS.Web.Models
{
    public class ClassInfo
    {
        public int Id { get; set; }

        [Display(Name = "Class Name")]
        [Required]
        [StringLength(100)]
        public String ClassName { get; set; }
    }
}