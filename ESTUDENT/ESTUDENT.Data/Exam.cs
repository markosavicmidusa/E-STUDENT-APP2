using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESTUDENT.Data
{
    [Table("exams")]
    public class Exam : Base
    {

        [Column("description")]
        public int Description { get; set; }
        
        [Column("professor")]
        public string Professor { get; set; }
        
        [Column("assistant")]
        public string Assistant { get; set; }



    }
}
