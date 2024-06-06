using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker1
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Player>().Wait();
        }

        public Task<List<Player>> GetPlayersAsync()
        {
            return _database.Table<Player>().ToListAsync();
        }

        public Task<Player> GetPlayerAsync(int id)
        {
            return _database.Table<Player>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SavePlayerAsync(Player player)
        {
            if (player.Id != 0)
            {
                return _database.UpdateAsync(player);
            }
            else
            {
                return _database.InsertAsync(player);
            }
        }

        public Task<int> DeletePlayerAsync(Player player)
        {
            return _database.DeleteAsync(player);
        }
    }
}
