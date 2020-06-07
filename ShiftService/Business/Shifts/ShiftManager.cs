using ShiftService.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using C = Common.DataTransfer.Shift;

namespace ShiftService.Business.Shifts
{
    public class ShiftManager : IShiftManager
    {
        private readonly ShiftContext _shiftContext;

        public ShiftManager(ShiftContext shifContext)
        {
            _shiftContext = shifContext;
        }

        public C.Shift GetShift(int id)
        {
            return _shiftContext.Shifts.Find(id);
        }

        public List<C.Shift> GetShifts()
        {
            return _shiftContext.Shifts.OrderBy(x => x.shiftDate).ToList();
        }

        public List<C.Shift> GetShiftsForUser(int userId)
        {
            var shifts =
                from s in this._shiftContext.Shifts
                where s.workingEmployees.Any(x => x.id == userId)
                select s;

            return shifts.OrderBy(x => x.shiftDate).ToList();
        }
    }
}
