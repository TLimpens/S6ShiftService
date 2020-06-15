using ShiftService.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShiftService.Models;
using C = Common.DataTransfer.Shift;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace ShiftService.Business.Shifts
{
    public class ShiftManager : IShiftManager
    {
        private readonly ShiftContext _shiftContext;

        public ShiftManager(ShiftContext shiftContext)
        {
            _shiftContext = shiftContext;
        }

        public async Task<Shift> GetShiftAsync(int id)
        {
            return await _shiftContext.Shifts.Where(x => x.id == id)
                        .Include(x => x.workingEmployees)
                        .Select(x => x.fromDTO()).SingleAsync();
        }

        public async Task<List<Shift>> GetShiftsAsync()
        {
            return await _shiftContext.Shifts
                .Include(x => x.workingEmployees)
                .Select(x => x.fromDTO())
                .ToListAsync();
        }

        public async Task<List<Shift>> GetShiftsForUserAsync(int userId)
        {

            return await _shiftContext.Shifts.Where(x => x.workingEmployees.Any(s => s.id == userId))
                .Include(x => x.workingEmployees)
                .Select(x => x.fromDTO())
                .ToListAsync();

        }

        public async Task PostNewShiftAsync(Shift shift)
        {
            _shiftContext.Add(shift.ToDTO());
            await _shiftContext.SaveChangesAsync();
        }
    }
}
