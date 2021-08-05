using System.Collections.Generic;

using GigHup2.Core.Models;

namespace GigHup2.Core.Repositorys
{
    public interface IAttenddanceRepository
    {
        Attendance GetAttendance(int gigId, string userid);
        IEnumerable<Attendance> GetFutureAttend(string userid);
    }
}