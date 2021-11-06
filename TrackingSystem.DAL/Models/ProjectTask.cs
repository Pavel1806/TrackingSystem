using System;
using System.Collections.Generic;
using System.Text;

namespace TrackingSystem.DAL.Models
{
    public class ProjectTask
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public string Priority { get; set; }
        public string Type { get; set; }
        public int ProjectId { get; set; }
        public Project project { get; set; }
        public int UserId { get; set; }
        public User user { get; set; }
    }
}
