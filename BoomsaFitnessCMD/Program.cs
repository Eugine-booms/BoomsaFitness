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
            Console.WriteLine("Введите пол");
            var gender = Console.ReadLine();
            Console.WriteLine("Введите дату рождения");
            var birthdate = DateTime.Parse(Console.ReadLine()); //TODO Переписать;
            Console.WriteLine("Введите вес");
            var weght = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите рост");
            var hight = double.Parse(Console.ReadLine());
            var userController = new UserController(name, gender, birthdate, weght, hight);
            userController.Save();
            var userLoad= new UserController().User;
            Console.ReadKey();
        }
    }
}
