using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarocTarl.Models
{
    public class Question
    {
        public Guid Id { get; set; }
        public Guid ExerciceId { get; set; }
        public Exercice Exercice { get; set; }
        public int Ordre { get; set; }
        public List<Choice> Choices { get; set; }
    }

}