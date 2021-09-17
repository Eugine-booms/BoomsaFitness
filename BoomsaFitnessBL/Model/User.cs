using System;
using System.Collections.Generic;

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
        public string Name { get; set; }
        /// <summary>
        /// Пол
        /// </summary>
       

        /// <summary>
        /// Дата рождений 
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Вес
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Рост
        /// </summary>
        public double Height { get; set; }
        public int Age
        {
            get
            {
                int age = DateTime.Today.Year - BirthDate.Year;
                if (BirthDate > DateTime.Today.AddYears(-age))
                {
                    age--;
                }
                return age;
            }
        }
        /// <summary>
        /// Создание нового пользователы
        /// </summary>
        /// <param name="name"> Имя пользователя</param>
        /// <param name="gender"> Пол </param>
        /// <param name="birthDate"> Дата рождения</param>
        /// <param name="weight"> Вес </param>
        /// <param name="height"> Рост </param>
        #endregion
       
        public int Id { get; set; }
        public int GenderId { get; set; }
        public virtual Gender Gender { get; set; }
        public User()
        {
        }

        public ICollection<Eating> Eatings { get; set; }
        public ICollection<Exercise> Exercises { get; set; }


        ////////For Entity
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="gender"></param>
        /// <param name="birthDate"></param>
        /// <param name="weight"></param>
        /// <param name="hight"></param>
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
        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым", nameof(name));
            }
            Name = name;
        }

        public override string ToString()
        {
            return Name + " " + Age;
        }

        public override int GetHashCode()
        {
            int hashCode = -421562316;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + BirthDate.GetHashCode();
            hashCode = hashCode * -1521134295 + Weight.GetHashCode();
            hashCode = hashCode * -1521134295 + Height.GetHashCode();
            hashCode = hashCode * -1521134295 + Age.GetHashCode();
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + GenderId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Gender>.Default.GetHashCode(Gender);
            hashCode = hashCode * -1521134295 + EqualityComparer<ICollection<Eating>>.Default.GetHashCode(Eatings);
            hashCode = hashCode * -1521134295 + EqualityComparer<ICollection<Exercise>>.Default.GetHashCode(Exercises);
            return hashCode;
        }

        public override bool Equals(object obj)
        {
            if (GetHashCode()!=obj.GetHashCode())
            {
                return false;
            } 
            return obj is User user &&
                   Name == user.Name;
        }
        public User Clon()
        {
            return MemberwiseClone() as User;
        }
        public static bool operator ==(User user, User user1)
        {
            return user.Equals(user1);
        }
        public static bool operator !=(User user, User user1)
        {
            return user.Equals(user1);
        }
    }
}
