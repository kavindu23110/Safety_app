using Safety_app.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Safety_app.Data.DatabaseOperation.ModeldatabaseOperations
{
    public class DrugOperator : DatabaseOperation<Drugs>
    {
     

        public DrugOperator(ref SQLiteAsyncConnection database) : base(ref database)
        {
            _database.CreateTableAsync<Drugs>().Wait();
        }

        public override Task<List<Drugs>> FindAsync(Expression<Func<Drugs, bool>> predicate)
        {
            return _database.Table<Drugs>()
                           .Where(predicate)
                           .ToListAsync();
        }

        public override Task<List<Drugs>> GetAsync()
        {
            return _database.Table<Drugs>().ToListAsync();
        }

        public override Task<Drugs> GetSelectedAsync(Expression<Func<Drugs, bool>> predicate)
        {
            return _database.Table<Drugs>()
                         .Where(predicate)
                         .FirstOrDefaultAsync();
        }
    }
}
