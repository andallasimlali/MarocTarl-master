using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarocTarl.Models
{
    public class StudentExam
    {
        public Guid Id { get; set; }
        public Guid? GroupeClasseStudentId { get; set; }
        //public GroupeClasseStudent GroupeClasseStudent { get; set; }
        public Guid ExamId { get; set; }
        public Exam Exam { get; set; }
        public DateTime DateAdd { get; set; }
        public Guid EtabFonctionnaireId { get; set; }
        public EtabFonctionnaire EtabFonctionnaire { get; set; }
        public TypeExam TypeExam { get; set; }
        //public List<Reponse> Reponses { get; set; }
    }

}