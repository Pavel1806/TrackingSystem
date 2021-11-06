using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrackingSystem.Web.Models
{
    public class ProjectTaskViewModel
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public string Priority { get; set; }
        public string Type { get; set; }
        public ProjectViewModel Project { get; set; }
        public UserViewModel User { get; set; }
        public List<ProjectViewModel> projectViewModels { get; set; }
        public List<UserViewModel> userViewModels { get; set; }

    }
}
