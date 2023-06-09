using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarocTarl.Models
{
    public class Groupe
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid EtabFonctionnaireId { get; set; }
        public EtabFonctionnaire EtabFonctionnaire { get; set; }
        public DateTime DateAdd { get; set; }
        public bool Default { get; set; }
        public List<GroupeClasseStudent> GroupeClasseStudents { get; set; }
    }


}