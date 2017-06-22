using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MSMS.Web.Models
{
    public class Guardian
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name ="Father's Name")]
        public string FatherName { get; set; }
        public int FatherOccupationId { get; set; }

        [Display(Name = "Father's Cell")]
        public string FatherCell { get; set; }

        [Display(Name = "Father's E-Mail")]
        public string FatherEmail { get; set; }

        [Display(Name = "Mother's Name")]
        public string MotherName { get; set; }
        public int MotherOccupationId { get; set; }

        [Display(Name = "Mother's Cell")]
        public string MotherCell { get; set; }

        [Display(Name = "Mother's E-Mail")]
        public string MotherEmail { get; set; }

        [Display(Name = "Guardian's Name")]
        public string GuardianName { get; set; }
        public int GuardianOccupationId { get; set; }

        [Display(Name = "Guardian's Cell")]
        public string GuardianCell { get; set; }

        [Display(Name = "Guardian's E-Mail")]
        public string GuardianEmail { get; set; }

        public string GuardianRelationId { get; set; }

        [Display(Name = "Present Address")]
        public string PresentAddress { get; set; }

        [Display(Name = "Present Address")]
        public string permanentAddress { get; set; }

    }
}