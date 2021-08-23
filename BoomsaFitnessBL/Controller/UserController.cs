using BoomsaFitnessBL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace BoomsaFitnessBL.Controller
{
    /// <summary>
    /// Контроллер пользователя
    /// </summary>
    public class UserController
    {
        public User CurentUser { get; private set; }
        public List <User> Users { get; }
        /// <summary>
        /// Создание нового контроллера пользователя
        /// </summary>
        /// <param name="user">Пользователь</param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым", nameof(userName));
            }
            Users = GetUsersData();
            CurentUser = Users.SingleOrDefault(u => u.Name == userName);
            if (CurentUser==null)
            {
                CurentUser = new User(userName);
                Users.Add(CurentUser);
                Save();
            }
        }
        public void CreateNewUser(string genderName, DateTime birthDate, double weight = 1, double height=1)
        {
            //TODO Проверка
            CurentUser.Gender = new Gender(genderName);
            CurentUser.BirthDate = birthDate;
            CurentUser.Weight = weight;
            CurentUser.Height = height;
            Save();

            //string str;
            //do
            //{
            //    Console.WriteLine("Пользователь не найден. Создать нового? д/н");
            //    str = Console.ReadLine();
            //} while (!"ДднН".Contains(str));
            //if ("Дд".Contains(str))
            //{
            //    Console.WriteLine("Введите пол");
            //    var gender = Console.ReadLine();
            //    DateTime birthDate =ParseDateTime();
            //    var weght = ParseDouble("Вес");
            //    var hight = ParseDouble("Рост");
            //    CurentUser= new User(userName, new Gender(gender), birthDate, weght, hight);
            //    this.Users.Add(CurentUser);
            //    Save();
            //    if (CurentUser == null)
            //    {
            //        throw new ArgumentNullException("Не создан пользователь", nameof(CurentUser));
            //    }
            //}
            //else return null;
            //return CurentUser;
        }
      
        /// <summary>
        /// Получить сохраненный список пользоваетлей
        /// </summary>
        /// <returns>сохраненный список пользоваетлей</returns>
        private List <User> GetUsersData ()
        {
            var formater = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (fs.Length >0 &&formater.Deserialize(fs) is List<User>  users)
                {
                    return users;
                }
                else
                {
                    return new List<User>();
                }
            }
           
        }
        /// <summary>
        /// Сохранить данные пользователя
        /// </summary>
        public void Save()
        {
            var formater = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formater.Serialize(fs, Users);
            }
            //TODO Добавить событие и оповещать о том что "Был сохранен"
        }
    }
}
