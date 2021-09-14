using BoomsaFitnessBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoomsaFitnessBL.Controller
{
    class DatabaseDataSever : IDataSaver
       
{
        public List<T> Load<T>() where T : class
        {
            using (var db = new DbFitnessContext())
            {
                var result = db.Set<T>().Where(l => true).ToList();
                return result;
            }
        }
        public void Save<T>(List<T> item) where T : class
        {
            using (var db = new DbFitnessContext())
            {
                db.Set<T>().AddRange(item);
                db.SaveChangesAsync();
            }
        }
    }

   

       
    
}
