using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoomsaFitnessBL.Model
{
    [Serializable]
    public class Activity
    
    {
        public int Id { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
        public Activity() { }

        public string Name { get; set; }
        public double CaloriesPerMinute { get; set; }
        
        public Activity (string name, double caloriesPerMinute)
        {
            Name = name ?? throw new ArgumentNullException("Имя не может быть пустым" , nameof(name));
            CaloriesPerMinute = caloriesPerMinute > 0 ?
                caloriesPerMinute : 
                throw new ArgumentException("Калории не могут быть меньше нуля ", nameof(caloriesPerMinute)); ;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
