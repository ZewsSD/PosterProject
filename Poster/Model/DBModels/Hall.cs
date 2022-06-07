using System;
using System.Collections.Generic;

#nullable disable

namespace Poster.Model.DBModels
{
    public partial class Hall : IReadOnlyHall
    {
        public int Id { get; private set; }
        public int? PlacesInLine { get; private set; }
        public int? CinemaId { get; private set; }
        public int? CountLine { get; private set; }

        public virtual Cinema Cinema { get; private set; }
        public virtual ICollection<Session> Sessions { get; private set; }

        public Hall(int placesInLine, int cinemaId, int countLine)
        {
            PlacesInLine = placesInLine;
            CinemaId = cinemaId;
            CountLine = countLine;

            Sessions = new HashSet<Session>();
        }

        public void Update(int placesInLine, int cinemaId, int countLine)
        {
            if (placesInLine != -1)
                PlacesInLine = placesInLine;
            if (cinemaId != -1)
                CinemaId = cinemaId;
            if (countLine != -1)
                CountLine = countLine;
        }
    }

    public interface IReadOnlyHall
    {
        public int Id { get; }
        public int? PlacesInLine { get; }
        public int? CinemaId { get; }
        public int? CountLine { get; }
    }
}
