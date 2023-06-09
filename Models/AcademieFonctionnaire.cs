using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace MarocTarl.Models
{
    public class AcademieFonctionnaire
    {
        public Guid Id { get; set; }
        public Guid AcademieId { get; set; }
        public Academie Academie { get; set; }
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; }
        public AnnéeSColaire AnnéeSِolaire { get; set; }
    }



}