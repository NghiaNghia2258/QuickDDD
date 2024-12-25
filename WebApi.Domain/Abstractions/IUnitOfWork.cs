﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using WebApi.Domain.Abstractions.Repository;

namespace WebApi.Domain.Abstractions
{
	public interface IUnitOfWork: IDisposable
	{
		public IQuizRepository QuizRepository { get; }
		Task<IDbContextTransaction> BeginTransactionAsync();
		Task CommitAsync();
		Task EndTransactionAsync();
		DbContext GetDbContext();
		Task RollbackTransactionAsync();
	}
}
