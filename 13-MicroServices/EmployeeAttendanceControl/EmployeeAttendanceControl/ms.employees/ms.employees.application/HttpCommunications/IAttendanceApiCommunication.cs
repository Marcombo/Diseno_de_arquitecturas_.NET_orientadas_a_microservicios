using System.Collections.Generic;
using System.Threading.Tasks;
using ms.employees.application.HttpCommunications.Responses;
using Refit;

namespace ms.employees.application.HttpCommunications
{
    public interface IAttendanceApiCommunication
    {
        [Get("/Attendances/GetAllAttendances")]
        Task<IEnumerable<AttendanceApiCommunicationResponse>> GetAllAttendances(string userName
                                                                    , [Header("Authorization")] string token);
    }
}
