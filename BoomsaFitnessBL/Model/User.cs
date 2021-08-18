using System;

namespace BoomsaFitnessBL.Model
{
    /// <summary>
    /// Пользователь
    /// </summary>
    [Serializable]
    public class User
    {
        #region Свойства
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Пол
        /// </summary>
        public Gender Gender { get; }
        /// <summary>
        /// Дата рождений 
        /// </summary>
        public DateTime BirthDate { get; }
        /// <summary>
        /// Вес
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Рост
        /// </summary>
        public double Height { get; set; }
        /// <summary>
        /// Создание нового пользователы
        /// </summary>
        /// <param name="name"> Имя пользователя</param>
        /// <param name="gender"> Пол </param>
        /// <param name="birthDate"> Дата рождения</param>
        /// <param name="weight"> Вес </param>
        /// <param name="height"> Рост </param>
        #endregion
        public User(string name,
                    Gender gender,
                    DateTime birthDate,
                    double weight,
                    double hight)
        {
            #region Проверка условий
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым", nameof(name));
            }
            if (gender == null)
            {
                throw new ArgumentNullException("Гендер не может быть Null", nameof(gender));
            }
            if (birthDate < DateTime.Parse("01.01.1900") || birthDate > DateTime.Now)
            {
                throw new ArgumentException("Дата рождения не может быть выходить за пределы 1900<дата<now", nameof(birthDate));
            }
            if (weight <= 0)
            {
                throw new ArgumentException("Вес не может быть <=0", nameof(weight));
            }
            if (hight <= 0)
            {
                throw new ArgumentException("Вес не может быть меньше 0", nameof(hight));
            }
            #endregion
            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = hight;
        }
        public override string ToString()
        {
            return Name; 
        }
    }
}
