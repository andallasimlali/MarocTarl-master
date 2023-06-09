using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarocTarl.Models
{
    public class Classe
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid EtabId { get; set; }
        public Etab Etab { get; set; }
        public Niveau Niveau { get; set; }
        public AnnéeSColaire AnnéeScolaire { get; set; }
        public List<ClasseStudent>ClasseStudents  { get; set; }
        public List<EtabFonctionnaireClasse> EtabFonctionnaireClasses { get; set; }
    }
}