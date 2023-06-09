using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarocTarl.Models
{
    public class EtabFonctionnaire
    {
        public Guid Id { get; set; }
        public Guid? EtabId { get; set; }
        //public Etab Etab { get; set; }
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; }
        public AnnéeSColaire AnnéeScolaire { get; set; }
        //public List<EtabFonctionnaire> EtabFonctionnaires { get; set; }
        public List<StudentExam> StudentExams { get; set; }
        public List<EtabFonctionnaireClasse> EtabFonctionnaireClasses { get; set; }

    }

}