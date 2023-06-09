using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarocTarl.Models
{
    public class Reponse
    {
        public Guid Id { get; set; }
        public bool IsCorrect { get; set; }
        public Guid ChoiceId { get; set; }
        public Choice Choice { get; set; }
        public DateTime DateAdd { get; set; }
        public Guid? StudentExamId { get; set; }
        //public StudentExam StudentExam { get; set; }

    }

}