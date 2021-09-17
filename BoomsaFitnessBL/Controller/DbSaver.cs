using BoomsaFitnessBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoomsaFitnessBL.Controller
{
    public class DbSaver : IDataSaver
    {
        public bool Del<T>(T item) where T:class
        {
            using (var db = new MyDBContext())
            {
                db.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return true;
            }
            return false;
                
        }

        public List<T> Load<T>() where T : class
        {
            using (var db = new MyDBContext())
            {
                return db.Set<T>().Where(o => true).ToList();
            }
        }

        public void Save<T>(List<T> item) where T : class
        {
            using (var db = new MyDBContext())
            {
                db.Set<T>().Add(item.Last<T>());
                db.SaveChanges();
            }
        }
    }
}
