﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

#nullable disable

namespace Poster.Model.DBModels
{
    public partial class City : IReadOnlyCity, INotifyPropertyChanged
    {
        private int _id;
        private string _name;
        private int? _cinemaId;
        private Cinema _cinema;

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public int? CinemaId
        {
            get => _cinemaId;
            set
            {
                _cinemaId = value;
                OnPropertyChanged(nameof(CinemaId));
            }
        }

        public virtual Cinema Cinema
        {
            get => _cinema;
            set
            {
                _cinema = value;
                OnPropertyChanged(nameof(Cinema));
            }
        }

        public City(string name, int cinemaId)
        {
            Name = name;
            CinemaId = cinemaId;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = " ") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

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
