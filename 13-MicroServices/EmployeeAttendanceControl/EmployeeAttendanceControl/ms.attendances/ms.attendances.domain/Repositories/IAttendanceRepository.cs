using System.Collections.Generic;
using System.Threading.Tasks;
using ms.attendances.domain.Entities;

namespace ms.attendances.domain.Repositories
{
    public interface IAttendanceRepository {
        Task<List<AttendanceRecord>> GetAllAttendances(string userName);
        Task<bool> CreateAttendance(AttendanceRecord attendanceRecord);
    }
}
