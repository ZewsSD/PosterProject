using Poster.Model.DBModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Poster.Model
{
    class PosterData
    {
        public PosterData()
        {

        }

        #region CRUD City
        public void AddCity(string name, int cinemaId)
        {
            City city = new City(name, cinemaId);

            using (PosterDbContext db = new PosterDbContext())
            {
                db.Cities.Add(city);
                db.SaveChanges();
            }
        }

        public void RemoveCity(int id)
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                City city = db.Cities.FirstOrDefault(x => x.Id == id);

                if (city != null)
                {
                    db.Cities.Remove(city);
                    db.SaveChanges();
                }
            }
        }

        public void UpdateCity(int id, string name = null, int cinemaId = -1)
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                City city = db.Cities.FirstOrDefault(x => x.Id == id);

                city.Update(name, cinemaId);

                db.Cities.Remove(city);
                db.SaveChanges();
            }
        }

        public IReadOnlyList<IReadOnlyCity> GetAllCities()
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                return db.Cities.ToList();
            }
        }

        public IReadOnlyCity GetCity(int id)
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                return db.Cities.FirstOrDefault(x => x.Id == id);
            }
        }
        #endregion

        #region CRUD Cinema
        public void AddCinema(int cityId, TimeSpan workTime, string title, string address)
        {
            City city = (City)GetCity(cityId);

            city.AddCinema(workTime, title, address);
        }

        public void RemoveCinema(int cityId, int cinemaId)
        {
            City city = (City)GetCity(cityId);

            city.RemoveCinema(cinemaId);
        }

        public void UpdateCinema(int cityId, int cinemaId, TimeSpan workTime, string title = null, string address = null)
        {
            City city = (City)GetCity(cityId);

            city.UpdateCinema(cinemaId, workTime, title, address);
        }

        public IReadOnlyList<IReadOnlyCinema> GetAllCinemas(int cityId)
        {
            City city = (City)GetCity(cityId);

            return city.GetAllCinemas();
        }

        public IReadOnlyCinema GetCinema(int cityId, int cinemaId)
        {
            City city = (City)GetCity(cityId);

            return city.GetCinema(cinemaId);
        }
        #endregion

        #region CRUD Hall
        public void AddHall(int cityId, int cinemaId, int placesLine, int countLine)
        {
            Cinema cinema = (Cinema)GetCinema(cityId ,cinemaId);

            cinema.AddHall(placesLine, cinemaId, countLine);
        }

        public void RemoveHall(int cityId, int cinemaId, int hallId)
        {
            Cinema cinema = (Cinema)GetCinema(cityId, cinemaId);

            cinema.RemoveHall(hallId);
        }

        public void UpdateHall(int cityId, int cinemaId, int hallId, int placesInLine, int countLine)
        {
            Cinema cinema = (Cinema)GetCinema(cityId, cinemaId);

            cinema.UpdateHall(hallId, placesInLine, cinemaId, countLine);
        }

        public IReadOnlyList<IReadOnlyHall> GetAllHalls(int cityId, int cinemaId)
        {
            Cinema cinema = (Cinema)GetCinema(cityId, cinemaId);

            return cinema.GetAllHalls();
        }

        public IReadOnlyHall GetHall(int cityId, int cinemaId, int hallId)
        {
            Cinema cinema = (Cinema)GetCinema(cityId, cinemaId);

            return cinema.GetHall(hallId);
        }
        #endregion

        #region CRUD Session
        public void AddSession(int cityId, int cinemaId, DateTime date, int movieId, int hallId)
        {
            Cinema cinema = (Cinema)GetCinema(cityId, cinemaId);

            cinema.AddSession(date, movieId, hallId);
        }

        public void RemoveSession(int cityId, int cinemaId, int sessionId)
        {
            Cinema cinema = (Cinema)GetCinema(cityId, cinemaId);

            cinema.RemoveSession(sessionId);
        }

        public void UpdateSession(int cityId, int cinemaId, int sessionId, DateTime date, int movieId,int hallId)
        {
            Cinema cinema = (Cinema)GetCinema(cityId, cinemaId);

            cinema.UpdateSession(sessionId, date, movieId, hallId);
        }

        public IReadOnlyList<IReadOnlySession> GetAllSessions(int cityId, int cinemaId)
        {
            Cinema cinema = (Cinema)GetCinema(cityId, cinemaId);

            return cinema.GetAllSessions();
        }

        public IReadOnlySession GetSession(int cityId, int cinemaId, int sessionId)
        {
            Cinema cinema = (Cinema)GetCinema(cityId, cinemaId);

            return cinema.GetSession(sessionId);
        }
        #endregion

        #region CRUD Movie
        public void AddMovie(int cityId, int cinemaId, string title, DateTime releseDate, string producer, string description, double rating, byte[] picture)
        {
            Cinema cinema = (Cinema)GetCinema(cityId, cinemaId);

            cinema.AddMovie(title, releseDate, producer, description, rating, picture);
        }

        public void RemoveMovie(int cityId, int cinemaId, int movieId)
        {
            Cinema cinema = (Cinema)GetCinema(cityId, cinemaId);

            cinema.RemoveMovie(movieId);
        }

        public void UpdateMovie(int cityId, int cinemaId, int movieId, string title, DateTime releseDate, string producer, string description, double rating, byte[] picture)
        {
            Cinema cinema = (Cinema)GetCinema(cityId, cinemaId);

            cinema.UpdateMovie(movieId, title, releseDate, producer, description, rating, picture);
        }

        public IReadOnlyList<IReadOnlyMovie> GetAllMovies(int cityId, int cinemaId)
        {
            Cinema cinema = (Cinema)GetCinema(cityId, cinemaId);

            return cinema.GetAllMovies();
        }

        public IReadOnlyMovie GetMovie(int cityId, int cinemaId, int movieId)
        {
            Cinema cinema = (Cinema)GetCinema(cityId, cinemaId);

            return cinema.GetMovie(movieId);
        }
        #endregion

        #region CRUD Ticket
        public void AddTicket(int cityId, int cinemaId, int price, int line, int place, int userId,int sessionId)
        {
            Cinema cinema = (Cinema)GetCinema(cityId, cinemaId);

            cinema.AddTicket(price, line, place, userId, sessionId);
        }

        public void RemoveTicket(int cityId, int cinemaId, int ticketId)
        {
            Cinema cinema = (Cinema)GetCinema(cityId, cinemaId);

            cinema.RemoveTicket(ticketId);
        }

        public void UpdateTicket(int cityId, int cinemaId, int ticketId, int price, int line, int place, int userId, int sessionId)
        {
            Cinema cinema = (Cinema)GetCinema(cityId, cinemaId);

            cinema.UpdateTicket(ticketId, price, line, place, userId, sessionId);
        }

        public IReadOnlyList<IReadOnlyTicket> GetAllTickets(int cityId, int cinemaId)
        {
            Cinema cinema = (Cinema)GetCinema(cityId, cinemaId);

            return cinema.GetAllTickets();
        }

        public IReadOnlyTicket GetTicket(int cityId, int cinemaId, int ticketId)
        {
            Cinema cinema = (Cinema)GetCinema(cityId, cinemaId);

            return cinema.GetTicket(ticketId);
        }
        #endregion

        #region CRUD User
        public void AddUser(string name, string surname, int phoneNumber)
        {
            User user = new User(name, surname, phoneNumber);

            using(PosterDbContext db = new PosterDbContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public void RemoveUser(int id)
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                User user = db.Users.FirstOrDefault(x => x.Id == id);

                db.Users.Remove(user);
                db.SaveChanges();
            }
        }

        public void UpdateUser(int id, string name = null, string surname = null, int phoneNumber = -1)
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                User user = db.Users.FirstOrDefault(x => x.Id == id);
                user.Update(name, surname , phoneNumber);

                db.Users.Remove(user);
                db.SaveChanges();
            }
        }

        public IReadOnlyList<IReadOnlyUser> GetAllUsers()
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                return db.Users.ToList();
            }
        }

        public IReadOnlyUser GetUser(int id)
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                return db.Users.FirstOrDefault(x => x.Id == id);
            }
        }
        #endregion

        #region CRUD Actor
        public void AddActor(string name, string surname, string patronomic)
        {
            Actor actor = new Actor(name, surname , patronomic);

            using (PosterDbContext db = new PosterDbContext())
            {
                db.Actors.Add(actor);
                db.SaveChanges();
            }
        }

        public void RemoveActor(int id)
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                Actor actor = db.Actors.FirstOrDefault(x => x.Id == id);

                db.Actors.Remove(actor);
                db.SaveChanges();
            }
        }

        public void UpdateActor(int id, string name = null, string surname = null, string patronomic = null)
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                Actor actor = db.Actors.FirstOrDefault(x => x.Id == id);
                actor.Update(name, surname, patronomic);

                db.Actors.Remove(actor);
                db.SaveChanges();
            }
        }

        public IReadOnlyList<IReadOnlyActor> GetAllActors()
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                return db.Actors.ToList();
            }
        }

        public IReadOnlyActor GetActor(int id)
        {
            using (PosterDbContext db = new PosterDbContext())
            {
                return db.Actors.FirstOrDefault(x => x.Id == id);
            }
        }
        #endregion
    }
}
