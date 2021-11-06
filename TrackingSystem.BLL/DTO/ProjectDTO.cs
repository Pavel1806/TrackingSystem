using System;
using System.Collections.Generic;
using System.Text;

namespace TrackingSystem.BLL.Models
{
    public class ProjectDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProjectTaskDTO> Tasks { get; set; }
    }
}
