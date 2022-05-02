using System;
using Microsoft.EntityFrameworkCore;


namespace GutenDexAPI.Models
{
    public class BookResponse
    {
        public int statusCode { get; set; }
        public string? statusDescription { get; set; }
        public List<Book> book { get; set; } = new();
    }
}