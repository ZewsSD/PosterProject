using System;
using System.Collections.Generic;

#nullable disable

namespace Poster.Model.DBModels
{
    public partial class Session : IReadOnlySession
    {
        public int Id { get; private set; }
        public int? MovieId { get; private set; }
        public DateTime? Date { get; private set; }
        public int? HallId { get; private set; }

        public virtual Hall Hall { get; private set; }
        public virtual Movie Movie { get; private  set; }
        public virtual ICollection<Ticket> Tickets { get; private set; }

        public Session(DateTime date, int movieId, int hallId)
        {
            Date = date;
            MovieId = movieId;
            HallId = hallId;

            Tickets = new HashSet<Ticket>();
        }

        public void Update(DateTime date, int movieId, int hallId)
        {
            if (date != null)
                Date = date;
            if (movieId != -1)
                MovieId = movieId;
            if (hallId != -1)
                HallId = hallId;
        }
    }

    public interface IReadOnlySession
    {
        public int Id { get; }
        public int? MovieId { get; }
        public DateTime? Date { get; }
        public int? HallId { get; }
    }
}
