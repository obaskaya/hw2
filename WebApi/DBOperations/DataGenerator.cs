using Bogus;
using Bogus.DataSets;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using WebApi.Data;
using static AutoMapper.Internal.ExpressionFactory;


namespace WebApi.DBOperations
{
	public class DataGenerator
	{
		public static void Initialize(IServiceProvider serviceProvider)
		{
			using (var context = new BookStoreDbContext(
			serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))

			{
				// Look for any book.
				if (context.Books.Any())
				{
					return;   // Data was already seeded
				}
				context.Books.AddRange(
					new Faker<Book>()

						.RuleFor(c => c.Title, f => f.Lorem.Letter(4))
						.RuleFor(c => c.GenreId, f => f.IndexFaker)
						.RuleFor(c => c.PageCount, f => f.Random.Number(50,600))
						.RuleFor(c => c.PublishDate, f => f.Date.Past().ToString())
						.Generate(100)

				);
				context.SaveChanges();
			}

		}
	}
}
