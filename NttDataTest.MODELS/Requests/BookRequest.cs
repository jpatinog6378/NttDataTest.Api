﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NttDataTest.MODELS.Requests
{
    public class BookRequest
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public int? AuthorId { get; set; }
    }
}
