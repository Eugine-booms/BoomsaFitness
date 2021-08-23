using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoomsaFitnessBL.Model
{
    [Serializable]
    public class Food
    {
        public string Name { get; }
        public double Proteins { get; }
        public double Fats { get; }
        public double Carbohydrates { get; }
        public double Calories { get; }
        

        public Food(string name) : this (name,1,1,1,1)
        {
        }
        public Food (string name, double fats, double proteins, double carbohydrates, double calories)
        {
            #region Проверки
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Название продукта не может быть пустым", nameof(name));
            }
            if (fats<=0)
            {
                throw new ArgumentNullException("Количество жиров не может быть меньше или равно нулю", nameof(fats));
            }
            if (proteins <= 0)
            {
                throw new ArgumentNullException("Количество белков не может быть меньше или равно нулю", nameof(fats));
            }
            if (carbohydrates <= 0)
            {
                throw new ArgumentNullException("Количество углеводов не может быть меньше или равно нулю", nameof(fats));
            }
            if (calories <= 0)
            {
                throw new ArgumentNullException("Количество калорий не может быть меньше или равно нулю", nameof(fats));
            }

            #endregion
            Name = name;
            Fats = fats /100.0;
            Proteins = proteins / 100.0;
            Carbohydrates = carbohydrates / 100.0;
            Calories = calories / 100.0;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
