using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleProductApplication.Services
{
    public interface IRepo<K, T> //key, object type
    {
        ICollection<T> GetAll();
        T Get(K id);
        bool Add(T item);
        bool Remove(K id);
        bool Update(T item);
    }
}
