using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.Eventing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BoomsaFitnessBL.Controller
{
    public abstract class ControllerBase
    { 
        
        public event EventHandler<string> SaveFile;
        public event Action<string> LoadFile;

        protected void SavingFile(object sender, string filename)
        {
            Console.WriteLine($"Файл {filename} сохранен вот этим дядей {sender}");
        }
        protected void LoadingFile(string obj)
        {
            Console.WriteLine($"Файл {obj} загружен");
        }
        protected void Save(string filename, object item)
        {
            var formater = new BinaryFormatter();
            using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                formater.Serialize(fs, item);
            }

            var args = new EventArgs();
            SaveFile?.Invoke(this, filename);
            //TODO Добавить событие и оповещать о том что "Был сохранен"
        }
        protected T Load<T> (string filename)
        {
            var formater = new BinaryFormatter();
            using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                LoadFile?.Invoke(filename);
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
