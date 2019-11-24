using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracer.Data;
using Tracer.Models;

namespace Tracer.Repository
{
    public class CategoriesRepository : ICategoriesRepository<Category>
    {
        readonly ContentDbContext _context;
        public CategoriesRepository(ContentDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> Categories => _context.Categories;

        public void Add(Category item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Category item)
        {
            throw new NotImplementedException();
        }

        public Category Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Category item)
        {
            throw new NotImplementedException();
        }
    }
}
