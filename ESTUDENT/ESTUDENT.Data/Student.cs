using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESTUDENT.Data
{
    [Table("students")]
    public class Student : Base
    {
        [Column("surname")]
        public string Surname { get; set; }

        [Column("index")]
        public string Index { get; set; }

        [Column("address")]
        public string Address { get; set; }


    }
}
