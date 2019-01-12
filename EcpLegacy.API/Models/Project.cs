using System;
using System.Collections.Generic;

namespace EcpLegacy.API.Models
{
    public partial class Project
    {
        public Project()
        {
            ProjectPhase = new HashSet<ProjectPhase>();
            ProjectStateHistory = new HashSet<ProjectStateHistory>();
        }

        public int Id { get; set; }
        public int? Clientid { get; set; }
        public string Pn { get; set; }
        public string Pnname { get; set; }
        public int? Soldhours { get; set; }
        public string Name { get; set; }
        public string Remarks { get; set; }
        public DateTime? Datecreated { get; set; }
        public DateTime? Datemodified { get; set; }
        public int? Createdbyid { get; set; }
        public int? Modifiedbyid { get; set; }
        public bool? Completed { get; set; }

        public virtual Client Client { get; set; }
        public virtual ICollection<ProjectPhase> ProjectPhase { get; set; }
        public virtual ICollection<ProjectStateHistory> ProjectStateHistory { get; set; }
    }
}
