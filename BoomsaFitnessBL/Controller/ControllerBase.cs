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
        IDataSaver dataSaver = new SerializationSaver(); 
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
        protected void Save <T>(List <T> item) where T:class
        {
            dataSaver.Save(item) ;
            SaveFile?.Invoke(this, typeof(T)+".dat");
        }
        protected List<T> Load<T> () where T : class
        {
            LoadFile?.Invoke(typeof(T) + ".dat");
            return dataSaver.Load<T>() ?? new List<T>() ;
        }
    }
}
