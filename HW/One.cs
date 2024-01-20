using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NpgsqlTypes;
using Npgsql;
using System.ComponentModel.DataAnnotations;

namespace First
{
    [Table("one")]
    public class One
    {
        [Key]
        [Column("product_name")]
        public string ProductName { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("price")]
        public int Price { get; set; }

        [Column("total_amount")]
        public int TotalAmount { get; set; }

    }
}
