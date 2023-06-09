using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarocTarl.Models
{
    public class Palier
    {
        public Guid Id { get; set; }
        public Guid ExamId { get; set; }
        public int Ordre { get; set; }
        public Exam Exam { get; set; }
        public bool IsCompetence { get; set; }
        public List<Exercice> Exercices { get; set; }
    }

}