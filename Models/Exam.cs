using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarocTarl.Models
{
    public class Exam
    {
        public Guid Id { get; set; }
        public Niveau Niveau { get; set; }
        public Matiere Matiere { get; set; }
        public DateTime DateEffet { get; set; }
        public int PalierOrdre { get; set; }
        public string Title { get; set; }
        public List<Palier> Paliers { get; set; }
        public List<StudentExam> StudentExams { get; set; }
        public bool Obligatoire { get; set; }

    }

}