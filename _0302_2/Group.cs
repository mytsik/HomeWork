using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NpgsqlTypes;
using Npgsql;
using System.ComponentModel.DataAnnotations;

namespace _2001
{
    [Table("group")]
    public class Group
    {
        [Key]
        [Column("group_name")]
        public string GroupName { get; set; }
        
    }
}
