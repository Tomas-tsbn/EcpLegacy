using System;
using System.Collections.Generic;

namespace EcpLegacy.API.Models
{
    public partial class ProjectState
    {
        public ProjectState()
        {
            ProjectStateHistory = new HashSet<ProjectStateHistory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? Datecreated { get; set; }
        public DateTime? Datemodified { get; set; }
        public int? Createdbyid { get; set; }
        public int? Modifiedbyid { get; set; }

        public virtual ICollection<ProjectStateHistory> ProjectStateHistory { get; set; }
    }
}
