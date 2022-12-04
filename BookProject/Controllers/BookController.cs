using Data.BookRepository.IBookRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace BookProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetBookAsync()
        {
            var BookData = await _bookRepository.GetAllAsync();
            return Ok(BookData);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetBookIdAsync(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var BookData = await _bookRepository.GetByIdAsync(id);
            return Ok(BookData);
        }
        [HttpPost]

        public async Task<IActionResult> AddBookAsync(addBook AddBook)
        {
            var model = new ModelsOfBook()
            {

                BookName = AddBook.BookName,
                BookType = AddBook.BookType,
                Price = AddBook.Price,
            };
            model = await _bookRepository.AddBookAsync(model);
            return Ok(model);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteBookAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var BookData = await _bookRepository.DeleteBookAsync(id);

            return Ok(BookData);

        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateBookAsync(int id, [FromBody]addBook AddBook)
        {
            var model = new ModelsOfBook()
            {
               Id=AddBook.Id,
               BookName=AddBook.BookName,
               BookType=AddBook.BookType,   Price=AddBook.Price,
            };
            model = await _bookRepository.UpdateBookAsync(id,model);
            return Ok(model);
    
        }
    }
}
