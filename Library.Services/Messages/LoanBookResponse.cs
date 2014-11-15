using System;
using Library.Services.Views;

namespace Library.Services.Messages

{
	public class LoanBookResponse : ResponseBase
	{
		public LoanView loan { get; set; }
	}
}

