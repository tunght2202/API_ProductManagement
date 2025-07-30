using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.IRepo
{
    public interface IGeneric<T> where T : class
    {
        List<T> GetAll();
        T Get(int id);
        int Create(T item);
        int Update(T item);
        int Delete(int id);
    }
}
