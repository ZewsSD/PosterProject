using Poster.Model.Tools;
using Poster.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;

namespace Poster.ViewModel
{
    class LoginUserVeiwModel : INotifyPropertyChanged
    {
        private CommandTemplate _openPosterWindow;
        private Window _window;

        public LoginUserVeiwModel(Window window)
        {
            _window = window;
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

        public void AddPosterWindow(object obj)
        {
            PosterWindow posterWindow = new PosterWindow();
            PosterViewModel posterWindowViewModel = new PosterViewModel(posterWindow);

            _window.Hide();

            posterWindow.DataContext = posterWindowViewModel;
            posterWindow.ShowDialog();
            _window.Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
