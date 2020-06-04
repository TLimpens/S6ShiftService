using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShiftService.Models
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }

        public User(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
