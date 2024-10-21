using System;
using System.Collections.Generic;

namespace Baitap4.Models
{
    public partial class Book
    {
        public int Id { get; set; }
        public string BookName { get; set; } = null!;
        public string Author { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}
