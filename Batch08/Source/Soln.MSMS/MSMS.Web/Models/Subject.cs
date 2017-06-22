using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MSMS.Web.Models
{
    public class Subject
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
                
        public int ClassId { get; set; }        
        [ForeignKey("ClassId")]
        //[Display(Name = "Class Name")]
        public virtual ClassInfo ClassInfo {get; set;}

        [Display(Name ="Subject Code")]
        public string SubjectCode { get; set; }

        [Display(Name = "Subject Name")]
        public string SubjectName { get; set; }
    }
}