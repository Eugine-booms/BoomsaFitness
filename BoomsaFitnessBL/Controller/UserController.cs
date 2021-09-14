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
    public class UserController:ControllerBase
    {
        public bool IsNewUser { get; } = false;
        public User CurentUser { get; private set; }
        public List <User> Users { get; private set; }
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
                IsNewUser = true;
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
        }
        /// <summary>
        /// Получить сохраненный список пользоваетлей
        /// </summary>
        /// <returns>сохраненный список пользоваетлей</returns>
        private List <User> GetUsersData ()
        {
            return Load<User>();
        }
        /// <summary>
        /// Сохранить данные пользователя
        /// </summary>
        public void Save()
        {
            Save(Users);
        }
        public bool DeleteCurentUser()
        {
            var usersCount = Users.Count;
            var sucsesfull= Users.Remove(CurentUser);
            CurentUser = null;
            Save();
            return (usersCount - 1) == Users.Count ? true : false;
        }
        public void PrintAllUsers()
        {
            var users = GetUsersData();
            foreach (var item in users)
            {
                Console.WriteLine($"\t{item}");
            }
        }
    }
}
