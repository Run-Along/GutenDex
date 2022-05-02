using System;
using Microsoft.EntityFrameworkCore;


namespace GutenDexAPI.Models
{
    public class AuthorResponse
    {
        public int statusCode { get; set; }
        public string statusDescription { get; set; }
        public List<Author> author { get; set; } = new();
    }
}
