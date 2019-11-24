using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracer.Repository
{
    public interface IRepository<T>
    {
        T Get(int id);
        void Add(T item);
        void Delete(T item);
        void Update(T item);
    }
}
