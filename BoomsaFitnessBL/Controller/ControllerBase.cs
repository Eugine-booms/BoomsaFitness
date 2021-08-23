using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace BoomsaFitnessBL.Controller
{
   public abstract class ControllerBase
    {
        protected void Save(string filename, object item)
        {
            var formater = new BinaryFormatter();
            using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                formater.Serialize(fs, item);
            }
            //TODO Добавить событие и оповещать о том что "Был сохранен"
        }
        protected T Load<T> (string filename)
        {
            var formater = new BinaryFormatter();
            using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formater.Deserialize(fs) is T items)
                {
                    return items;
                }
                else
                {
                    return  default(T);
                }
            }
        }
    }
}
