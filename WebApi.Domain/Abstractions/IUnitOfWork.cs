﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using WebApi.Domain.Abstractions.Repository;
using WebApi.Domain.Abstractions.Repository.Identity;

namespace WebApi.Domain.Abstractions
{
    public interface IUnitOfWork: IDisposable
	{
		public ITeacherRepository Teacher { get; }
		public IFacultyRepository Faculty { get; }
        public ISubjectRepository Subject { get; }
		public IIdentityRepository Identity { get; }
		public IStudentRepository Student { get; }
		public ISchoolClassRepository SchoolClass { get; }
        public IMajorRepository Major { get; }
        public ISchoolClassesStudentRepository SchoolClassesStudent { get; }
        public IStudentGradeRepository StudentGrade { get; }

        Task<IDbContextTransaction> BeginTransactionAsync();
		Task CommitAsync();
		Task EndTransactionAsync();
		DbContext GetDbContext();
		Task RollbackTransactionAsync();
	}
}
