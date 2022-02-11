using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public enum PointState
    {
        Empty = 0,  // Empty point
        Miss = 1,   // A point that has no ship and is recorded as a miss
        Ship = 2,   // A ship point that has not been hit
        Hit = 3     // A point that is a hit on the ship
    }

    public enum Direction
    {
        Horizontal,
        Vertical
    }
}
