using System;
using System.Collections.Generic;

#nullable disable

namespace Poster.Model.DBModels
{
    public partial class ActorMovie
    {
        public int Id { get; set; }
        public int? ActorId { get; set; }
        public int? MovieId { get; set; }

        public virtual Actor Actor { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
