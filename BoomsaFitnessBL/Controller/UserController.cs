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
        public User User { get; }
        /// <summary>
        /// Создание нового контроллера пользователя
        /// </summary>
        /// <param name="user">Пользователь</param>
        public UserController (string userName, string gendername, DateTime birthDay, double weight, double hight )
        {
            // ToDO: проверка
            var gender = new Gender(gendername);
            User = new User(userName, gender, birthDay, weight, hight );
            
        }
        public UserController ()
        {
            var formater = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {

                if (formater.Deserialize(fs) is User user)
                {
                    User = user;
                }
                // TO DO что делать если пользователя не прочитали 

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
                formater.Serialize(fs, User);
            }
            //TODO Добавить событие и оповещать о том что "Был сохранен"
        }
    }
}
