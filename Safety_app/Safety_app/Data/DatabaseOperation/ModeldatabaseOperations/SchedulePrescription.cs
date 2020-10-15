using Safety_app.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Safety_app.Data.DatabaseOperation.ModeldatabaseOperations
{

    public class SchedulePrescriptionOperater : DatabaseOperation<DrugSchedulePrescription>
    {
        public SchedulePrescriptionOperater(ref SQLiteAsyncConnection database) : base(ref database)
        {
            _database.CreateTableAsync<Drugs>().Wait();
        }

        public override Task<List<DrugSchedulePrescription>> GetAsync()
        {
            return _database.Table<DrugSchedulePrescription>().ToListAsync();
        }
        public override Task<List<DrugSchedulePrescription>> FindAsync(Expression<Func<DrugSchedulePrescription, bool>> predicate)
        {
            return _database.Table<DrugSchedulePrescription>()
                            .Where(predicate)
                            .ToListAsync();
        }

        public override Task<DrugSchedulePrescription> GetSelectedAsync(Expression<Func<DrugSchedulePrescription, bool>> predicate)
        {
            return _database.Table<DrugSchedulePrescription>()
                       .Where(predicate)
                       .FirstOrDefaultAsync();
        }
    }
}
