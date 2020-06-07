using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using C = Common.DataTransfer.Shift;


namespace ShiftService.Business.Shifts
{
    public interface IShiftManager
    {
        public C.Shift GetShift(int id);

        public List<C.Shift> GetShifts();

        public List<C.Shift> GetShiftsForUser(int userId);
    }
}
