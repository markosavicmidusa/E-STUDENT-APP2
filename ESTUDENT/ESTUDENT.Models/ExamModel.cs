using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESTUDENT.Models

{
    public class ExamModel
    {

        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("year")]
        public int Year { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("professor")]
        public string Professor { get; set; }

        [Column("assistant")]
        public string Assistant { get; set; }

        [Column("date")]
        public DateTime Date { get; set; }
    }
}
