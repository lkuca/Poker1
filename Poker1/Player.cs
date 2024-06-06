using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker1
{
    public class Player
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; } // Добавляем свойство Id
        public string Name { get; set; }
        public int Wins { get; set; }

        public Player()
        {
            Name = string.Empty; // Initialize Name to an empty string
            Wins = 0;
        }
    }
}
