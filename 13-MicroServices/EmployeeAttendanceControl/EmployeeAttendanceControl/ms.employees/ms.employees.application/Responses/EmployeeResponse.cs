using System;
namespace ms.employees.application.Responses
{
    public class EmployeeResponse
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime LastAttendanceDate { get; set; }
        public bool? LastAttendanceState { get; set; }
        public string LastAttendanceNotes { get; set; }
    }
}
