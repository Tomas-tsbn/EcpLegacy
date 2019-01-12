using System;
using System.Collections.Generic;

namespace EcpLegacy.API
{
    public partial class ActivityAssociate
    {
        public int Id { get; set; }
        public int? Activityid { get; set; }
        public int? Associateid { get; set; }
        public int? Plannedhours { get; set; }
        public int? Workedhours { get; set; }
        public DateTime? Datecreated { get; set; }
        public DateTime? Datemodified { get; set; }
        public int? Createdbyid { get; set; }
        public int? Modifiedbyid { get; set; }

        public virtual Activity Activity { get; set; }
        public virtual Associate Associate { get; set; }
    }
}
