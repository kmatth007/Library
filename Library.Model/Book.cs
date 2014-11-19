using System;
using Library.Infrastructure;
namespace Library.Model
{
	public class Book : IAggregrateRoot
	{
		
      
        public Guid Id { get; set; }
		public virtual BookTitle Title { get; set; }
		public virtual Member OnLoanTo { get; set; }

		public Book ()
		{
		}
	}
}

