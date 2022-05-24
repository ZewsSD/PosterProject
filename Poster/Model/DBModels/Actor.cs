using System;
using System.Collections.Generic;

#nullable disable

namespace Poster.Model.DBModels
{
    public partial class Actor
    {
        public Actor()
        {
            ActorMovies = new HashSet<ActorMovie>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }

        public virtual ICollection<ActorMovie> ActorMovies { get; set; }
    }
}
