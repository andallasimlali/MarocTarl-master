using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarocTarl.Models
{
    public class GroupeClasseStudent
    {
        public Guid Id { get; set; }
        public Guid GroupeId { get; set; }
        public Groupe Groupe { get; set; }
        public Guid ClasseStudentId { get; set; }
        public ClasseStudent ClasseStudent { get; set; }
        //public List<StudentExam> StudentExams { get; set; }
    }

}