using Poster.Model.DBModels;
using Poster.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Printing;
using System.Security.Cryptography;
using System.Numerics;

namespace Poster.ViewModel
{
    class TicketViewModel : INotifyPropertyChanged
    {
        private IReadOnlyMovie _movie;
        private PosterData _model;
        private ObservableCollection<Hall> _halls;
        private Hall _hall;
        private ObservableCollection<Ticket> _tickets;
        private LineViewModel _ticketViewModels;

        public ObservableCollection<HallButton> HallButtons { get; private set; }
        public ObservableCollection<PlaceViewModel> Places { get; private set; }

        public LineViewModel TicketViewModels
        {
            get => _ticketViewModels;
            set
            {
                _ticketViewModels = value;
                OnPropertyChanged(nameof(TicketViewModels));
            }
        }

        public TicketViewModel(PosterData model, Movie movie)
        {
            _movie = movie;
            _model = model;
            _halls = new ObservableCollection<Hall>(_model.GetAllHalls());
            _hall = _halls[0];
            HallButtons = new ObservableCollection<HallButton>();

            foreach (var hall in _halls)
            {
                HallButtons.Add(new HallButton(hall));
            }

            _tickets = new ObservableCollection<Ticket>(_model.GetAllTickets());
            TicketViewModels = new LineViewModel((int)_hall.CountLine, (int)_hall.PlacesInLine, _tickets);
            List<PlaceViewModel> places = new List<PlaceViewModel>();

            for (int i = 0; i < TicketViewModels.Places.Count; i++)
            {
                places.Add(TicketViewModels.Places[i]);
            }

            Places = new ObservableCollection<PlaceViewModel>(places);
        }

        public string Title
        {
            get => _movie.Title;
        }

        public byte[] Picture
        {
            get => _movie.Picture;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    class HallButton
    {
        private Hall _hall;

        public HallButton(Hall hall)
        {
            _hall = hall;
        }

        public int? PlacesInLine
        {
            get => _hall.PlacesInLine;
        }
        public int? CountLine
        {
            get => _hall.CountLine;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    class TicketButton
    {
        private Ticket _ticket;

        public int? Price
        {
            get => _ticket.Price;
        }
        public int? Line
        {
            get => _ticket.Line;
        }
        public int? Place
        {
            get => _ticket.Place;
        }

        public TicketButton(Ticket ticket)
        {
            _ticket = ticket;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    class LineViewModel
    {
        private List<PlaceViewModel> _places;

        public List<PlaceViewModel> Places
        {
            get => _places;
            set
            {
                _places = value;
                OnPropertyChanged(nameof(Places));
            }
        }

        public LineViewModel(int countLine, int countPlaceInLine, ObservableCollection<Ticket> tickets)
        {
            _places = new List<PlaceViewModel>();
            Ticket[] tempTickets = new Ticket[countPlaceInLine];

            for (int i = 0; i < countLine; i++)
            {
                for (int j = 0; j < tempTickets.Length; j++)
                {
                    if (tickets.Count > j)
                    {
                        if (tickets[j].Line == i + 1)
                        {
                            tempTickets[(int)tickets[j].Place - 1] = tickets[j];
                        }
                    }
                }

                _places.Add(new PlaceViewModel(countPlaceInLine, tempTickets));
                tempTickets = new Ticket[countPlaceInLine];
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    class PlaceViewModel
    {
        private List<TicketButton> _tickets;

        public List<TicketButton> Tickets
        {
            get => _tickets;
            set
            {
                _tickets = value;
                OnPropertyChanged(nameof(Tickets));
            }
        }

        public PlaceViewModel(int countPlaceInLine, Ticket[] tickets)
        {
            _tickets = new List<TicketButton>();

            for (int i = 0; i < countPlaceInLine; i++)
            {
                if (tickets[i] != null)
                    _tickets.Add(new TicketButton(tickets[i]));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
