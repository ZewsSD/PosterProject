using System;
using System.Collections.Generic;

#nullable disable

namespace Poster.Model.DBModels
{
    public partial class Cinema
    {
        public Cinema()
        {
            Cities = new HashSet<City>();
            Halls = new HashSet<Hall>();
        }

        public int Id { get; set; }
        public TimeSpan? WorkTime { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }

        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<Hall> Halls { get; set; }
    }
}
