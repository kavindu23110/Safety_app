using Safety_app.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Safety_app.Data.DatabaseOperation.ModeldatabaseOperations
{
    public class PrescriptionOperator : DatabaseOperation<Prescription>
    {
        public PrescriptionOperator(ref SQLiteAsyncConnection database) : base(ref database)
        {
            _database.CreateTableAsync<Prescription>().Wait();
        }

        public override Task<List<Prescription>> FindAsync(Expression<Func<Prescription, bool>> predicate)
        {
            return _database.Table<Prescription>()
                        .Where(predicate)
                        .ToListAsync();
        }

        public override Task<List<Prescription>> GetAsync()
        {
            return _database.Table<Prescription>().ToListAsync();
        }

        public override Task<Prescription> GetSelectedAsync(Expression<Func<Prescription, bool>> predicate)
        {
            return _database.Table<Prescription>().FirstOrDefaultAsync();
        }
    }
}
