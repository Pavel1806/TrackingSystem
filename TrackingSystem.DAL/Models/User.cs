using System;
using System.Collections.Generic;
using System.Text;

namespace TrackingSystem.DAL.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SerName { get; set; }
        public List<ProjectTask> Tasks { get; set; }
        public User()
        {
            Tasks = new List<ProjectTask>();
        }

    }
}
