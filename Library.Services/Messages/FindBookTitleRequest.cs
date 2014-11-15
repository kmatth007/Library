using System;

namespace Library.Services.Messages
{
	public class FindBookTitleRequest
	{
		public string ISBN { get; set;}
		public bool All { get; set;}
	}
}

