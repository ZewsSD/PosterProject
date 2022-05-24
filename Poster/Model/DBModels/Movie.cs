using System;
using System.Collections.Generic;

#nullable disable

namespace Poster.Model.DBModels
{
    public partial class Movie
    {
        public Movie()
        {
            ActorMovies = new HashSet<ActorMovie>();
            Sessions = new HashSet<Session>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Producer { get; set; }
        public string Description { get; set; }
        public double? Rating { get; set; }
        public byte[] Picture { get; set; }

        public virtual ICollection<ActorMovie> ActorMovies { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
    }
}
