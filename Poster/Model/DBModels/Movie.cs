using System;
using System.Collections.Generic;

#nullable disable

namespace Poster.Model.DBModels
{
    public partial class Movie : IReadOnlyMovie
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public DateTime? ReleaseDate { get; private set; }
        public string Producer { get; private set; }
        public string Description { get; private set; }
        public double? Rating { get; private set; }
        public byte[] Picture { get; private set; }

        public virtual ICollection<ActorMovie> ActorMovies { get; private set; }
        public virtual ICollection<Session> Sessions { get; private set; }

        public Movie(string title, DateTime releaseDate, string producer, string description, double rating, byte[] picture)
        {
            Title = title;
            ReleaseDate = releaseDate;
            Producer = producer;
            Description = description;
            Rating = rating;
            Picture = picture;

            ActorMovies = new HashSet<ActorMovie>();
            Sessions = new HashSet<Session>();
        }

        public void Update(string title, DateTime releaseDate, string producer, string description, double rating, byte[] picture)
        {
            if (title != null)
                Title = title;
            if (releaseDate != null)
                ReleaseDate = releaseDate;
            if (producer != null)
                Producer = producer;
            if (description != null)
                Description = description;
            if (rating != -1)
                Rating = rating;
            if (picture != null)
                Picture = picture;
        }
    }

    public interface IReadOnlyMovie
    {
        public int Id { get; }
        public string Title { get; }
        public DateTime? ReleaseDate { get; }
        public string Producer { get; }
        public string Description { get; }
        public double? Rating { get; }
        public byte[] Picture { get; }
    }
}
