using SQLite;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Safety_app.Data.DatabaseOperation
{
    public abstract class DatabaseOperation<T> : IDatabaseoperation<T> where T : class
    {
        public readonly SQLiteAsyncConnection _database;
        public DatabaseOperation(ref SQLiteAsyncConnection database)
        {
            _database = database;

        }


        public Task<int> DeleteAsync(T Entity)
        {
            return _database.DeleteAsync(Entity);
        }
        public abstract Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate);

        public abstract Task<List<T>> GetAsync();
        public abstract Task<T> GetSelectedAsync(Expression<Func<T, bool>> predicate);

        public Task<int> saveAsync(T Entity)
        {
            return _database.InsertAsync(Entity);
        }

        public Task<int> updateAsync(T Entity)
        {

            return _database.UpdateAsync(Entity);
        }
     
        


    }
}
