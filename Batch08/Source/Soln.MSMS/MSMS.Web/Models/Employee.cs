using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace MSMS.Web.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public int EmployeeTypeId { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string ShortName { get; set; }
        public string CellNumber { get; set; }
        public string AlternativeNumber { get; set; }
        public string Email { get; set; }
        public string LastQualification { get; set; }
        public string ExtraQualification { get; set; }
        public string ExperienceYear { get; set; }
        public int GenderId { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public DateTime JoiningDate { get; set; }
        public int ReferenceId { get; set; }
        public string ReferenceName { get; set; }
        public Url Image { get; set; }
        public Url Cv { get; set; }
    }
}