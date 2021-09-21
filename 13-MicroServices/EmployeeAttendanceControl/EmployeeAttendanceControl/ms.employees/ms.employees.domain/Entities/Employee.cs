using System;
using System.ComponentModel.DataAnnotations;

namespace ms.employees.domain.Entities
{
    public class Employee
    {
        [Required]
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? LastAttendanceDate { get; set; }
        public bool LastAttendanceState { get; set; }
        public string LastAttendanceNotes { get; set; }
    }
}
