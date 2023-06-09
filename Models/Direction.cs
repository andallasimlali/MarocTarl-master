using MarocTarl.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MarocTarl.Models
{
    public class Direction
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid AcademieId { get; set; }
        public Academie Academie { get; set; }
        public List<Etab> Etabs { get; set; }
       // public List<Secteur> Secteurs { get; set; }
    }

    [NotMapped]
    public class DirectionVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid AcademieId { get; set; }
        public Academie Academie { get; set; }
        public List<Etab> Etabs { get; set; }
         public List<Secteur> Secteurs { get; set; }
    }

}