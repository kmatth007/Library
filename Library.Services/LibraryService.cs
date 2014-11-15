using System;
using Library.Services.Messages;
using Library.Services.Mappers;
using Library.Model;
using Library.Services.Views;
using Library.Infrastructure.UnitOfWork;


namespace Library.Services
{
	public class LibraryService
	{
		private IUnitOfWork _uow;
		private IBookRepository _bookRepository;
		private IBookTitleRepository _bookTitleRepository;
		private IMemberRepository _memberRepository;
		private LoanService _loanService;

		public LibraryService (IBookTitleRepository bookTitleRepository, IBookRepository bookRepository, IMemberRepository memberRepository, IUnitOfWork unitOfWork)
		{
			_uow = unitOfWork;
			_memberRepository = memberRepository;
			_bookRepository = bookRepository;
			_bookTitleRepository = bookTitleRepository;
			_loanService = new LoanService (_bookRepository, _memberRepository, _uow);
		}

		public AddBookResponse AddBook(AddBookRequest request)
		{

		}
	}
}

