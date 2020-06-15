using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using U = Common.DataTransfer.User;

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

        public U ToDTO()
        {
            return new U(this.id, this.name, 0);
        }
    }
}
