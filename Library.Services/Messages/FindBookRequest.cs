using System;

namespace Library.Services.Messages
{
	public class FindBookRequest
	{
		public string Id { get; set;}
		public string ISBN { get; set;}
		public bool All { get; set;}


	}
}

