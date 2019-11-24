using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracer.Models;

namespace Tracer.Repository
{
    public interface IElementsRepostiory<T>: IRepository<T>
    {
        IEnumerable<T> Elements { get; }
        bool ElementExists(int id);
    }
}
