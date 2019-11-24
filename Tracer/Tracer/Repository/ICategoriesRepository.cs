using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracer.Models;

namespace Tracer.Repository
{
    public interface ICategoriesRepository<T> : IRepository<T>
    {
        IEnumerable<T> Categories { get; }
    }
}
