using System;
using System.Collections.Generic;

namespace Library.Services.Views
{
	public class MemberView
	{
		public string MemberId { get; set; }
		public string FullName { get; set; }
		public IList<LoanView> Loans { get; set; }

	}
}

