using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    internal class Player : IBoard
    {
        public int[,] Grid { get; set; }

        public int Width
        {
            get
            {
                return Grid.GetLength(0);
            }
        }

        public int Height
        {
            get
            {
                return Grid.GetLength(1);
            }
        }

        public int ShipCount { get; set; } = 0;
        public int AttackCount { get; set; } = 0;

        public Player(int width, int height)
        {
            Grid = CreateBoard(width, height);
        }
   
        public int[,] CreateBoard(int width, int height)
        {
            return new int[width, height];
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
                var hit = Grid[x, y] >= (int)PointState.Ship;

                if (hit)
                {
                    Grid[x, y] = (int)PointState.Hit;
                    return true;
                }
                else
                {
                    Grid[x, y] = (int)PointState.Miss;
                }
            }

            return false;
        }

        public bool GameComplete()
        {
            if (ShipCount > 0)
            {
                for (int x = 0; x < Width; x++)
                {
                    for (int y = 0; y < Height; y++)
                    {
                        if (Grid[x, y] == (int)PointState.Ship) return false;
                    }
                }
            }

            return true;
        }
        private void UpdateBoardWithShip(int posX, int posY, Direction direction, int length)
        {

            if (direction == Direction.Horizontal)
            {
                for (int x = posX; x < posX + length; x++)
                {
                    Grid[x, posY] = (int)PointState.Ship;
                }
            }
            else
            {
                for (int y = posY; y < posY + length; y++)
                {
                    Grid[posX, y] = (int)PointState.Ship;
                }
            }
        }

        public void UpdateBoardWithAttack(int posX, int posY)
        {
            throw new NotImplementedException();
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
            var maxX = direction == Direction.Vertical ? Width - 1 :
                Width - length;
            var minX = 0;

            var maxY = direction == Direction.Horizontal ? Height - 1 :
                Height - length;

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
                    if (Grid[x, posY] == (int)PointState.Ship) return true;
                }
            }
            else
            {
                for (int y = posY; y < posY + ship.Length; y++)
                {
                    if (Grid[posX, y] == (int)PointState.Ship) return true;
                }
            }
            return false;
        }



    }
}
