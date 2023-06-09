using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarocTarl.Models
{
    public class MinistereFonctionnaire
    {
        public Guid Id { get; set; }
        public Guid MinistereId { get; set; }
        public Ministere Ministere { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public AnnéeSColaire AnnéeSColaire { get; set; }
    }


    public class MinistereFonctionnaireVM
    {
        public Guid Id { get; set; }
        public Guid MinistereId { get; set; }
        public Ministere Ministere { get; set; }
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; }
        public AnnéeSColaire AnnéeScolaire { get; set; }
        public string NomAr { get; set; }
        public string NomFr { get; set; }
        public string PrenomAr { get; set; }
        public string PrenomFr { get; set; }
        public string TEL { get; set; }
        public string CIN { get; set; }
        public Gender Gender { get; set; }
        public bool IsMinistere { get; set; }
        public bool IsMiniChefProjet { get; set; }
        public bool IsMiniCoordProjet { get; set; }
        public bool IsMiniCoordGENIE { get; set; }
        public bool IsAssoTarga { get; set; }

    }




}