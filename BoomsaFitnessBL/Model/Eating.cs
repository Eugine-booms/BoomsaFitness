using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoomsaFitnessBL.Model
{
    /// <summary>
    /// Прием пищи
    /// </summary>
    [Serializable]
   public  class Eating
    {
        public int Id { get; set; }
        public Eating() { }
        public DateTime Moment { get;}
        public Dictionary<Food, double> Foods { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }

        public Eating (User user)
        {
            User = user ?? throw new ArgumentNullException(nameof(user), "Пользователь не может быть null" );
            Moment = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }

        
        public void Add(Food food, double weight)
        {
            var product= Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));
            if (product == null)
            {
                Foods.Add(food, weight);
            }
            else 
            {
                Foods[product] += weight;
            }    
        }
    }
}
