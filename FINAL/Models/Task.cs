using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FINAL.Models
{
    [Authorize]
    public class Task : ITask
    {
        // VISIBLE EXCLUSIVEMENT PAR SON CREATEUR
        //Dropdown list(écran de création de tâche):
        //Créer tâches avec "Design Pattern Factory"

        public List<Task> TasksList { get; internal set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public string User { get; set; }
        public int Votes { get; set; }
        public TaskModel taskmodel { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        // CHANGER LE STATUS DE LA TACHE AVEC UN BOUTON DANS LE CONTROLLEUR
        public void UpdateStatus(bool status)
        {
            if (status == false)
            {
                this.Status = true;
            }
            else
            {
                this.Status = false;
            }
        }
        public void Reset()
        {
            // Void
        }
        public string GetSpecialInfo()
        {
            return "Valeur du compteur";
        }
    }
}