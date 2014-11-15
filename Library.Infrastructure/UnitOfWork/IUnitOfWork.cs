using System;

namespace Library.Infrastructure.UnitOfWork
{
	public interface IUnitOfWork
	{
		void RegisterAmended(IAggregrateRoot entity, IUnitOfWorkRepository unitOfWorkRepository);
		void RegisterNew(IAggregrateRoot entity, IUnitOfWorkRepository unitOfWorkRepository);
		void RegisterRemoved(IAggregrateRoot entity, IUnitOfWorkRepository unitOfWorkRepository);
		void Commit();
	}
}

