using System;
using System.Collections;
using System.Collections.Generic;
using Library.Services.Views;

namespace Library.Services.Messages
{
	public class FindMemberResponse
	{
		public IEnumerable<MemberView> MembersFound { get; set; }

	}
}

