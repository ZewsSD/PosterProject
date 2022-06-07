using System;
using System.Collections.Generic;

#nullable disable

namespace Poster.Model.DBModels
{
    public partial class Actor : IReadOnlyActor
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Patronymic { get; private set; }

        public virtual ICollection<ActorMovie> ActorMovies { get; private set; }

        public Actor(string name, string surname, string patronomic)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronomic;

            ActorMovies = new HashSet<ActorMovie>();
        }

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
