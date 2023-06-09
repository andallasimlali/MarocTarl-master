using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MarocTarl.Models
{
    public class Secteur
    {
        public Guid Id { get; set; }
        public Guid? DirectionFonctionnaireId { get; set; }
        //public Direction Direction { get; set; }
        public string Name { get; set; }
        public List<SecteurEtab> SecteurEtabs { get; set; }
    }


    [NotMapped]
    public class SecteurVM
    {
        public Guid Id { get; set; }
        public Guid? DirectionId { get; set; }
        public Direction Direction { get; set; }
        public string Name { get; set; }
        public List<SecteurEtab> SecteurEtabs { get; set; }
    }

}