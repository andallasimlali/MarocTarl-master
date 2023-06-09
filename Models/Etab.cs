using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarocTarl.Models
{
    public class Etab
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid DirectionId { get; set; }
        public Direction Direction { get; set; }
        public List<Classe> Classes { get; set; }
        public List<SecteurEtab> SecteurEtabs { get; set; }
        //public List<EtabFonctionnaire> EtabFonctionnaires { get; set; }

    }
}