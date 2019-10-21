using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using FINAL.Models;
using System.Text;

namespace FINAL.Models
{
    public class Dal : IDal
    {
        private BddContext bdd;

        public static string EncodeMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }


        public int AjouterUtilisateur(string nom, string motDePasse, string confirmation, string email)
        {
            string motDePasseEncode = EncodeMD5(motDePasse);
            string confirmationEncode = EncodeMD5(confirmation);
            Utilisateur utilisateur = new Utilisateur { Nom = nom, MotDePasse = motDePasseEncode, ConfirmMotDePasse = confirmationEncode, Email = email };
            bdd.Utilisateurs.Add(utilisateur);
            bdd.SaveChanges();
            return utilisateur.Id;
        }

        public Utilisateur Authentifier(string nom, string motDePasse)
        {
            string motDePasseEncode = EncodeMD5(motDePasse);
            return bdd.Utilisateurs.FirstOrDefault(u => u.Nom == nom && u.MotDePasse == motDePasseEncode);
        }

        public Utilisateur ObtenirUtilisateur(int id)
        {
            return bdd.Utilisateurs.FirstOrDefault(u => u.Id == id);
        }

        public Utilisateur ObtenirUtilisateur(string idString)
        {
            int id;
            if (int.TryParse(idString, out id))
                return ObtenirUtilisateur(id);
            return null;
        }

        public class UtilisateurViewModel
        {
            public Utilisateur Utilisateur { get; set; }
            public bool Authentifie { get; set; }
        }

        public Dal()
        {
            bdd = new BddContext();
        }

        public List<TaskModel> GetTasks()
        {
            return bdd.Tasks.ToList();
        }

        public void CreateTask(string title, string type, string username, string description)
        {
            bdd.Tasks.Add(new TaskModel { Title = title, Type = type, User = username, Date = DateTime.Today, Description = description });
            bdd.SaveChanges();
        }

        public void Dispose()
        {
            bdd.Dispose();
        }

        List<Task> IDal.GetTasks()
        {
            throw new NotImplementedException();
        }
    }
}