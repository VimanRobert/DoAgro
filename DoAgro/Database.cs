using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace DoAgro
{
    public class Database
    {
        private readonly SQLiteAsyncConnection _database;

        public Database(string dbLocal)
        {
            _database = new SQLiteAsyncConnection(dbLocal);
            _database.CreateTableAsync<LocalNotification>();
        }
        public Task<List<LocalNotification>> GetNotificationAsync()
        {
            return _database.Table<LocalNotification>().ToListAsync();
        }
        public Task<int> SaveNotificationAsync(LocalNotification localNotification)
        {
            return _database.InsertAsync(localNotification);
        }
        public Task<int> UpdateNotificationAsync(LocalNotification localNotification)
        {
            return _database.UpdateAsync(localNotification);
        }
        public Task<int> DeleteNotificationAsync(LocalNotification localNotification)
        {
            return _database.DeleteAsync(localNotification);
        }
    }
}
