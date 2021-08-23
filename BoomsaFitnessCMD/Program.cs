using BoomsaFitnessBL.Controller;
using BoomsaFitnessBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoomsaFitnessCMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует приложение BoomsaFitness");
            Console.WriteLine("Введите имя пользователя");
            var name = Console.ReadLine();
            var userController = new UserController(name);
            if (userController.CurentUser == null)
            {

                string str;
                do
                {
                    Console.WriteLine("Пользователь не найден. Создать нового? д/н");
                    str = Console.ReadLine();
                } while (!"ДднН".Contains(str));
                if ("Дд".Contains(str))
                {
                    Console.WriteLine("Введите пол");
                    var gender = Console.ReadLine();
                    DateTime birthDate = ParseDateTime();
                    var weght = ParseDouble("Вес");
                    var hight = ParseDouble("Рост");
                    userController.CreateNewUser (gender, birthDate, weght, hight);
                }
            }
                Console.WriteLine(userController.CurentUser);
          
            Console.ReadKey();
        }
        private static DateTime ParseDateTime()
        {
            while (true)
            {
                Console.WriteLine("Введите дату рождения (dd.MM.YYYY)");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime birthDate))
                {
                    return birthDate;
                }
                else
                {
                    Console.WriteLine("Неверный формат даты");
                }
            }
        }
        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.WriteLine($"Введите {name}");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Неверный формат {name}: ");
                }
            }
        }
    }
}
