using System;
using Library.Services.Views;
using Library.Model;
using System.Collections.Generic;

namespace Library.Services.Mappers
{
	public static class LoanExtensionMethods
	{
		public static LoanView ConvertToLoanView(this Loan loan)
		{
			return new LoanView {
				BookTitle = loan.Book.Title.Title,
				CopyId = loan.Book.Id.ToString(),
				LoanId = loan.Member.Id.ToString(),
				MemberName = loan.Member.FirstName + ' ' + loan.Member.LastName,
				LoanDate = loan.LoanDate.ToString(),
				DateForReturn = loan.DateForReturn.ToString(),
				StillOutOnLoan = loan.HasNotBeenReturned()
			};
		}

		public static IList<LoanView> ConvertToLoanViews(this IEnumerable<Loan> loans)
		{
			IList<LoanView> loanViews = new List<LoanView> ();

			foreach(Loan loan in loans)
			{
				loanViews.Add (loan.ConvertToLoanView ());
			}

			return loanViews;
		}

	}
}

