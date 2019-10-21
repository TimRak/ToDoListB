using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FINAL.Models
{
    public interface ITask
    {
        TaskModel taskmodel { get; set; }
        void UpdateStatus(bool status);
        void Reset();
        string GetSpecialInfo();
    }
}