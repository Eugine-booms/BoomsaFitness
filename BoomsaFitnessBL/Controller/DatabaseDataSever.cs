using BoomsaFitnessBL.Model;
using System.Collections.Generic;
using System.Linq;

namespace BoomsaFitnessBL.Controller
{
    class DatabaseDataSever : IDataSaver

    {
        public List<T> Load<T>() where T : class
        {
            using (var db = new DbFitnessContext())
            {
                var result = db.Set<T>().Where(o => true).ToList();
                return result;
            }
        }
        public void Save<T>(List<T> item) where T : class
        {
            using (var db = new DbFitnessContext())
            {
                foreach (var item1 in item)
                {
                    db.Set<T>().Add(item1);
                    db.SaveChanges();
                }
           //     db.Set<T>().AddRange(item);
                db.SaveChanges();
            }
        }
    }





}
