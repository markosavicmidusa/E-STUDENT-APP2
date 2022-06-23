using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESTUDENT.Data
{
    public class StudentStudentExamExam : StudentExam
    {
        [Column("name")]
        public string Name { get; set; }

        [Column("professor")]
        public string Professor { get; set; }

        [Column("assistant")]
        public string Assistant { get; set; }

        [Column("date")]
        public DateTime Date { get; set; }

        [Column("name")]
        public string StudentName { get; set; }

        [Column("surname")]
        public string Surname { get; set; }

        [Column("index")]
        public string Index { get; set; }

        [Column("year")]
        public int Year { get; set; }

    }
}
