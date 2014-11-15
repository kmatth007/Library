using System;
using Library.Services.Views;
using System.Collections;
using System.Collections.Generic;

namespace Library.Services.Messages
{
	public class FindBookTitleResponse : ResponseBase
	{
		public IEnumerable<BookTitleView> BookTitles { get; set; }

	}

}

