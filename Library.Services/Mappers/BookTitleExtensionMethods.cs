using System;
using Library.Services.Views;
using Library.Model;
using System.Collections.Generic;

namespace Library.Services.Mappers
{
	public static class BookTitleExtensionMethods
	{
		public static BookTitleView ConvertToBookTitleView(this BookTitle bookTitle)
		{
			return new BookTitleView {
				ISBN = bookTitle.ISBN,
				Title = bookTitle.Title
			};
		}

		public static IList<BookTitleView> ConvertToBookTitleViews(this IEnumerable<BookTitle> bookTitles)
		{
			IList<BookTitleView> bookViews = new List<BookTitleView> ();

			foreach(BookTitle bookTitle in bookTitles)
			{
				bookViews.Add (bookTitle.ConvertToBookTitleView ());
			}
			return bookViews;

		}
	}
}

