using Microsoft.AspNetCore.Mvc;
using NttDataTest.CORE.Core.Author.Interface;
using NttDataTest.MODELS.Requests;

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

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _authorCore.GetById(id);
            return response != null ? Ok(response) : NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> AddOrUpdate(AuthorRequest model)
        {
            var response = await _authorCore.AddOrUpdate(model);
            return response ? Ok(response) : NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var response = await _authorCore.Delete(id);
                return response ? Ok(response) : NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        #endregion
    }
}
