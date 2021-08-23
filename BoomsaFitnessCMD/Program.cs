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
            Console.WriteLine("Вас приветствует приложение BoomsaFitness.");
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
            var eatingController = new EatingController(userController.CurentUser);
            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine("E - ввести прием пищи");
            var key = Console.ReadKey();
            if (key.Key==ConsoleKey.E)
            {
                var eating= EnterEating();
                eatingController.Add(eating.Food, eating.weight);

                foreach (var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"\t{item.Key}-{item.Value}");
                }
                
            }
            Console.ReadKey();
        }

        private static (Food Food, double weight) EnterEating()
        {
            Console.Write("Введите имя продукта: ");
            var food= Console.ReadLine();
            var calories = ParseDouble("калорийность");
            var fats = ParseDouble("жиры");
            var proteins = ParseDouble("Белки");
            var carbohydrates = ParseDouble("Углеводы");
            Console.Write("Введите вес порции: ");
            var weight = ParseDouble("Вес порции: ");
            var eating = new Food(food, fats, proteins, carbohydrates, calories);
            return (Food: eating, weight: weight);
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
