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
        public Shift GetShift(int id)
        {
            return _manager.GetShift(id);
        }

        [HttpGet("GetShifts")]
        public List<Shift> GetShifts()
        {
            return _manager.GetShifts();
        }

        [HttpGet("GetShiftsForUser/{userId}")]
        public Task<List<Shift>> GetShiftsForUser(int userId)
        {
            return _manager.GetShiftsForUser(userId);
        }

        [HttpPost("PostNewShift")]
        public void PostNewShift([FromBody]Shift shift)
        {
            _manager.PostNewShift(shift);

        }
    }
}