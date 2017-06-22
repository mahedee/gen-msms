using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MSMS.Web.Models
{
    public class LookupVM
    {
        public int Id { get; set; }
        [Display(Name = "Lookup Name")]
        public string Name { get; set; }
        [Display(Name="Is Parent")]
        public bool IsParent { get; set; }
        public string Description { get; set; }

        [Display(Name = "Parent")]
        public int? ParentId { get; set; }
    }
}