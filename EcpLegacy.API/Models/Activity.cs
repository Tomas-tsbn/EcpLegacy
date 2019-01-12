using System;
using System.Collections.Generic;

namespace EcpLegacy.API.Models
{
    public partial class Activity
    {
        public Activity()
        {
            ActivityAssociate = new HashSet<ActivityAssociate>();
        }

        public int Id { get; set; }
        public int? Projectphaseid { get; set; }
        public string Name { get; set; }
        public string Remarks { get; set; }
        public int? Priority { get; set; }
        public int? Responsible { get; set; }
        public int? Plannedhours { get; set; }
        public string Year { get; set; }
        public string Week { get; set; }
        public int? Statusid { get; set; }
        public DateTime? Datecreated { get; set; }
        public DateTime? Datemodified { get; set; }
        public int? Createdbyid { get; set; }
        public int? Modifiedbyid { get; set; }

        public virtual ProjectPhase Projectphase { get; set; }
        public virtual Associate ResponsibleNavigation { get; set; }
        public virtual ActivityStatus Status { get; set; }
        public virtual ICollection<ActivityAssociate> ActivityAssociate { get; set; }
    }
}
