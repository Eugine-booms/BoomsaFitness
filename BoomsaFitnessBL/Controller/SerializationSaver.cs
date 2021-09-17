using BoomsaFitnessBL.Model;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BoomsaFitnessBL.Controller
{
    class SerializationSaver : IDataSaver
    {
        public bool Del<T>(T item) where T : class
        {
            var items = Load<T>();
            var i = items.Find(u => u.Equals(item));
            items.Remove(i);
            Save<T>(items);
            return true;
        }

        public void Save<T>(List<T> item) where T : class
        {
            var filename = typeof(T).Name + ".dat";
            var formater = new BinaryFormatter();
            using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                formater.Serialize(fs, item);
            }
        }

        public List<T> Load<T>() where T : class
        {
            var filename = typeof(T).Name + ".dat";
            var formater = new BinaryFormatter();
            using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formater.Deserialize(fs) is List<T> items)
                {
                    return items;
                }
                else
                {
                    return new List<T>();
                }
            }
        }
        
    }
}
