﻿using RepositoryPatternWithUOW.Core.Enums;
namespace RepositoryPatternWithUOW.Core.Models
{
    public class Attendance
    {
        public int Id { get; set; }

        public AttendanceStatus Status { get; set; }

        public DayOfWeek AttendanceDay { get; set; }

        public DateOnly Date { get; set; }

        public TimeOnly ArrivingTime { get; set; }

        public TimeOnly LeavingTime { get; set; }

        public int OverTimeHours { get; set; }

        public int LateTimeHours { get; set; }

        public int? EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

    }
}
