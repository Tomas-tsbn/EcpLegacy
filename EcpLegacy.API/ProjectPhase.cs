using System;
using System.Collections.Generic;

namespace EcpLegacy.API
{
    public partial class ProjectPhase
    {
        public ProjectPhase()
        {
            Activity = new HashSet<Activity>();
        }

        public int Id { get; set; }
        public int? Projectid { get; set; }
        public string Name { get; set; }
        public string Remarks { get; set; }
        public DateTime? Datecreated { get; set; }
        public DateTime? Datemodified { get; set; }
        public int? Createdbyid { get; set; }
        public int? Modifiedbyid { get; set; }

        public virtual Project Project { get; set; }
        public virtual ICollection<Activity> Activity { get; set; }
    }
}
