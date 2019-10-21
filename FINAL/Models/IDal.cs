using FINAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FINAL.Models
{
    public interface IDal : IDisposable
    {
        List<Task> GetTasks();
        int AjouterUtilisateur(string nom, string motDePasse, string confirm, string email);
        Utilisateur Authentifier(string nom, string motDePasse);
        Utilisateur ObtenirUtilisateur(int id);
        Utilisateur ObtenirUtilisateur(string idStr);

    }
}