using Microsoft.VisualStudio.TestTools.UnitTesting;
using Battleship;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Tests
{
    [TestClass()]
    public class PersonTests
    {
        [TestMethod()]
        public void GetRatingTest()
        {

            var p = new Player(10, 10);
            var ship1 = new Ship(2);
            var ship2 = new Ship(3);

            p.AddShip(1, 1, ship1, Direction.Horizontal);
            p.AddShip(1, 2, ship2, Direction.Vertical);

            p.TakeAttack(1, 1);
            p.TakeAttack(2, 1);
            p.TakeAttack(1, 2);
            p.TakeAttack(1, 3);
            p.TakeAttack(1, 4);

            Assert.AreEqual(true, p.PlayerLostGame());
            Assert.AreEqual(-1, p.GetRating());

        }
    }
}