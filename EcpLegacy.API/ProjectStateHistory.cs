using System;
using System.Collections.Generic;

namespace EcpLegacy.API
{
    public partial class ProjectStateHistory
    {
        public int Id { get; set; }
        public int? Projectid { get; set; }
        public int? Projectstateid { get; set; }
        public DateTime? Decisiondate { get; set; }
        public string Remarks { get; set; }
        public int? Documentid { get; set; }
        public DateTime? Datecreated { get; set; }
        public DateTime? Datemodified { get; set; }
        public int? Createdbyid { get; set; }
        public int? Modifiedbyid { get; set; }

        public virtual Project Project { get; set; }
        public virtual ProjectState Projectstate { get; set; }
    }
}
