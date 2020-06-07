using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Common.DataTransfer
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        public string name { get; set; }

        public User(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
