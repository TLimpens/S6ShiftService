using ShiftService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ShiftService.Business.Shifts
{
    public interface IShiftManager
    {
        public Task<Shift> GetShiftAsync(int id);

        public Task<List<Shift>> GetShiftsAsync();

        public Task<List<Shift>> GetAllUpcommingShiftsAsync();

        public Task<List<Shift>> GetShiftsForUserAsync(int userId);
        public Task PostNewShiftAsync(Shift shift);
    }
}
