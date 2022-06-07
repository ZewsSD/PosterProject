using System;
using System.Collections.Generic;

#nullable disable

namespace Poster.Model.DBModels
{
    public partial class Ticket : IReadOnlyTicket
    {
        public int Id { get; private set; }
        public int? SessionId { get; private set; }
        public int? Price { get; private set; }
        public int? Line { get; private set; }
        public int? Place { get; private set; }
        public int? UserId { get; private set; }

        public virtual Session Session { get; private set; }
        public virtual User User { get; private set; }

        public Ticket(int price, int line, int place, int userId, int sessionId)
        {
            Price = price;
            Line = line;
            Place = place;
            UserId = userId;
            SessionId = sessionId;
        }

        public void Update(int price, int line, int place, int userId, int sessionId)
        {
            if (price != -1)
                Price = price;
            if (line != -1)
                Line = line;
            if (place != -1)
                Place = place;
            if (userId != -1)
                UserId = userId;
            if (sessionId != -1)
                SessionId = sessionId;
        }
    }

    public interface IReadOnlyTicket
    {
        public int Id { get; }
        public int? SessionId { get; }
        public int? Price { get; }
        public int? Line { get; }
        public int? Place { get; }
        public int? UserId { get; }
    }
}
