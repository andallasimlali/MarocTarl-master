using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarocTarl.Models
{
    public class ClasseStudent
    {
        public Guid Id { get; set; }
        public Guid ClasseId { get; set; }
        public Classe Classe { get; set; }
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; }
        public List<GroupeClasseStudent> GroupeClasseStudents { get; set; }
    }

}