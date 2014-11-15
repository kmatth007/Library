using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;

namespace Library.Infrastructure.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{
		private Dictionary<IAggregrateRoot, IUnitOfWorkRepository> addedEntites;
		private Dictionary<IAggregrateRoot, IUnitOfWorkRepository> changedEntites;
		private Dictionary<IAggregrateRoot, IUnitOfWorkRepository> deletedEntities;

		public UnitOfWork()
		{
			addedEntites =
				new Dictionary<IAggregrateRoot, IUnitOfWorkRepository> ();
			changedEntites = 
				new Dictionary<IAggregrateRoot, IUnitOfWorkRepository> ();
			deletedEntities =
				new Dictionary<IAggregrateRoot, IUnitOfWorkRepository> ();
		}

		public void RegisterAmended(IAggregrateRoot entity, IUnitOfWorkRepository unitOfWorkRepository)
		{
			if (!changedEntites.ContainsKey(entity)) {
				changedEntites.Add(entity, unitOfWorkRepository);

			}

		}

		public void RegisterNew(IAggregrateRoot entity, IUnitOfWorkRepository unitOfWorkRepository)
		{
			if (!addedEntites.ContainsKey(entity)) {
				addedEntites.Add (entity, unitOfWorkRepository);
			}
		}

		public void RegisterRemoved(IAggregrateRoot entity, IUnitOfWorkRepository unitOfWorkRepository)
		{
			if (!deletedEntities.ContainsKey(entity)) {
				deletedEntities.Add (entity, unitOfWorkRepository);
			}
		}

		public void Commit()
		{
			using (TransactionScope scope = new TransactionScope ()) 
			{
				foreach (IAggregrateRoot entity in this.addedEntites.Keys) {
					this.addedEntites[entity].PersistCreationOf (entity);
			}

			foreach (IAggregrateRoot entity in this.changedEntites.Keys) {
				this.changedEntites[entity].PersistUpdateOf (entity);
			}

			foreach (IAggregrateRoot entity in this.deletedEntities.Keys) {
				this.deletedEntities[entity].PersistDeletionOf (entity);
			}

				scope.Complete();
		}

	}
}
}

