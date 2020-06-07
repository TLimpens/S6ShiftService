using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Common.DataTransfer.Shift
{
    public class Shift
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        public int employeeSlots { get; set; }
        public DateTime shiftDate { get; set; }
        public virtual ICollection<User> workingEmployees { get; set; }

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
    }
}
