using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public interface IBoard
    {
       
        public int ShipCount { get; set; }
        
        public int AttackCount { get; set; }

        public int[,] CreateBoard(int width, int height);

        public bool AddShip(int posX, int posY, Ship ship, Direction direction);

        public bool TakeAttack(int posX, int posY); 

        public bool PlayerLostGame();


    }
}
