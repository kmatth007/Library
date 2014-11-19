using System;
using Library.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace Library.Model
{
	public class BookTitle : IAggregrateRoot
	{
        [Key]
		public string ISBN { get; set; }
		public string Title { get; set; }

	}
}

