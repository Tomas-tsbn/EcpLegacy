using System;
using System.Collections.Generic;

namespace EcpLegacy.API.Models
{
    public partial class Associate
    {
        public Associate()
        {
            Activity = new HashSet<Activity>();
            ActivityAssociate = new HashSet<ActivityAssociate>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public byte[] Password { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Frendlyname { get; set; }
        public string Email { get; set; }
        public DateTime? Datecreated { get; set; }
        public DateTime? Datemodified { get; set; }
        public int? Createdbyid { get; set; }
        public int? Modifiedbyid { get; set; }
        public string Accesskey { get; set; }

        public virtual ICollection<Activity> Activity { get; set; }
        public virtual ICollection<ActivityAssociate> ActivityAssociate { get; set; }
    }
}
