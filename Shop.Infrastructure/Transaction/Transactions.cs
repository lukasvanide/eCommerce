using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Shop.Domain.Transaction;
using Shop.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Shop.Infrastructure.Transaction
{
    public class Transactions : ITransaction
    {
        private readonly AplicationDbContext _db;

        public Transactions(AplicationDbContext db)
        {
            _db = db;
        }

        public async Task CommitTransactionAsync()
        {
            await _db.Database.CurrentTransaction?.CommitAsync();
        }

        public void Dispose()
        {
            _db.Database.CurrentTransaction?.Dispose();
        }

        public async Task RollbackTransactionAsync()
        {
            _db.Database.CurrentTransaction?.Rollback();
        }

        public async Task StartTransactionAsync()
        {
            await _db.Database.BeginTransactionAsync();
        }
    }
}
