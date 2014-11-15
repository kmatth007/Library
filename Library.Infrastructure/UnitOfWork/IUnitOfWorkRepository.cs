using System;

namespace Library.Infrastructure.UnitOfWork
{
	public interface IUnitOfWorkRepository
	{
		void PersistCreationOf(IAggregrateRoot entity);
		void PersistUpdateOf(IAggregrateRoot entity);
		void PersistDeletionOf(IAggregrateRoot entity);


	}
}

