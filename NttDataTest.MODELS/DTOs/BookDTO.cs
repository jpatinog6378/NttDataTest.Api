using NttDataTest.MODELS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NttDataTest.MODELS.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public AuthorDTO Author { get; set; } = null!;
    }
}
