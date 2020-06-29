 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShiftService.Business.Shifts;
using ShiftService.Models;

namespace ShiftService.Controllers
{
    [Route("api/[controller]")]
    public class ShiftController : Controller
    {

        private readonly IShiftManager _manager;

        public ShiftController(IShiftManager manager)
        {
            this._manager = manager;
        }

        [HttpGet("GetShift/{id}")]
        public async Task<Shift> GetShift(int id)
        {
            return await _manager.GetShiftAsync(id);
        }

        [HttpGet("GetShifts")]
        public async Task<List<Shift>> GetShifts()
        {
            return await _manager.GetShiftsAsync();
        }

        [HttpGet("getallupcommingshifts")]
        public async Task<List<Shift>> GetAllUpcommingShifts()
        {
            return await _manager.GetAllUpcommingShiftsAsync();
        }

        [HttpGet("GetShiftsForUser/{userId}")]
        public async Task<List<Shift>> GetShiftsForUser(int userId)
        {
            return await _manager.GetShiftsForUserAsync(userId);
        }

        [HttpPost("PostNewShift")]
        public async void PostNewShift([FromBody]Shift shift)
        {
            await _manager.PostNewShiftAsync(shift);

        }

    }
}