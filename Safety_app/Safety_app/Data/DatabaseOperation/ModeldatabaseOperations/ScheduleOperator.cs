using Safety_app.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Safety_app.Data.DatabaseOperation.ModeldatabaseOperations
{
    public class ScheduleOperator : DatabaseOperation<Models.Shedule>
    {
        public ScheduleOperator(ref SQLiteAsyncConnection database) : base( ref database)
        {
            _database.CreateTableAsync<Shedule>().Wait();
        }

        public override Task<List<Shedule>> FindAsync(Expression<Func<Shedule, bool>> predicate)
        {
          
            return _database.Table<Shedule>()
                           .Where(predicate)
                           .ToListAsync();
        }

        public override Task<List<Shedule>> GetAsync()
        {
            return _database.Table<Shedule>().ToListAsync();
        }

     

        public override Task<Shedule> GetSelectedAsync(Expression<Func<Shedule, bool>> predicate)
        {
            return _database.Table<Shedule>()
                     .Where(predicate)
                     .FirstOrDefaultAsync();
        }
    }
}
