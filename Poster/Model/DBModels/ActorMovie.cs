using System;
using System.Collections.Generic;

#nullable disable

namespace Poster.Model.DBModels
{
    public partial class ActorMovie : IReadOnlyActorMovie
    {
        public int Id { get; private set; }
        public int? ActorId { get; private set; }
        public int? MovieId { get; private set; }

        public virtual Actor Actor { get; set; }
        public virtual Movie Movie { get; set; }
        
        public ActorMovie(int actorId, int movieId)
        {
            ActorId = actorId;
            MovieId = movieId;
        }

        public void Update(int actorId, int movieId)
        {
            if (actorId != -1)
                ActorId = actorId;
            if (movieId != -1)
                MovieId = movieId;
        }
    }

    public interface IReadOnlyActorMovie
    {
        public int Id { get; }
        public int? ActorId { get; }
        public int? MovieId { get; }
    }
}
