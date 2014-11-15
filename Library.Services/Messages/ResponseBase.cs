using System;

namespace Library.Services.Messages
{
	public abstract class ResponseBase
	{
		public bool Success { get; set; }
		public string Message { get; set; }
	}
}

