using Safety_app.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Safety_app.Data.DatabaseOperation.ModeldatabaseOperations
{
    public class Drug_scheduleOperator : DatabaseOperation<Drug_Schedule>
    {


        public Drug_scheduleOperator(ref SQLiteAsyncConnection database) : base(ref database)
        {
            _database.CreateTableAsync<Drugs>().Wait();
        }

        public override Task<List<Drug_Schedule>> GetAsync()
        {
            return _database.Table<Drug_Schedule>().ToListAsync();
        }
        public override Task<Drug_Schedule> FindAsync(Expression<Func<Drug_Schedule, bool>> predicate)
        {
            return _database.Table<Drug_Schedule>()
                            .Where(predicate)
                            .FirstOrDefaultAsync();
        }

    }
}
