using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarocTarl.Models
{
    public class SecteurEtab
    {
        public Guid Id { get; set; }
        public Guid SecteurId { get; set; }
        public Secteur Secteur { get; set; }
        public Guid EtabId { get; set; }
        public Etab Etab { get; set; }
    }

}