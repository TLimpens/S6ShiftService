using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using S = Common.DataTransfer.Shift;
using U = Common.DataTransfer.User;

namespace ShiftService.Models
{
    public class Shift
    {
        public int id { get; set; }
        public int employeeSlots { get; set; }
        public DateTime shiftDate { get; set; }
        public List<User> workingEmployees { get; set; }

        public Shift(int id, int employeeSlots, DateTime shiftDate, List<User> workingEmployees) 
        {
            this.id = id;
            this.employeeSlots = employeeSlots;
            this.shiftDate = shiftDate;
            this.workingEmployees = workingEmployees;
        }

        public Shift()
        {
        }

        public override string ToString()
        {
            return base.ToString() + ": " + id.ToString();
        }

        public S.Shift ToDTO()
        {

            List<U> translatedUsers = new List<U>();

            foreach (User u in workingEmployees)
            {
                translatedUsers.Add(u.ToDTO());
            }

            return new S.Shift(this.id, this.employeeSlots, this.shiftDate, translatedUsers);
        }
    }
}
