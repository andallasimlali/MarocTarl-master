using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarocTarl.Models
{
    public class Exercice
    {
        public Guid Id { get; set; }
        public Guid PalierId { get; set; }
        public Palier Palier { get; set; }
        public string Description { get; set; }
        public int Ordre { get; set; }
        public bool ShowWithPrevious { get; set; }
        public double Seuil { get; set; }
        public List<Question> Questions { get; set; }
    }

}