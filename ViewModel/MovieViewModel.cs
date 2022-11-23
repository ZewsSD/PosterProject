using Poster.Model;
using Poster.Model.DBModels;
using Poster.Model.Tools;
using Poster.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Media;
using static System.Net.Mime.MediaTypeNames;

namespace Poster.ViewModel
{
    class MovieViewModel : INotifyPropertyChanged
    {
        private CommandTemplate _openTicketWindow;
        private Window _window;
        private PosterData _model;
        private Movie _movie;

        public ObservableCollection<Actor> Actors { get; private set; }
        public ObservableCollection<Session> Sessions { get; private set; }
        public ObservableCollection<Hall> Halls { get; private set; }
        public ObservableCollection<Cinema> Cinemas { get; private set; }

        public string Title
        {
            get => _movie.Title;
            set
            {
                OnPropertyChanged(nameof(Title));
            }
        }
        public DateTime? ReleaseDate
        {
            get => _movie.ReleaseDate;
            set
            {
                OnPropertyChanged(nameof(ReleaseDate));
            }
        }
        public string Producer
        {
            get => _movie.Producer;
            set
            {
                OnPropertyChanged(nameof(Producer));
            }
        }
        public string Description
        {
            get => _movie.Description;
            set
            {
                OnPropertyChanged(nameof(Description));
            }
        }
        public double? Rating
        {
            get => _movie.Rating;
            set
            {
                OnPropertyChanged(nameof(Rating));
            }
        }
        public byte[] Picture
        {
            get => _movie.Picture;
            set
            {
                OnPropertyChanged(nameof(Picture));
            }
        }

        public MovieViewModel(Window window, PosterData model, Movie movie)
        {
            _window = window;
            _model = model;
            _movie = movie;
            Actors = new ObservableCollection<Actor>(_model.GetAllActors().Where(actor => _movie.ActorMovies.Count(b => b.ActorId == actor.Id) > 0));
            Sessions = new ObservableCollection<Session>(_model.GetAllSessions().Where(session => session.MovieId == _movie.Id));
            Halls = new ObservableCollection<Hall>(_model.GetAllHalls().Where(hall => hall.Id == Sessions[0].Id));
            Cinemas = new ObservableCollection<Cinema>(_model.GetAllCinemas().Where(cinema => cinema.Id == Halls[0].Id));
        }

        public CommandTemplate CreateTicketWindow
        {
            get
            {
                if (_openTicketWindow == null)
                    _openTicketWindow = new CommandTemplate(AddTicketWindow);
                return _openTicketWindow;
            }
        }

        public void AddTicketWindow(object obj)
        {
            TicketWindow ticketWindow = new TicketWindow();
            TicketViewModel ticketWindowViewModel = new TicketViewModel(_model, _movie);

            ticketWindow.DataContext = ticketWindowViewModel;
            ticketWindow.ShowDialog();
            _window.Show();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
