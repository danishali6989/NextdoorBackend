﻿
using Microsoft.EntityFrameworkCore.Storage;
using NextDoor.DataLayer;
using NextDoor.Infrastructure.DataLayer;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NextDoor.DataLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;
        private IDbContextTransaction _dbTransaction;

        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void BeginTransaction()
        {
            _dbTransaction = _dataContext.Database.BeginTransaction();
        }

        public async Task BeginTransactionAsync()
        {
            _dbTransaction = await _dataContext.Database.BeginTransactionAsync();
        }

        public int SaveChanges()
        {
            return _dataContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dataContext.SaveChangesAsync();
        }

        public void Commit()
        {
            _dbTransaction.Commit();
        }

        public void Rollback()
        {
            _dbTransaction.Rollback();
        }

        public async Task<int> ExecuteSqlCommandAsync(string sqlCommand, params object[] parameters)
        {
            return await _dataContext.Database.ExecuteSqlRawAsync(sqlCommand, parameters);
        }
    }
}
