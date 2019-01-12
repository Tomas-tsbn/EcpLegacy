using System;
using System.Collections.Generic;

namespace EcpLegacy.API.Models
{
    public partial class ActivityStatus
    {
        public ActivityStatus()
        {
            Activity = new HashSet<Activity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Remarks { get; set; }
        public DateTime? Datecreated { get; set; }
        public DateTime? Datemodified { get; set; }
        public int? Createdbyid { get; set; }
        public int? Modifiedbyid { get; set; }

        public virtual ICollection<Activity> Activity { get; set; }
    }
}
