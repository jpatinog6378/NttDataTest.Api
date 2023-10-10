using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NttDataTest.CORE.Core.Book.Interface;
using NttDataTest.MODELS.Requests;

namespace NttDataTest.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        #region Fields
        private readonly IBookCore _bookCore;
        #endregion

        #region Builder
        public BookController(IBookCore bookCore)
        {
            _bookCore = bookCore;   
        }
        #endregion

        #region Methods
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _bookCore.GetAll();
            return response != null ? Ok(response) : NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _bookCore.GetById(id);
            return response != null ? Ok(response) : NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> AddOrUpdate(BookRequest model)
        {
            var response = await _bookCore.AddOrUpdate(model);
            return response ? Ok(response) : NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var response = await _bookCore.Delete(id);
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
