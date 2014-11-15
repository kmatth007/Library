using System;
using Library.Infrastructure;

namespace Library.Model
{
	public class BookTitle : IAggregrateRoot
	{
		public string ISBN { get; set; }
		public string Title { get; set; }

	}
}

