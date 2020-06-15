using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using U = ShiftService.Models.User;

namespace Common.DataTransfer
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        public string name { get; set; }
        public int shiftId { get; set; }

        public User(int id, string name, int shiftId)
        {
            this.id = id;
            this.name = name;
            this.shiftId = shiftId;
        }

        public U fromDTO()
        {
            return new U(id, name);
        }
        
    }
}
