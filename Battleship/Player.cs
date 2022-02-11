using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Player : IBoard
    {

        public int BoardWidth
        {
            get
            {
                return _grid.GetLength(0);
            }
        }

        public int BoardHeight
        {
            get
            {
                return _grid.GetLength(1);
            }
        }

        public int ShipCount { get; set; } = 0;
        public int AttackCount { get; set; } = 0;

        private int[,] _grid { get; set; }

        public Player(int boardWidth, int boardHeight)
        {
           _grid = CreateBoard(boardWidth, boardHeight);
        }
   
        public int[,] CreateBoard(int width, int height)
        {
            if (width < 1 || height < 1) return new int[10, 10];

            _grid = new int[width, height];

            return _grid;
        }


        public bool AddShip(int posX, int posY, Ship ship, Direction direction)
        {
            if (CheckShipPositionValid(posX, posY, ship, direction))
            {
                UpdateBoardWithShip(posX, posY, direction, ship.Length);
                ShipCount++;
                return true;
            }

            return false;
        }

        public bool TakeAttack(int x, int y)
        {
            AttackCount++;

            if (PositionValid(x, y))
            {
                var hit = _grid[x, y] >= (int)PointState.Ship;

                if (hit)
                {
                    _grid[x, y] = (int)PointState.Hit;
                    return true;
                }
                else
                {
                    _grid[x, y] = (int)PointState.Miss;
                }
            }

            return false;
        }

        public bool PlayerLostGame()
        {
            if (ShipCount > 0)
            {
                for (int x = 0; x < BoardWidth; x++)
                {
                    for (int y = 0; y < BoardHeight; y++)
                    {
                        if (_grid[x, y] == (int)PointState.Ship) return false;
                    }
                }
                return true;
            }

            return false;
   
        }

        private void UpdateBoardWithShip(int posX, int posY, Direction direction, int length)
        {

            if (direction == Direction.Horizontal)
            {
                for (int x = posX; x < posX + length; x++)
                {
                    _grid[x, posY] = (int)PointState.Ship;
                }
            }
            else
            {
                for (int y = posY; y < posY + length; y++)
                {
                    _grid[posX, y] = (int)PointState.Ship;
                }
            }
        }
           
        private bool CheckShipPositionValid(int posX,int posY, Ship ship, Direction direction)
        {
            if (PositionValid(posX, posY, ship.Length, direction))
            {
                return CheckShipExists(posX, posY, ship, direction) ? false : true;
            }
            return false;
        }

        private bool PositionValid(int posX, int posY, int length = 1, Direction direction = Direction.Horizontal)
        {
            var maxX = direction == Direction.Vertical ? BoardWidth - 1 :
                BoardWidth - length;
            var minX = 0;

            var maxY = direction == Direction.Horizontal ? BoardHeight - 1 :
                BoardHeight - length;

            var minY = 0;

            if (posX >= minX && posX <= maxX && posY <= maxY & posY >= minY)
            {
                return true;
            }

            return false;
        }

        private bool CheckShipExists(int posX, int posY, Ship ship, Direction direction)
        {
            if(direction == Direction.Horizontal)
            {
                for (int x = posX; x < posX + ship.Length; x++)
                {
                    if (_grid[x, posY] == (int)PointState.Ship) return true;
                }
            }
            else
            {
                for (int y = posY; y < posY + ship.Length; y++)
                {
                    if (_grid[posX, y] == (int)PointState.Ship) return true;
                }
            }
            return false;
        }



    }
}
