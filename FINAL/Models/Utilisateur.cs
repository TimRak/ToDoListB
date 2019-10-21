using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FINAL.Models
{
    public class Utilisateur
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nom")]
        public string Nom { get; set; }
        [Required]
        [Display(Name = "Mot de passe")]
        public string MotDePasse { get; set; }
        [Compare("MotDePasse", ErrorMessage = "Confirm password doesn't match, Type again !")]
        [Display(Name = "Confirmation")]
        public string ConfirmMotDePasse { get; set; }
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Incorrect Email Format")]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}