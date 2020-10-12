using Safety_app.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Safety_app.Data.DatabaseOperation.ModeldatabaseOperations
{

    public class SchedulePrescriptionOperater : DatabaseOperation<SchedulePrescription>
    {
        public SchedulePrescriptionOperater(ref SQLiteAsyncConnection database) : base(ref database)
        {
            _database.CreateTableAsync<Drugs>().Wait();
        }

        public override Task<List<SchedulePrescription>> GetAsync()
        {
            return _database.Table<SchedulePrescription>().ToListAsync();
        }
        public override Task<SchedulePrescription> FindAsync(Expression<Func<SchedulePrescription, bool>> predicate)
        {
            return _database.Table<SchedulePrescription>()
                            .Where(predicate)
                            .FirstOrDefaultAsync();
        }
    }
}
