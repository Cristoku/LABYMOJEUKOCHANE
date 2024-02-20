using LibApp.Data;
using LibApp.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using LibApp.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LibApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BooksApiController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET /api/books
        [HttpGet]
        public IActionResult GetBooks()
        {
            var books = _context.Books
                .Include(b => b.Genre)
                .ToList()
                .Select(_mapper.Map<Book, BookDto>);
            return Ok(books);
        }

        // GET /api/books/{id}
        [HttpGet("{id}", Name = "GetBook")]
        public IActionResult GetBook(int id)
        {
            var book = _context.Books
                .Include(b => b.Genre)
                .SingleOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<BookDto>(book));
        }

        // POST /api/books
        [HttpPost]
        public IActionResult CreateBook(BookDto bookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var book = _mapper.Map<Book>(bookDto);
            _context.Books.Add(book);
            _context.SaveChanges();

            return CreatedAtRoute(nameof(GetBook), new { id = book.Id }, bookDto);
        }

        // PUT /api/books/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, BookDto bookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var bookInDb = _context.Books.SingleOrDefault(b => b.Id == id);
            if (bookInDb == null)
            {
                return NotFound();
            }

            _mapper.Map(bookDto, bookInDb);
            _context.SaveChanges();

            return Ok(bookDto);
        }

        // DELETE /api/books/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var bookInDb = _context.Books.SingleOrDefault(b => b.Id == id);
            if (bookInDb == null)
            {
                return NotFound();
            }

            _context.Books.Remove(bookInDb);
            _context.SaveChanges();

            return Ok(bookInDb);
        }
    }
}