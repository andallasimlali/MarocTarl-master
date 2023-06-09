using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarocTarl.Models
{
    public class EtabFonctionnaireClasse
    {
        public Guid Id { get; set; }
        public Guid ClasseId { get; set; }
        public Classe Classe { get; set; }
        public Guid EtabFonctionnaireId { get; set; }
        public EtabFonctionnaire EtabFonctionnaire { get; set; }
    }

}