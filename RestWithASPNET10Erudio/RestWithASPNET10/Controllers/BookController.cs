using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNET10.Model;
using RestWithASPNET10.Services.Interfaces;
using Serilog;

namespace RestWithASPNET10.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private IBookServices _bookServices;
        private ILogger<BookController> _logger;

        public BookController(IBookServices bookServices, ILogger<BookController> logger)
        {
            _bookServices = bookServices;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult BuscarTodosLivros()
        {
            var todosLivros = _bookServices.FindAll().ToList();
            if (todosLivros == null) return NotFound();
            return Ok(todosLivros);
        }

        [HttpGet("{id}")]
        public IActionResult BucarLivroId(long id)
        {
            var livroId = _bookServices.FindById(id);
            if (livroId == null) return NotFound();
            return Ok(livroId);
        }


        [HttpPost]
        public IActionResult CriarLivros(Book book)
        {
            if (book == null)
            {
                _logger.LogError("Error: o paramentro livro está vazio");
                return BadRequest();
            }
            else
            {
                var createLivro = _bookServices.CreateBook(book);
                _logger.LogInformation("Livro Criado com Susseso");
                return Ok(createLivro);
            }
        }

        [HttpPut]
        public IActionResult AtualizarLivros(Book book)
        {
            if (_bookServices == null)
            {
                _logger.LogError("Error: o paramentro livro está vazio");
                return BadRequest();
            }
            else
            {
                var atualizarLivro = _bookServices.UpdateBook(book);
                _logger.LogInformation("Livro atualizado com susseso");
                return Ok(atualizarLivro);
            }
        }

        [HttpDelete]
        public IActionResult DeleteLivro(int id)
        {

            _logger.LogInformation($"Deleting person with ID: {id}");
            _bookServices.DeleteBook(id);
            _logger.LogDebug($"Person with ID: {id} deleted successfully");
            return NoContent();

        }



    }
}
