using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FINAL.Models
{
    public class BlogPost : ITask
    {
        // VUE PAR TOUS LES UTILISATEURS
        // Affiche compteur d'upvotes
        //if(upvotes == 0){afficher le BlogPost normalement}
        //if(upvotes > 0){afficher en vert}
        //if(upvotes< 0){afficher en rouge}
        
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public string User { get; set; }
        public int Votes { get; set; }
        public TaskModel taskmodel { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string GetSpecialInfo()
        {
            if (this.Date < DateTime.Today)
            {
                return "délai passé";
            }
            else
            {
                return "";
            }
        }
        public void Reset()
        {
            // Remet le compteur à zero
            this.Votes = 0;
        }
        public void UpdateStatus(bool status)
        {
            switch(status)
            {
                case true:
                    this.Votes += 1;
                    break;

                case false:
                    this.Votes = this.Votes - 1;
                    break;
                default:
                    break;
            }
        }
    }
}