using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracer.Models
{
    public class Element
    {
        public int ElementId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string PublishingHouse { get; set; }
        public string Length { get; set; }
        public string Isbn { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }
        public string TableOfContents { get; set; }
        public Category Category { get; set; }
    }
}
