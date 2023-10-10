using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NttDataTest.MODELS.Entities
{
    public partial class Author
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public virtual Book? Book { get; set; }
    }
}
