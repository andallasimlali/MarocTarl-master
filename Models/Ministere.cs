using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarocTarl.Models
{
    public class Ministere
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public AnnéeSColaire AnnéeSColaire { get; set; }
        public List<Academie> Academies { get; set; }
    }
}