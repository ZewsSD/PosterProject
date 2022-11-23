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
using System.Windows.Controls;

namespace Poster.ViewModel
{
    class LoginUserVeiwModel : INotifyPropertyChanged
    {
        private CommandTemplate _openPosterWindow;
        private CommandTemplate _getCities;
        private PosterData _model;
        private Window _window;
        private City _selectedCity;
        private City _inputCityData;
        private Cinema _selectedCinema;
        private Cinema _inputCinemaData;

        public ObservableCollection</*IReadOnly*/City> Cities { get; private set; }
        public ObservableCollection</*IReadOnly*/Cinema> Cinemas { get; private set; }

        public City SelectedCity
        {
            get => _selectedCity;
            set
            {
                _selectedCity = value;
                OnPropertyChanged(nameof(SelectedCity));

                if (SelectedCity == null)
                    return;

                InputCityData = new City(SelectedCity.Name, SelectedCity.CinemaId);

                InputCityData.Id = SelectedCity.Id;
                InputCityData.Name = SelectedCity.Name;
                InputCityData.CinemaId = SelectedCity.CinemaId;
                InputCityData.Cinema = SelectedCity.Cinema;
            }
        }

        public City InputCityData
        {
            get => _inputCityData;
            set
            {
                _inputCityData = value;
                OnPropertyChanged(nameof(InputCityData));
            }
        }

        public Cinema SelectedCinema
        {
            get => _selectedCinema;
            set
            {
                _selectedCinema = value;
                OnPropertyChanged(nameof(SelectedCinema));

                if (SelectedCinema == null)
                    return;

                InputCinemaData = new Cinema();

                InputCinemaData.Id = SelectedCinema.Id;
                InputCinemaData.Title = SelectedCinema.Title;
                InputCinemaData.Address = SelectedCinema.Address;
                InputCinemaData.WorkTime = SelectedCinema.WorkTime;
                InputCinemaData.Cities = SelectedCinema.Cities;
                InputCinemaData.Halls = SelectedCinema.Halls;
            }
        }

        public Cinema InputCinemaData
        {
            get => _inputCinemaData;
            set
            {
                _inputCinemaData = value;
                OnPropertyChanged(nameof(InputCinemaData));
            }
        }

        public LoginUserVeiwModel(Window window, PosterData model)
        {
            _window = window;
            _model = model;
            Cities = _model.GetAllCities();
            Cinemas = _model.GetAllCinemas();
        }

        public CommandTemplate CreatePosterWindow
        {
            get
            {
                if (_openPosterWindow == null)
                    _openPosterWindow = new CommandTemplate(AddPosterWindow);
                return _openPosterWindow;
            }

        }

        public CommandTemplate GetCities
        {
            get
            {
                if (_getCities == null)
                {
                    _getCities = new CommandTemplate(obj =>
                    {

                    }
                    );
                }

                return _getCities;
            }
        }

        public void AddPosterWindow(object obj)
        {
            if (_inputCityData != null && _inputCinemaData != null)
            {
                PosterWindow posterWindow = new PosterWindow();
                PosterViewModel posterWindowViewModel = new PosterViewModel(_model, posterWindow);

                _window.Hide();

                posterWindow.DataContext = posterWindowViewModel;
                posterWindow.ShowDialog();
                _window.Close();
            }
            else
            {
                MessageBox.Show("Вы не выбрали город или кинотеатр");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
