using NttDataTest.MODELS.DTOs;
using NttDataTest.MODELS.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NttDataTest.CORE.Core.Book.Interface
{
    public interface IBookCore
    {
        Task<List<BookDTO>> GetAll();
        Task<BookDTO> GetById(int id);
        Task<bool> AddOrUpdate(BookRequest model);
        Task<bool> Delete(int id);
    }
}
