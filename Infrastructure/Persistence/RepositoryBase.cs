﻿using Application.Interfaces;
using Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure.Persistence
{
	public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
	{
		protected ApplicationDbContext ApplicationDbContext { get; set; }
		public RepositoryBase(ApplicationDbContext applicationDbContext)
		{
			ApplicationDbContext = applicationDbContext;
		}

		public IQueryable<T> FindAll()
		{
			return ApplicationDbContext.Set<T>().AsNoTracking();
		}
		public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
		{
			return ApplicationDbContext.Set<T>().Where(expression).AsNoTracking();
		}
		public void Create(T entity)
		{
			ApplicationDbContext.Set<T>().Add(entity);
		}
		public void Update(T entity)
		{
			ApplicationDbContext.Set<T>().Update(entity);
		}
		public void Delete(T entity)
		{
			ApplicationDbContext.Set<T>().Remove(entity);
		}
	}
}
