using System;
using Library.Infrastructure;
using Library.Infrastructure.Query;
using System.Collections;
using System.Collections.Generic;

namespace Library.Model
{
	public interface IBookRepository
	{
		void Add (Book book);
		void Remove(Book book);
		void Save (Book book);

		Book FindBy (Guid Id);

		IEnumerable<Book> FindAll ();
		IEnumerable<Book> FindAll (int index, int count);
		IEnumerable<Book> FindBy(Query query);
		IEnumerable<Book> FindBy (Query query, int index, int count);



	}
}

