using System;
namespace ms.attendances.application.Request
{
    public class CreateAttendanceRequest
    {
        public string FullName { get; set; }
        public DateTime Date { get; set; }
        public bool Attendance { get; set; }
        public string Notes { get; set; }
    }
}
