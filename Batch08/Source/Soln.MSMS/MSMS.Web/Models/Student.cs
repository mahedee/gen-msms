using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MSMS.Web.Models
{
    public class Student
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //[Display(Name = "Class")]
        public int ClassId { get; set; }
        [ForeignKey("ClassId")]
        public virtual ClassInfo ClassInfo { get; set; }


        [Display(Name = "Batch")]
        public string Batch { get; set; }

        [Display(Name = "Student Id")]
        [Required]
        public string StudentId { get; set; }


        [Display(Name = "Student Name")]
        [Required]
        public string StudentName { get; set; }


        [Display(Name = "Roll Number")]
        public int ClassRoll { get; set; }
      
        public int GroupId { get; set; }

        public int SectionId { get; set; }     

        [Display(Name = "Shift")]
        public int ShiftId { get; set; }

        [Display(Name = "Cell Number")]
        public string CellNumber { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "G.P.A(P.E.C)")]
        public double? PEC { get; set; }

        [Display(Name = "G.P.A(J.S.C)")]
        public double? JSC { get; set; }

        [Display(Name = "G.P.A(S.S.C)")]
        public double? SSC { get; set; }

        //[Display(Name = "Gender")]
        public char GenderId { get; set; }

        [Display(Name = "Admission Referance")]
        public int AdmissionReferanceId { get; set; }

        [Display(Name = "Referance Name")]
        public string ReferanceName { get; set; }

        [Display(Name = "Discount")]
        public double Discount { get; set; }      
    }
}