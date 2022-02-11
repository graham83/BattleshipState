using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public enum PointState
    {
        Empty = 0,
        Miss = 1,
        Ship = 2,
        Hit = 3
    }

    public enum Direction
    {
        Horizontal,
        Vertical
    }
}
