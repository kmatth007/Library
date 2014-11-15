using System;

namespace Library.Model
{
	public static class LoanFactory
	{
		public static Loan CreateLoanFrom(Book book, Member member)
		{
			Loan loan = new Loan ();
			loan.Book = book;
			loan.Member = member;
			loan.LoanDate = DateTime.Now;
			loan.DateForReturn = DateTime.Now.AddDays (7);
			return loan;
		}
	}
}

