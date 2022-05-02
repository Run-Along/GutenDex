using System;

namespace GutenDexAPI.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string? AuthorName { get; set; }
        public int Birth_Year { get; set; }
        public int Death_Year { get; set; }

        public List<Book>? Books { get; set; }
    }
}
