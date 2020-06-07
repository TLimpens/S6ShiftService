using ShiftService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ShiftService.Business.Shifts
{
    public interface IShiftManager
    {
        public Shift GetShift(int id);

        public List<Shift> GetShifts();

        public List<Shift> GetShiftsForUser(int userId);
    }
}
