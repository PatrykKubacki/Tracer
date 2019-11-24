using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Tracer.Models
{
    public class Element
    {
        public int ElementId { get; set; }
        public int CategoryId { get; set; }

        [DisplayName("Tytuł")]
        public string Title { get; set; }

        [DisplayName("Wydawnictwo")]
        public string PublishingHouse { get; set; }

        [DisplayName("Długość")]
        public string Length { get; set; }

        [DisplayName("Numer ISBN")]
        public string Isbn { get; set; }

        [DisplayName("Opis")]
        public string Description { get; set; }

        [DisplayName("Obraz")]
        public byte[] Picture { get; set; }

        [DisplayName("Spis treści")]
        public string TableOfContents { get; set; }

        [DisplayName("Kategoria")]
        public Category Category { get; set; }
    }
}
