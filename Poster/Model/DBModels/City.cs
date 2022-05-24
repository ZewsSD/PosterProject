using System;
using System.Collections.Generic;

#nullable disable

namespace Poster.Model.DBModels
{
    public partial class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CinemaId { get; set; }

        public virtual Cinema Cinema { get; set; }
    }
}
