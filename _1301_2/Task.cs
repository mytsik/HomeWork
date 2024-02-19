using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NpgsqlTypes;
using Npgsql;
using System.ComponentModel.DataAnnotations;

namespace _1301_2
{
    
    [Table("task")]
    public class Task
    {

        [Key]
        [Column("task_name")]
        public string TaskName { get; set; }

        [Column("deadline")]
        public string Deadline { get; set; }

        [Column("status")]
        public string Status { get; set; }
    }

}
