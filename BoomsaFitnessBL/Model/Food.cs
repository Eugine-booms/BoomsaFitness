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
        public string Name { get; set; }
        public double Proteins { get; set; }
        public double Fats { get; set; }
        public double Carbohydrates { get; set; }
        public double Calories { get; set; }


        ////////For Entity
        public int Id { get; set; }

        public Food()
        {
        }
        public int EatingId { get; set; }
        public virtual Eating Eating { get; set; }

        ////////For Entity


        public Food(string name) : this (name,1,1,1,1)
        {
        }
        public Food (string name, double fats, double proteins, double carbohydrates, double calories)
        {
            #region Проверки
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name),"Название продукта не может быть пустым");
            }
            if (fats<=0)
            {
                throw new ArgumentNullException( nameof(fats), "Количество жиров не может быть меньше или равно нулю");
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
