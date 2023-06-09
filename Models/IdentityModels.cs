using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MarocTarl.Models
{



    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        public string NomAr { get; set; }
        public string NomFr { get; set; }
        public string PrenomAr { get; set; }
        public string PrenomFr { get; set; }
        public string TEL { get; set; }
        public string CIN { get; set; }
        public Gender Gender { get; set; }
        public int PW { get; set; }


        public List<MinistereFonctionnaire> MinistereFonctionnaires { get; set; }
        public List<AcademieFonctionnaire> AcademieFonctionnaires { get; set; }
        public List<DirectionFonctionnaire> DirectionFonctionnaires { get; set; }
        public List<ClasseStudent> ClasseStudents { get; set; }
        public List<Etab> Etabs { get; set; }

        public List<EtabFonctionnaire> EtabFonctionnaires { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<MarocTarl.Models.Exam> Exams { get; set; }

        public System.Data.Entity.DbSet<MarocTarl.Models.Palier> Paliers { get; set; }

        public System.Data.Entity.DbSet<MarocTarl.Models.Exercice> Exercices { get; set; }

        public System.Data.Entity.DbSet<MarocTarl.Models.Question> Questions { get; set; }

        public System.Data.Entity.DbSet<MarocTarl.Models.Choice> Choices { get; set; }

        public System.Data.Entity.DbSet<MarocTarl.Models.Ministere> Ministeres { get; set; }

        public System.Data.Entity.DbSet<MarocTarl.Models.MinistereFonctionnaire> MinistereFonctionnaires { get; set; }

        public System.Data.Entity.DbSet<MarocTarl.Models.Academie> Academies { get; set; }

        public System.Data.Entity.DbSet<MarocTarl.Models.AcademieFonctionnaire> AcademieFonctionnaires { get; set; }

        public System.Data.Entity.DbSet<MarocTarl.Models.Direction> Directions { get; set; }

        public System.Data.Entity.DbSet<MarocTarl.Models.DirectionFonctionnaire> DirectionFonctionnaires { get; set; }

        public System.Data.Entity.DbSet<MarocTarl.Models.Etab> Etabs { get; set; }

        public System.Data.Entity.DbSet<MarocTarl.Models.Secteur> Secteurs { get; set; }

        public System.Data.Entity.DbSet<MarocTarl.Models.SecteurEtab> SecteurEtabs { get; set; }

        public System.Data.Entity.DbSet<MarocTarl.Models.EtabFonctionnaire> EtabFonctionnaires { get; set; }

        public System.Data.Entity.DbSet<MarocTarl.Models.Classe> Classes { get; set; }

        public System.Data.Entity.DbSet<MarocTarl.Models.EtabFonctionnaireClasse> EtabFonctionnaireClasses { get; set; }

        public System.Data.Entity.DbSet<MarocTarl.Models.Groupe> Groupes { get; set; }

        public System.Data.Entity.DbSet<MarocTarl.Models.ClasseStudent> ClasseStudents { get; set; }

        public System.Data.Entity.DbSet<MarocTarl.Models.GroupeClasseStudent> GroupeClasseStudents { get; set; }

        public System.Data.Entity.DbSet<MarocTarl.Models.StudentExam> StudentExams { get; set; }

        public System.Data.Entity.DbSet<MarocTarl.Models.Reponse> Reponses { get; set; }

        public System.Data.Entity.DbSet<MarocTarl.Models.Excel> Excels { get; set; }
    }
}