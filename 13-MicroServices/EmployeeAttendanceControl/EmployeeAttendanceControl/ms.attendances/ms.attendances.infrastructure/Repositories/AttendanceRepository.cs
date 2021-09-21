using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Driver;
using ms.attendances.domain.Entities;
using ms.attendances.domain.Repositories;
using ms.attendances.infrastructure.Data;
using ms.attendances.infrastructure.MongoEntities;

namespace ms.attendances.infrastructure.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly IAttendanceContext _context;
        private readonly IMapper _mapper;
        public AttendanceRepository(IAttendanceContext context,IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateAttendance(AttendanceRecord entity) {
            await _context.AttendanceCollection.InsertOneAsync(_mapper.Map<AttendanceMongo>(entity));
            return true;
        }

        public async Task<List<AttendanceRecord>> GetAllAttendances(string userName)
        {
            var queryResult = await ((userName != null) ?
                                                  _context.AttendanceCollection.FindAsync(a => a.UserName == userName)
                                                : _context.AttendanceCollection.FindAsync(a => true));
            var res = queryResult.ToListAsync().Result;

            return _mapper.Map<List<AttendanceRecord>>(res);
        }
    }
}
