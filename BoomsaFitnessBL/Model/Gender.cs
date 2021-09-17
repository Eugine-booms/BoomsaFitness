using System;
using System.Collections.Generic;

namespace BoomsaFitnessBL.Model
{/// <summary>
/// Пол
/// </summary>
    [Serializable]
    public class Gender
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пола не может быть пустым или null", nameof(name));
            }

            Name = name;
        }

        public Gender()
        {
        }

        public override string ToString()
        {
            return Name;
        }
    }
}