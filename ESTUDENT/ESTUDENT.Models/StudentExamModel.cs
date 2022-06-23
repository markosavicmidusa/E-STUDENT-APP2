using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESTUDENT.Models
{
    public class StudentExamModel
    {

        [Column("id")]
        public int Id { get; set; }

        [Column("student_id")]
        public int StudentId { get; set; }

        [Column("exam_id")]
        public int ExamId { get; set; }

        [Column("status")]
        public string Status { get; set; }

    }
}
