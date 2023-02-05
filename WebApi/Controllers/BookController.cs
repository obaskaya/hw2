using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.BookOperations;
using WebApi.Data;
using WebApi.DBOperations;
using static WebApi.BookOperations.CreateBookCommand;
using static WebApi.BookOperations.UpdateBookCommand;

namespace WebApi.Controllers
{
	[ApiController]
	[Route("[controller]s")]
	public class BookController : ControllerBase
	{
		private readonly BookStoreDbContext _context;
		public BookController(BookStoreDbContext context)
		{
			_context = context;
		}


		[HttpGet]
		public IActionResult GetBooks()
		{
			GetBooksQuery query = new GetBooksQuery(_context);
			var result = query.Handle();
			return Ok(result);

		}

		// get by id
		[HttpGet("{id}")]

		public IActionResult GetById(int id)
		{
			BookDetailViewModel result;
<<<<<<< Updated upstream
			try
			{
				GetBookDetailQuery query = new GetBookDetailQuery(_context);
				query.BookId = id;
				result = query.Handle();
			}
			catch (Exception ex)
			{
=======
>>>>>>> Stashed changes

			GetBookDetailQuery query = new GetBookDetailQuery(_context, _mapper);
			query.BookId = id;

			GetBooksQueryValidator validator = new GetBooksQueryValidator();
			validator.ValidateAndThrow(query);
			result = query.Handle();

			return Ok(result);

		}

		// add book 
		[HttpPost]
		public IActionResult AddBook([FromBody] CreateBookModel newBook)
		{
<<<<<<< Updated upstream
			CreateBookCommand command = new CreateBookCommand(_context);
			try
			{
				command.Model = newBook;
				command.Handle();

			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}
=======
			CreateBookCommand command = new CreateBookCommand(_context, _mapper);

			command.Model = newBook;
			CreateBookCommandValidator validator = new CreateBookCommandValidator();

			validator.ValidateAndThrow(command);
			command.Handle();

>>>>>>> Stashed changes
			return Ok();


		}

		// update book
		[HttpPut("{id}")]
		public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
		{
<<<<<<< Updated upstream
			try
			{
				UpdateBookCommand command = new UpdateBookCommand(_context);
				command.BookId = id;
				command.Model = updatedBook;
				command.Handle();
			}
			catch (Exception ex)
			{
=======
>>>>>>> Stashed changes

			UpdateBookCommand command = new UpdateBookCommand(_context);
			command.BookId = id;
			command.Model = updatedBook;

			UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
			validator.ValidateAndThrow(command);
			command.Handle();

			return Ok();
		}


		[HttpDelete("{id}")]
		public IActionResult DeleteBook(int id)
		{
<<<<<<< Updated upstream
			try
			{
				DeleteBookCommand command = new DeleteBookCommand(_context);
				command.BookId = id;
				command.Handle();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
=======

			DeleteBookCommand command = new DeleteBookCommand(_context);
			command.BookId = id;
			DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
			validator.ValidateAndThrow(command);
			command.Handle();

>>>>>>> Stashed changes

			return Ok();

		}
	}
}
