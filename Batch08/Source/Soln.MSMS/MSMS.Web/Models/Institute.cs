using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MSMS.Web.Models
{
    public class Institute
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Institution Name")]
        [Required]
        [StringLength(500)]
        public string InstituteName { get; set; }

        [StringLength(500)]
        public string Slogan { get; set; }

        public string Address { get; set; }

        [Display(Name = "Institution Code")]
        [Required]
        [StringLength(100)]
        public string InstituteCode { get; set; }

        [Display(Name = "Year of Establishment")]
        public int EstablishedYear { get; set; }
    }
}