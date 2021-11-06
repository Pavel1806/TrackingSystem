using System;
using System.Collections.Generic;
using System.Text;

namespace TrackingSystem.BLL.Models
{
    public class ProjectTaskDTO
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public string Priority { get; set; }
        public string Type { get; set; }
        public int projectId { get; set; }
        public int userId { get; set; }
        public ProjectDTO projectDTO{get; set;}
        public UserDTO userDTO { get; set; }

        
    }
}
