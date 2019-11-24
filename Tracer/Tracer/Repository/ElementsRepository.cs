using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tracer.Data;
using Tracer.Models;

namespace Tracer.Repository
{
    public class ElementsRepository : IElementsRepostiory<Element>
    {
        ContentDbContext _context;

        public ElementsRepository(ContentDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Element> Elements 
            => _context.Elements.Include(e=>e.Category);

        public void Add(Element item)
        {
            _context.Elements.Add(item);

            _context.SaveChanges();
        }

        public void Delete(Element item)
        {

            var element = Elements.FirstOrDefault(x => x.ElementId == item.ElementId);
            if (element != null) 
                _context.Elements.Remove(element);

            _context.SaveChanges();
        }

        public bool ElementExists(int id)
        {
            return _context.Elements.Any(e => e.ElementId == id);
        }

        public Element Get(int id)
        {
            var result = Elements.FirstOrDefault(x => x.ElementId == id);
            return result;
        }

        public void Update(Element item)
        {
            _context.Elements.Update(item);
            _context.SaveChanges();
        }
    }
}
