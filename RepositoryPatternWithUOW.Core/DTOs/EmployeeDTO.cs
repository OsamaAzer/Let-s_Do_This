﻿
using RepositoryPatternWithUOW.Core.Enums;

namespace RepositoryPatternWithUOW.Core.DTOs
{
    public class EmployeeDTO
    {
        public string FullName { get; set; }

        public string Gender { get; set; }

        public string Address { get; set; }

        public string Nationality { get; set; }

        public string JobTitle { get; set; }

        public long PhoneNumber { get; set; }

        public DateOnly ContractDate { get; set; }

        public TimeOnly ArrivalTime { get; set; }

        public TimeOnly DepartureTime { get; set; }

        public int? DepartmentId { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int? RoleId { get; set; }
    }
}
