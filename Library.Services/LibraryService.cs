using System;
using Library.Services.Messages;
using Library.Services.Mappers;
using Library.Model;
using Library.Services.Views;
using Library.Infrastructure.UnitOfWork;
using System.Collections.Generic;


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
            AddBookResponse response = new AddBookResponse();

            BookTitle bookTitle = _bookTitleRepository.FindBy(request.ISBN);
            Book book = new Book();
            book.Title = bookTitle;
            book.Id = Guid.NewGuid();
            _bookRepository.Add(book);
            _uow.Commit();

            response.Success = true;
            return response;

		}

        public AddBookTitleResponse AddBookTitle(AddBookTitleRequest request)
        {
            AddBookTitleResponse response = new AddBookTitleResponse();
            BookTitle bookTitle = new BookTitle();
            bookTitle.ISBN = request.ISBN;
            bookTitle.Title = request.Title;

            _bookTitleRepository.Add(bookTitle);
            _uow.Commit();

            response.Success = true;
            return response;

        }

        public FindBookResponse FindBooks(FindBookRequest request) 
        { 
            FindBookResponse response = new FindBookResponse();
            IEnumerable<Book> books = _bookRepository.FindAll();
            IEnumerable<BookView> bookViews = books.ConvertToBookViews();
            response.Books = bookViews;
            return response;          

        
        }

        public FindBookTitleResponse FindBookTitles(FindBookTitleRequest request)
        {
            FindBookTitleResponse response = new FindBookTitleResponse();
            IList<BookTitleView> bookTitles = new List<BookTitleView>();

            if(request.All)
            {
                bookTitles = _bookTitleRepository.FindAll().ConvertToBookTitleViews();
            }
            else
            {
                BookTitle bookTtile = _bookTitleRepository.FindBy(request.ISBN);
                bookTitles.Add(bookTtile.ConvertToBookTitleView());
            }

            response.BookTitles = bookTitles;
            response.Success = true;
            return response;
        }

        public LoanBookResponse LoanBook(LoanBookRequest request)
        {
            LoanBookResponse response = new LoanBookResponse();
            Loan loan = _loanService.Loan(new Guid(request.MemberId), new Guid(request.CopyId));

            if(loan != null)
            {
                response.loan = loan.ConvertToLoanView();
                response.Success = true;
            }
            else
            {
                response.Success = false;
            }

            return response;
        }

        public ReturnBookResponse ReturnBook(ReturnBookRequest request)
        {
            ReturnBookResponse response = new ReturnBookResponse();
            _loanService.Return(new Guid(request.CopyId));
            return response;
        }

        public AddMemberResponse AddMember(AddMemberRequest request)
        {
            AddMemberResponse response = new AddMemberResponse();

            Member member = new Member();
            member.FirstName = request.FirstName;
            member.LastName = request.LastName;
            member.Id = Guid.NewGuid();

            _memberRepository.Add(member);
            _uow.Commit();

            return response;
        }

        public FindMemberResponse FindMembers(FindMemberRequest request)
        {
            FindMemberResponse response = new FindMemberResponse();
            IList<MemberView> members = new List<MemberView>();

            if (request.All)
            {
                members = _memberRepository.FindAll().ConvertToMemberViews();
            }
            else
            {
                Member member = _memberRepository.FindBy(new Guid(request.MemberId));
                members.Add(member.ConvertToMemberView());
            }

            response.MembersFound = members;
            response.Success = true;
            return response;
        }


	}
}

