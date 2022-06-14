using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

#nullable disable

namespace Poster.Model.DBModels
{
    public partial class Actor : IReadOnlyActor
    {
        private int _id;
        private string _name;
        private string _surname;
        private string _patronomic;
        private ICollection<ActorMovie> _actorMovies;

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
        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }
        public string Patronymic
        {
            get => _patronomic;
            set
            {
                _patronomic = value;
                OnPropertyChanged(nameof(Patronymic));
            }
        }

        public virtual ICollection<ActorMovie> ActorMovies
        {
            get => _actorMovies;
            set
            {
                _actorMovies = value;
                OnPropertyChanged(nameof(ActorMovies));
            }
        }

        public Actor(string name, string surname, string patronomic)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronomic;

            ActorMovies = new HashSet<ActorMovie>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = " ") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public void Update(string name, string surname, string patronomic)
        {
            if (name != null)
                Name = name;
            if (surname != null)
                Surname = surname;
            if (patronomic != null)
                Patronymic = patronomic;
        }
    }

    public interface IReadOnlyActor
    {
        public int Id { get; }
        public string Name { get; }
        public string Surname { get; }
        public string Patronymic { get; }
    }
}
