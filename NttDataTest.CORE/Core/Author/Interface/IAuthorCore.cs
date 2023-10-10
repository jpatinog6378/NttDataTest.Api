using NttDataTest.MODELS.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NttDataTest.CORE.Core.Author.Interface
{
    public interface IAuthorCore
    {
        Task<List<AuthorDTO>> GetAll();
    }
}
