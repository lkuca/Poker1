using SQLite;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Poker1
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "poker.db3");
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<WinRecord>().Wait();
        }

        public Task<int> SaveWinRecordAsync(WinRecord record)
        {
            return _database.InsertAsync(record);
        }

        public Task<int> GetPlayerWinsAsync()
        {
            return _database.Table<WinRecord>().CountAsync(r => r.IsPlayerWin);
        }

        public Task<int> GetPcWinsAsync()
        {
            return _database.Table<WinRecord>().CountAsync(r => r.IsPcWin);
        }
    }

    public class WinRecord
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public bool IsPlayerWin { get; set; }
        public bool IsPcWin { get; set; }
        public DateTime Date { get; set; }
    }
}