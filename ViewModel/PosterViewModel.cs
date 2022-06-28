using Poster.Model;
using Poster.Model.DBModels;
using Poster.Model.Tools;
using Poster.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;

namespace Poster.ViewModel
{
    class PosterViewModel : INotifyPropertyChanged
    {
        private Movie _selectedMovie;
        private Movie _inputMovieData;
        private PosterData _model;
        private CommandTemplate _openMovieWindow;
        private Window _window;

        public ObservableCollection<IReadOnlyMovie> Movies { get; private set; }

        public Movie SelectedMovie
        {
            get => _selectedMovie;
            set
            {
                _selectedMovie = value;
                OnPropertyChanged(nameof(SelectedMovie));

                if (SelectedMovie == null)
                    return;

                InputMovieData.Id = SelectedMovie.Id;
                InputMovieData.Title = SelectedMovie.Title;
                InputMovieData.ReleaseDate = SelectedMovie.ReleaseDate;
                InputMovieData.Producer = SelectedMovie.Producer;
                InputMovieData.Description = SelectedMovie.Description;
                InputMovieData.Rating = SelectedMovie.Rating;
                InputMovieData.Picture = SelectedMovie.Picture;
            }
        }

        public Movie InputMovieData
        {
            get => _inputMovieData;
            set
            {
                _inputMovieData = value;
                OnPropertyChanged(nameof(SelectedMovie));
            }
        }

        public PosterViewModel(Window window)
        {
            _window = window;
            Movies = new ObservableCollection<IReadOnlyMovie>(_model.GetAllMovies());
            InputMovieData = null;
        }

        public CommandTemplate CreateMovieWindow
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
            MovieViewModel movieViewModel = new MovieViewModel(movieWindow);

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
