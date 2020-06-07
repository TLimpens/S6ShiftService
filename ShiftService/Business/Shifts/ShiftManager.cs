using ShiftService.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShiftService.Models;
using C = Common.DataTransfer.Shift;
using Microsoft.EntityFrameworkCore;

namespace ShiftService.Business.Shifts
{
    public class ShiftManager : IShiftManager
    {
        private readonly ShiftContext _shiftContext;

        public ShiftManager(ShiftContext shiftContext)
        {
            _shiftContext = shiftContext;
        }

        public Shift GetShift(int id)
        {
            return _shiftContext.Shifts.Find(id).fromDTO();
        }

        public List<Shift> GetShifts()
        {
            List<Shift> returnList = new List<Shift>();


            foreach (C.Shift shift in _shiftContext.Shifts.OrderBy(x => x.shiftDate).ToList())
            {
                returnList.Add(shift.fromDTO());
            }
            
            
            
            return returnList;
        }

        public List<Shift> GetShiftsForUser(int userId)
        {
            return this._shiftContext.Shifts.Where(x => x.workingEmployees.Any(s => s.id == userId))
                .Include(x => x.workingEmployees)
                .Select(x => x.fromDTO())
                .ToList();

        }
    }
}
