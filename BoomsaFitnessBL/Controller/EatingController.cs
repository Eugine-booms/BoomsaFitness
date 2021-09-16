using BoomsaFitnessBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BoomsaFitnessBL.Controller
{
    public class EatingController:ControllerBase
    {
        
        private readonly User user;
        public List<Food> Foods { get; }
        public Eating Eating { get; }
        public EatingController(User user)
        {
            this.LoadFile += (str) => Console.WriteLine($"Файл {str} загружен");
            this.SaveFile += (s, str) => Console.WriteLine($"Файл {str} сохранен вот этим дядей {s}"); ;
            this.user = user ?? throw new ArgumentNullException(nameof(user), "Пользователь не может быть пустым");
            Foods = GetAllFoods();
            Eating = GetEating();
        }
        public void Add (Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);
            if(product==null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                Save();
            }
            else
            {
                Eating.Add(product, weight);
                Save();
            }
        }
        private Eating GetEating()
        {
          return  Load <Eating> ().FirstOrDefault()??new Eating(user);
        }

        private List<Food> GetAllFoods()
        {
            return Load<Food>();
        }
        private void Save()
        {
            Save(Foods);
            var eatingList = new List<Eating>() { Eating };
            Save<Eating>(eatingList);
        }
    }
}
