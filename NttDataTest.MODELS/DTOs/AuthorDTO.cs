using NttDataTest.MODELS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NttDataTest.MODELS.DTOs
{
    public class AuthorDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public List <BookDTO>? Book { get; set; }
    }
}
