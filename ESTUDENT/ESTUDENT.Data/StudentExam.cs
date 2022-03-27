using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESTUDENT.Data
{
    [Table("students_exams")]
    public class StudentExam
    {
        [Column("id")]
        public int Id { get; set; }
        
        [Column("student_id")]
        public int StudentId { get; set; }

        [Column("exam_id")]
        public int ExamId { get; set; }
    }
}
