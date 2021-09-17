using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoomsaFitnessBL.Controller
{
   public interface IDataSaver

    {
        void Save<T>(List<T> item) where T: class;
        List<T> Load<T>() where T : class;
        bool Del<T>(T item) where T : class; 
    }
}
