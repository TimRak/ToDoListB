using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FINAL.Models
{
    public class Factory
    {
        public static ITask create_task(string tasktype)
        {
            switch (tasktype)
            {
                case "task":
                    return new Task();
                case "blogpost":
                    return new BlogPost();
                default:
                    throw new Exception("unknown task requested");
            }
        }
    }
}