using System;

namespace Library.Infrastructure.Query
{
	public class OrderByClause
	{
		public string PropertyName { get; set; }
		public bool Desc { get; set; }

		public OrderByClause(){
		}

	}
}

