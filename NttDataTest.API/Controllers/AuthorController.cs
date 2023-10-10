using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NttDataTest.CORE.Core.Author.Interface;

namespace NttDataTest.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        #region Fields
        private readonly IAuthorCore _authorCore;
        #endregion

        #region Builder
        public AuthorController(IAuthorCore authorCore)
        {
            _authorCore = authorCore;
        }
        #endregion

        #region Methods

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _authorCore.GetAll();
            return response != null ? Ok(response) : NoContent();
        }
        #endregion
    }
}
