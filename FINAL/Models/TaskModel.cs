using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FINAL.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public bool Status { get; set; }
        public string User { get; set; }
        public int Votes { get; set; }
    }
}