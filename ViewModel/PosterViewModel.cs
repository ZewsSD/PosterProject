using Poster.Model;
using Poster.Model.DBModels;
using Poster.Model.Tools;
using Poster.View;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;

namespace Poster.ViewModel
{
    class PosterViewModel : INotifyPropertyChanged
    {
        private Movie _selectedMovie;
        private PosterData _model;
        private ObservableCollection<Movie> _movies;
        private Window _window;
        public ObservableCollection<PosterMovieViewModel> PosterMovies { get; private set; }

        public PosterViewModel(PosterData model, Window window)
        {
            _model = model;
            _movies = new ObservableCollection<Movie>(_model.GetAllMovies());
            _window = window;

            PosterMovies = new ObservableCollection<PosterMovieViewModel>();

            foreach (var movie in _movies)
            {
                PosterMovies.Add(new PosterMovieViewModel(_window, _model, movie));
            }
        }

        public Movie SelectedMovie
        {
            get => _selectedMovie;
            set
            {
                _selectedMovie = value;
                OnPropertyChanged(nameof(SelectedMovie));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    class PosterMovieViewModel
    {
        private CommandTemplate _openMovieWindow;
        private Window _window;
        private PosterData _model;
        private Movie _movie;

        public int Id
        {
            get => _movie.Id;
            set
            {
                OnPropertyChanged(nameof(Id));
            }
        }

        public string Title
        {
            get => _movie.Title;
            set
            {
                OnPropertyChanged(nameof(Title));
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

        public PosterMovieViewModel(Window window, PosterData model, Movie movie)
        {
            _window = window;
            _movie = movie;
            _model = model;
        }

        public CommandTemplate OpenMovieWindow
        {
            get
            {
                if (_openMovieWindow == null)
                    _openMovieWindow = new CommandTemplate(AddMovieWindow);
                return _openMovieWindow;
            }
        }

        public void AddMovieWindow(object obj)
        {
            MovieWindow movieWindow = new MovieWindow();
            MovieViewModel movieViewModel = new MovieViewModel(movieWindow, _model, _movie);

            _window.Hide();

            movieWindow.DataContext = movieViewModel;
            movieWindow.ShowDialog();

            _window.Show();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
