using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public abstract class Person
    {
        public string Name { get; set; } 

        public int Wins { get; set; }
        public int Losses { get; set; }

        public Person(string name)
        {
            Name = name;
        }

        public int GetRating()
        {
            return Wins - Losses;
        }
    }
}
