using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoomsaFitnessBL.Controller
{
    public class DbSaver : IDataSaver
    {

        public List<T> Load<T>() where T : class
        {
            using (var db = new DbFitnessContext())
            {
                return db.Set<T>().Where(o => true).ToList();
            }
            
        }

        public void Save<T>(List<T> item) where T : class
        {
            using (var db = new DbFitnessContext())
            {
                db.Set<T>().AddRange(item);
            }
        }
    }
}
