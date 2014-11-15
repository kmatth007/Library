using System;
using System.Collections.Generic;
using System.Collections;
using Library.Services.Views;

namespace Library.Services.Messages
{
	public class FindBookResponse : ResponseBase
	{
		public IEnumerable<BookView> Books { get; set; }

	}
}

