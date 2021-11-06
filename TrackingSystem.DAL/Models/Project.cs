using System;
using System.Collections.Generic;
using System.Text;

namespace TrackingSystem.DAL.Models
{
   public class Project
    {
        public int Id { get; set; }
        public string Name{ get;set;}

        public List<ProjectTask> Tasks { get; set; }
        public Project()
        {
            Tasks = new List<ProjectTask>();
        }

    }
}
