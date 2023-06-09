using MarocTarl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarocTarl.Controllers
{
    public class MinistereService
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public AnnéeSColaire GetCurrentAnnéeScolaire(Guid id)
        {
            var ministere = db.Ministeres.FirstOrDefault(x => x.Id == id);

            if (ministere == null)
            {
                return 0;
            }

            return ministere.AnnéeSColaire;
        }
        public string FormatCIN(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("المدخل غير صالح. يجب ألا يكون فارغًا.");
            }

            string letters = input.Substring(0, Math.Min(input.Length, 2)).ToUpper();
            string number = input.Substring(Math.Min(input.Length, 2));

            if (letters.Length < 1 || letters.Length > 2)
            {
                throw new ArgumentException("تنسيق الرقم التعريفي غير صالح: يجب أن يحتوي الجزء الأول على حرف واحد أو اثنين.");
            }

            int numericPart;
            if (!int.TryParse(number, out numericPart) || numericPart < 1 || numericPart > 999999)
            {
                throw new ArgumentException("تنسيق الرقم التعريفي غير صالح: يجب أن يكون الجزء الثاني رقمًا بين 1 و 999999.");
            }

            return letters + numericPart.ToString();
        }

        public bool IsValidCIN(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            string letters = input.Substring(0, Math.Min(input.Length, 2)).ToUpper();
            string number = input.Substring(Math.Min(input.Length, 2));

            if (letters.Length < 1 || letters.Length > 2)
            {
                return false;
            }

            int numericPart;
            if (!int.TryParse(number, out numericPart) || numericPart < 1 || numericPart > 999999)
            {
                return false;
            }

            return true;
        }



    }
}