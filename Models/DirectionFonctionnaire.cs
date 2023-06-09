using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarocTarl.Models
{
    public class DirectionFonctionnaire
    {
        public Guid Id { get; set; }
        public Guid DirectionId { get; set; }
        public Direction Direction { get; set; }
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; }
        public AnnéeSColaire AnnéeScolaire { get; set; }
    }

}