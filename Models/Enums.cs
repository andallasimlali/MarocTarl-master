using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MarocTarl.Models
{
    public enum Gender
    {
        [Display(Name = "ذكر")]
        Male,
        [Display(Name = "أنثى")]
        Femelle
    }

    public enum TypeQuestion
    {
        [Display(Name = "صحيح / خطأ")]
        trueFalse,
        [Display(Name = "اختيار من متعدد")]
        MultiChoices
    }


    public enum TypeExam
    {
        [Display(Name ="رائز تموضع")]
        Postitioning,
        [Display(Name = "رائز تتبع")]
        Suivi,
        [Display(Name = "رائز نهاية الدعم")]
        Final
    }

    public enum Matiere
    {
        [Display(Name = "اللغة العربية")]
        Arabe,
        [Display(Name = "اللغة الفرنسية")]
        Français,
        [Display(Name = "الرياضيات")]
        Maths
    }


    public enum Niveau
    {
        [Display(Name = "المستوى الأول")]
        Année1,
        [Display(Name = "المستوى الثاني")]
        Année2,
        [Display(Name = "المستوى الثالث")]
        Année3,
        [Display(Name = "المستوى الرابع")]
        Année4,
        [Display(Name = "المستوى الخامس")]
        Année5,
        [Display(Name = "المستوى السادس")]
        Année6
    }


    public enum AnnéeSColaire
    {
        [Display(Name = "2022/2023")]
        A2022_2023,
        [Display(Name = "2023/2024")]
        A2023_2024,
        [Display(Name = "2024/2025")]
        A2024_2025
    }


    public enum MinistRoles
    {
        [Display(Name = "وزير التربية الوطنية")]
        Ministere=101,
        [Display(Name = "المسؤول الوطني عن مشروع TaRL")]
        MiniChefProjet=102,
        [Display(Name = "المنسق الوطني لمشروع TaRL")]
        MiniCoordProjet = 103,
        [Display(Name = "المنسق الوطني GENIE")]
        MiniCoordGENIE = 104,
        [Display(Name = "جمعية تاركا")]
        AssoTarga = 105

    }


    public enum AcademieRoles
    {
        [Display(Name = "مدير الأكاديمية")]
        Academie = 201,
        [Display(Name = "المسؤول الجهوي عن مشروع TaRL")]
        AcademieChefProjet = 202,
        [Display(Name = "المنسق الجهوي لمشروع TaRL")]
        AcademieCoordProjet = 203,
        [Display(Name = "المنسق الجهوي GENIE")]
        AcademieCoordGENIE = 204

    }

    public enum DirectionRoles
    {
        [Display(Name = "المدير الإقليمي")]
        Direction = 401,
        [Display(Name = "المسؤول الإقليمي عن مشروع TaRL")]
        DirectionChefProjet = 402,
        [Display(Name = "المنسق الإقليمي لمشروع TaRL")]
        DirectionCoordProjet = 403,
        [Display(Name = "المنسق الإقليمي لمشروع GENIE")]
        DirectionCoordGENIE = 404,
        [Display(Name = "مفتش تربوي")]
        Inspecteur = 405

    }


    public enum EtabRoles
    {
        [Display(Name = "مدير المؤسسة")]
        Etab = 501,
        [Display(Name = "أستاذ")]
        Prof = 502,
        [Display(Name = "تلميذ")]
        Student = 503

    }

}