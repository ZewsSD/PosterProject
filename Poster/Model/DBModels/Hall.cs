using System;
using System.Collections.Generic;

#nullable disable

namespace Poster.Model.DBModels
{
    public partial class Hall
    {
        public Hall()
        {
            Sessions = new HashSet<Session>();
        }

        public int Id { get; set; }
        public int? PlacesInLine { get; set; }
        public int? CinemaId { get; set; }
        public int? CountLine { get; set; }

        public virtual Cinema Cinema { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
    }
}
