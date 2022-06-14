using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

#nullable disable

namespace Poster.Model.DBModels
{
    public partial class Cinema : IReadOnlyCinema, INotifyPropertyChanged
    {
        private int _id;
        private TimeSpan? _workTime;
        private string _title;
        private string _address;
        private ICollection<City> _cities;
        private ICollection<Hall> _halls;

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        public TimeSpan? WorkTime
        {
            get => _workTime;
            set
            {
                _workTime = value;
                OnPropertyChanged(nameof(WorkTime));
            }
        }
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        public string Address
        {
            get => _address;
            set
            {
                _address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        public virtual ICollection<City> Cities
        {
            get => _cities;
            set
            {
                _cities = value;
                OnPropertyChanged(nameof(Cities));
            }
        }
        public virtual ICollection<Hall> Halls
        {
            get => _halls;
            set
            {
                _halls = value;
                OnPropertyChanged(nameof(Halls));
            }
        }

        public Cinema(TimeSpan workTime, string title, string address)
        {
            WorkTime = workTime;
            Title = title;
            Address = address;

            Cities = new HashSet<City>();
            Halls = new HashSet<Hall>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = " ") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public void Update(TimeSpan workTime, string title, string address)
        {
            if (workTime != null)
                WorkTime = workTime;
            if (title != null)
                Title = title;
            if (address != null)
                Address = address;
        }

        #region CRUD Hall
        public void AddHall(int placesInLine, int cinemaId, int countLine)
        {
            Hall hall = new Hall(placesInLine, cinemaId, countLine);

            using (PosterDbContext db = new PosterDbContext())
            {
                db.Halls.Add(hall);
                db.SaveChanges();
            }
        }

        public void RemoveHall(int id)
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                Hall hall = db.Halls.FirstOrDefault(x => x.Id == id);

                if (hall != null)
                {
                    db.Halls.Remove(hall);
                    db.SaveChanges();
                }
            }
        }

        public void UpdateHall(int id, int placesInLine = -1, int cinemaId = -1, int countLine = -1)
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                Hall hall = db.Halls.FirstOrDefault(i => i.Id == id);

                hall.Update(placesInLine, cinemaId, countLine);

                db.Halls.Update(hall);
                db.SaveChanges();
            }
        }

        public IReadOnlyList<IReadOnlyHall> GetAllHalls()
        {
            using(PosterDbContext db = new PosterDbContext())
            {
                return db.Halls.ToList();
            }
        }

        public IReadOnlyHall GetHall(int id)
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                return db.Halls.FirstOrDefault(x => x.Id == id);
            }
        }
        #endregion

        #region CRUD Movie
        public void AddMovie(string title, DateTime releaseDate, string producer, string description, double rating, byte[] picture)
        {
            Movie movie = new Movie(title, releaseDate, producer, description, rating, picture);

            using (PosterDbContext db = new PosterDbContext())
            {
                db.Movies.Add(movie);
                db.SaveChanges();
            }
        }

        public void RemoveMovie(int id)
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                Movie movie = db.Movies.FirstOrDefault(x => x.Id == id);

                if (movie != null)
                {
                    db.Movies.Remove(movie);
                    db.SaveChanges();
                }
            }
        }

        public void UpdateMovie(int id, string title = null, DateTime releaseDate = new DateTime(), string producer = null, string description = null, double rating = -1, byte[] picture = null)
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                Movie movie = db.Movies.FirstOrDefault(i => i.Id == id);

                movie.Update(title, releaseDate, producer, description, rating, picture);

                db.Movies.Update(movie);
                db.SaveChanges();
            }
        }

        public IReadOnlyList<IReadOnlyMovie> GetAllMovies()
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                return db.Movies.ToList();
            }
        }

        public IReadOnlyMovie GetMovie(int id)
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                return db.Movies.FirstOrDefault(x => x.Id == id);
            }
        }
        #endregion

        #region CRUD Session
        public void AddSession(DateTime date, int movieId, int hallId)
        {
            Session session = new Session(date, movieId, hallId);

            using(PosterDbContext db = new PosterDbContext())
            {
                db.Sessions.Add(session);
                db.SaveChanges();
            }
        }

        public void RemoveSession(int id)
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                Session session = db.Sessions.FirstOrDefault(x => x.Id == id);

                if (session != null)
                {
                    db.Sessions.Remove(session);
                    db.SaveChanges();
                }
            }
        }

        public void UpdateSession(int id, DateTime date = new DateTime(), int movieId = -1, int hallId = -1)
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                Session session = db.Sessions.FirstOrDefault(i => i.Id == id);

                session.Update(date, movieId, hallId);

                db.Sessions.Update(session);
                db.SaveChanges();
            }
        }

        public IReadOnlyList<IReadOnlySession> GetAllSessions()
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                return db.Sessions.ToList();
            }
        }

        public IReadOnlySession GetSession(int id)
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                return db.Sessions.FirstOrDefault(x => x.Id == id);
            }
        }
        #endregion

        #region CRUD Ticket
        public void AddTicket(int price, int line, int place, int userId, int sessionId)
        {
            Ticket ticket = new Ticket(price, line, place, userId, sessionId);

            using (PosterDbContext db = new PosterDbContext())
            {
                db.Tickets.Add(ticket);
                db.SaveChanges();
            }
        }

        public void RemoveTicket(int id)
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                Ticket ticket = db.Tickets.FirstOrDefault(x => x.Id == id);

                if (ticket != null)
                {
                    db.Tickets.Remove(ticket);
                    db.SaveChanges();
                }
            }
        }

        public void UpdateTicket(int id, int price = -1, int line = -1, int place = -1, int userId = -1, int sessionId = -1)
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                Ticket ticket = db.Tickets.FirstOrDefault(i => i.Id == id);

                ticket.Update(price, line, place, userId, sessionId);

                db.Tickets.Update(ticket);
                db.SaveChanges();
            }
        }

        public IReadOnlyList<IReadOnlyTicket> GetAllTickets()
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                return db.Tickets.ToList();
            }
        }

        public IReadOnlyTicket GetTicket(int id)
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                return db.Tickets.FirstOrDefault(x => x.Id == id);
            }
        }
        #endregion
    }

    public interface IReadOnlyCinema
    {
        public int Id { get; }
        public TimeSpan? WorkTime { get; }
        public string Title { get; }
        public string Address { get; }
    }
}
