using System;
using System.Collections.Generic;

#nullable disable

namespace Poster.Model.DBModels
{
    public partial class Ticket
    {
        public int Id { get; set; }
        public int? SessionId { get; set; }
        public int? Price { get; set; }
        public int? Line { get; set; }
        public int? Place { get; set; }
        public int? UserId { get; set; }

        public virtual Session Session { get; set; }
        public virtual User User { get; set; }
    }
}
