using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESTUDENT.Models
{
    public class StudentModel
    {

        [Column("id")]
        public int Id { get; set; }
        
        //[Column("name")]
        [Required]
        [Display(Name = "NAME-LABEL", Prompt = "NAME-PLACEHOLDER")]
        public string Name { get; set; }

        //[Column("year")]
        [Required]
        [Display(Name = "YEAR-LABEL", Prompt = "YEAR-PLACEHOLDER")]
        public int Year { get; set; }

        //[Column("surname")]
        [Required]
        [Display(Name = "SURNAME-LABEL", Prompt = "SURNAME-PLACEHOLDER")]
        public string Surname { get; set; }

        [Column("index")]
        [Required]
        [Display(Name = "INDEX-LABEL", Prompt = "INDEX-PLACEHOLDER")]
        public string Index { get; set; }

        [Column("address")]
        [Required]
        [Display(Name = "ADDRESS-LABEL", Prompt = "ADDRESS-PLACEHOLDER")]
        public string Address { get; set; }

    }
}
