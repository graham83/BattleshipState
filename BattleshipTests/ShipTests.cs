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
    public class ShipTests
    {
        [TestMethod()]
        public void ShipTest()
        {
            var ship = new Ship(8);
            Assert.AreEqual(8, ship.Length);
        }
    }
}