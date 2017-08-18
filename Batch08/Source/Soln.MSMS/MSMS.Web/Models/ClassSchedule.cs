using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSMS.Web.Models
{
    public class ClassSchedule
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public int ShiftId { get; set; }
        public int SectionId { get; set; }
        public int SubjectId { get; set; }
        public int TeacherId { get; set; }
        public int RoomId { get; set; }
        public int DayId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}