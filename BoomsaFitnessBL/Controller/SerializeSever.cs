using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace BoomsaFitnessBL.Controller
{
    class SerializeSever : IDataSaver 
    {
        public List<T> Load<T>() where T : class
        {
            var formater = new BinaryFormatter();
            var fileName = typeof(T) + "dat";
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
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
        public void Save<T>(List<T> item) where T : class
        {
            var formater = new BinaryFormatter();
            var fileName = typeof(T) + "dat";
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formater.Serialize(fs, item);
            }
        }
    }
}
