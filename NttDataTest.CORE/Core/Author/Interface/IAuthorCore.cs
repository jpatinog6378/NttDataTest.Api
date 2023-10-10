using NttDataTest.MODELS.DTOs;
using NttDataTest.MODELS.Requests;

namespace NttDataTest.CORE.Core.Author.Interface
{
    public interface IAuthorCore
    {
        Task<List<AuthorDTO>> GetAll();
        Task<AuthorDTO> GetById(int id);
        Task<bool> AddOrUpdate(AuthorRequest model);
        Task<bool> Delete(int id);
    }
}
