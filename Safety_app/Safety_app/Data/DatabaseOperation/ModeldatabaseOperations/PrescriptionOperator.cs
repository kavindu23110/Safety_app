using Safety_app.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Safety_app.Data.DatabaseOperation.ModeldatabaseOperations
{
    public class PrescriptionOperator : DatabaseOperation<Prescriptions>
    {
        public PrescriptionOperator(ref SQLiteAsyncConnection database):base(ref database)
        {

        }
        public override Task<List<Prescriptions>> GetAsync()
        {
            return _database.Table<Prescriptions>().ToListAsync();
        }

        public override Task<Prescriptions> FindAsync(Expression<Func<Prescriptions, bool>> predicate)
        {
            return _database.Table<Prescriptions>()
                            .Where(predicate)
                            .FirstOrDefaultAsync();
        }


    }
}
