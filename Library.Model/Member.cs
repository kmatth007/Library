﻿using System;
using Library.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Model
{
	public class Member : IAggregrateRoot
	{
		public Guid Id { get; set; }
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public virtual IList<Loan> Loans { get; set; }

		public void Return(Book book)
		{
			Loan loan = FindCurrentOutstandingLoanFor (book);

			if (loan != null) {
				loan.MarkAsReturned ();
				book.OnLoanTo = null;

			} else {
				throw new ApplicationException (String.Format ("Cannot return book '{0}'. Member '{1}'" + "does not have this book on loan" 
					+ book.Id.ToString (), this.Id.ToString ()));
			}

		}

		private Loan FindCurrentOutstandingLoanFor(Book book)
		{
			return Loans.FirstOrDefault (l => (l.Book.Id == book.Id && l.HasNotBeenReturned ()));
		}

		public bool CanLoan(Book book)
		{
			return book.OnLoanTo == null;
		}

		public Loan Loan(Book book)
		{
			Loan loan = default(Loan);
			if (CanLoan (book)) {
				loan = LoanFactory.CreateLoanFrom (book, this);
				Loans.Add (loan);
			} else {
				throw new ApplicationException (String.Format ("Cannot loan book '{0}'. Book is on loan to Member '{1}'", book.Id.ToString (), book.OnLoanTo.Id.ToString ()));
			}

			return loan;

		}

		public Member ()
		{
		}
	}
}

