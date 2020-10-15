using Safety_app.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Safety_app.Data.DatabaseOperation.ModeldatabaseOperations
{
    public class DrugSchedulePrescriptionOperator : DatabaseOperation<DrugSchedulePrescription>
    {


        public DrugSchedulePrescriptionOperator(ref SQLiteAsyncConnection database) : base(ref database)
        {
        _database.CreateTableAsync<DrugSchedulePrescription>().Wait();
        }

        public override Task<List<DrugSchedulePrescription>> GetAsync()
        {
            return _database.Table<DrugSchedulePrescription>().ToListAsync();
        }
        public override Task<List<DrugSchedulePrescription>> FindAsync(Expression<Func<DrugSchedulePrescription, bool>> predicate)
        {
       
           return _database.Table<DrugSchedulePrescription>()
                    .Where(predicate).ToListAsync();

        }

        public override Task<DrugSchedulePrescription> GetSelectedAsync(Expression<Func<DrugSchedulePrescription, bool>> predicate)
        {
            return _database.Table<DrugSchedulePrescription>()
                           .Where(predicate)
                           .FirstOrDefaultAsync();
        }
    }
}
