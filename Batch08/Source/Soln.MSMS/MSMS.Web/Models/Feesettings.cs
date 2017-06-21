using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MSMS.Web.Models
{
    public class FeeSettings
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        public int ClassId { get; set; }
        [ForeignKey("ClassId")]
        public virtual ClassInfo ClassInfo { get; set; }


        [Display(Name = "Monthly Fee")]
        [Required]
        public double MonthlyFee { get; set; }

        [Display(Name = "Effective Date")]
        public DateTime EffectiveDate { get; set; }
    }
}