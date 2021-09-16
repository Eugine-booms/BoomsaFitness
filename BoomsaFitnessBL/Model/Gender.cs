using System;
using System.Collections.Generic;

namespace BoomsaFitnessBL.Model
{/// <summary>
/// Пол
/// </summary>
    [Serializable]
    public class Gender
    {
        public string Name { get; }
        /// <summary>
        /// Создание нового гендера
        /// </summary>
        /// <param name="Name">Имя пола</param>


        ////////For Entity
        public int Id { get; set; }
        
        public Gender()
        {
        }
        public virtual ICollection<User> Users { get; set; }

        ////////For Entity
        public Gender (string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пола не может быть пустым или null", nameof(Gender.Name));
            }
            this.Name = name;
            
        }

        

        public override string ToString()
        {
            return Name;
        }
    }
}