using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable

namespace Poster.Model.DBModels
{
    public partial class City : IReadOnlyCity
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int? CinemaId { get; private set; }

        public virtual Cinema Cinema { get; private set; }

        public City(string name, int cinemaId)
        {
            Name = name;
            CinemaId = cinemaId;
        }

        public void Update(string name, int cinemaId)
        {
            if (name != null)
                Name = name;
            if (cinemaId != -1)
                CinemaId = cinemaId;
        }

        public void AddCinema(TimeSpan workTime, string title, string address)
        {
            Cinema cinema = new Cinema(workTime, title, address);

            using (PosterDbContext db = new PosterDbContext())
            {
                db.Cinemas.Add(cinema);
                db.SaveChanges();
            }
        }

        public void RemoveCinema(int id)
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                Cinema cinema = db.Cinemas.FirstOrDefault(x => x.Id == id);

                if (cinema != null)
                {
                    db.Cinemas.Remove(cinema);
                    db.SaveChanges();
                }
            }
        }

        public void UpdateCinema(int id, TimeSpan workTime = new TimeSpan(), string title = null, string address = null)
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                Cinema cinema = db.Cinemas.FirstOrDefault(i => i.Id == id);

                cinema.Update(workTime, title, address);

                db.Cinemas.Update(cinema);
                db.SaveChanges();
            }
        }

        public IReadOnlyList<IReadOnlyCinema> GetAllCinemas()
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                return db.Cinemas.ToList();
            }
        }

        public IReadOnlyCinema GetCinema(int id)
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                return db.Cinemas.FirstOrDefault(x => x.Id == id);
            }
        }
    }

    public interface IReadOnlyCity
    {
        public int Id { get; }
        public string Name { get; }
        public int? CinemaId { get; }
    }
}
