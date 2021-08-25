using BoomsaFitnessBL.Controller;
using BoomsaFitnessBL.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace BoomsaFitnessCMD
{
    class Program
    {
        static void Main(string[] args)
        {


            var  culture = CultureInfo.CurrentCulture;
            var resourseManager = new ResourceManager("BoomsaFitnessCMD.Languages.Messages", typeof(Program).Assembly);
            Console.WriteLine(resourseManager.GetString("Hello", culture));
            UserController userController = ChangeUser();
            Console.WriteLine(userController.CurentUser);
            var eatingController = new EatingController(userController.CurentUser);
            var exiexerciseController = new ExerciseController(userController.CurentUser);
            

            while (true)
            {
                if (userController.CurentUser==null)
                {
                    userController= ChangeUser();
                }
                Console.WriteLine($"\tТекущий пользователь {userController.CurentUser}");
                Console.WriteLine();
                Console.WriteLine("Что вы хотите сделать?");
                Console.WriteLine("D - удалить текущего пользователя");
                Console.WriteLine("C - Сменить пользователя");
                Console.WriteLine("O - очистить экран");
                Console.WriteLine("E - ввести прием пищи");
                Console.WriteLine("A - ввести упражнение");
                Console.WriteLine("U - Вывести всех пользователей");
                Console.WriteLine("Q - выход");

                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.D:
                        Console.Clear();
                        userController.DeleteCurentUser();
                        userController.PrintAllUsers();
                        break;
                    case ConsoleKey.C:
                        Console.Clear();
                        userController.PrintAllUsers();
                        userController = ChangeUser();
                        break;
                    case ConsoleKey.O:
                        Console.Clear();
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                    case ConsoleKey.E:
                        Console.Clear();
                        var eating = EnterEating();
                        eatingController.Add(eating.Food, eating.weight);

                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"\t{item.Key}-{item.Value}");
                        }
                        break;
                    case ConsoleKey.U:
                        Console.Clear();
                        userController.PrintAllUsers();
                        break;
                    case ConsoleKey.A:
                        var exercise = EnterExercise(userController.CurentUser);
                        exiexerciseController.Add(exercise);
                        Console.Clear();
                        Console.WriteLine(userController.CurentUser);
                        Console.WriteLine("Активности");
                        foreach (var item in exiexerciseController.Exercises)
                        {
                            Console.WriteLine($"\t{item}");
                        }
                        break;
                }

            }

            Console.ReadKey();
        }
        private static UserController ChangeUser()
        {
            Console.WriteLine("Введите имя пользователя");
            var name = Console.ReadLine();
            var userController = new UserController(name);
            if (userController.IsNewUser)
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
                    DateTime birthDate = ParseDateTime("дату рождения(dd.MM.YYYY)");
                    var weght = ParseDouble("Вес");
                    var hight = ParseDouble("Рост");
                    userController.CreateNewUser(gender, birthDate, weght, hight);
                }
            }

            return userController;
        }

        private static Exercise EnterExercise(User user)
        {
            Console.WriteLine("Введите название упражнения: ");
            var exerciseName = Console.ReadLine();
            var exerciseStart = ParseDateTime("Время начала упражнения ");
            var exerciseFinish = ParseDateTime("Время окончания упражнения ");
            var energy = ParseDouble("Расход энергии");
            return new Exercise(exerciseStart, exerciseFinish, user, new Activity(exerciseName, energy));



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
        private static DateTime ParseDateTime(string param)
        {
            while (true)
            {
                Console.WriteLine($"Введите {param}");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime dateTime))
                {
                    return dateTime;
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
