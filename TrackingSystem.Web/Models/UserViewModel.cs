using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrackingSystem.Web.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SerName { get; set; }
        public List<ProjectTaskViewModel> Tasks { get; set; }
    }
}
