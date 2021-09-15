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
    public class UserController : ControllerBase
    {
        public User CurentUser { get; private set; }
        public List<User> Users { get; private set; }
        /// <summary>
        /// Создание нового контроллера пользователя
        /// </summary>
        /// <param name="user">Пользователь</param>
        
        public UserController()
        {
            Users = GetUsersData();
        }
        public bool SetCurentUser(string userName)
        {
            CurentUser = Users.SingleOrDefault(u => u.Name == userName);
            return CurentUser != null;
        }
        public bool SetCurentUser(User user)
        {
            CurentUser = user;
            Users.Add(user);
            Save();
            return CurentUser != null;
        }
        public User ChangeCurentUser(string name)
        {
            if (SetCurentUser(name))
            {
                return CurentUser;
            }
            return null;
        }
        /// <summary>
        /// Получить сохраненный список пользователей
        /// </summary>
        /// <returns>сохраненный список пользователей</returns>
        private List<User> GetUsersData()
        {
            return Load<User>() ?? new List<User>();
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
            var sucsesfull = Users.Remove(CurentUser);
            CurentUser = null;
            Save();
            return (usersCount - 1) == Users.Count ? true : false;
        }
        public void PrintAllUsers()
        {
            var users = GetUsersData();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            foreach (var item in users)
            {
                Console.WriteLine($"\t{item}");
            }
            Console.ResetColor();
        }
    }
}
