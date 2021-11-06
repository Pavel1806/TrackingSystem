using System;
using System.Collections.Generic;
using System.Text;

namespace TrackingSystem.BLL.Models
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SerName { get; set; }
        public List<ProjectTaskDTO> Tasks { get; set; }
    }
}
