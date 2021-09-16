using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace BoomsaFitnessBL.Controller
{
    class SerializationSaver : IDataSaver
    {
        

        public void Save<T>(List<T> item) where T : class
        {
            var filename = typeof(T) + ".dat";
            var formater = new BinaryFormatter();
            using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                formater.Serialize(fs, item);
            }
        }

        List<T> IDataSaver.Load<T>() 
        {
            var filename = typeof(T) + ".dat";
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
