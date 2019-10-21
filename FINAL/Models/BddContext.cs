using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using FINAL.Models;
using MySql.Data.Entity;

namespace FINAL.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class BddContext : DbContext
    {
        public BddContext()
            : base("Connection")
        {
            this.Configuration.ValidateOnSaveEnabled = false;
        }

        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }
    }
}