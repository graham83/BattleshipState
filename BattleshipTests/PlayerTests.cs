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
    public class PlayerTests
    {
        
        [TestMethod()]
        public void PlayerTest()
        {
            var p = new Player(10, 10);

            Assert.AreEqual(10, p.BoardWidth);
            Assert.AreEqual(10, p.BoardHeight);
        }


        [TestMethod()]
        public void PlayerTestBadInit()
        {
            var p = new Player(-5, 0);

            Assert.AreEqual(10, p.BoardWidth);
            Assert.AreEqual(10, p.BoardHeight);
        }

        [TestMethod()]
        public void CreateBoardTest()
        {
            var p = new Player(5, 5);

            var board = p.CreateBoard(8, 5);
            
            Assert.AreEqual(8, board.GetLength(0));

            Assert.AreEqual(5, board.GetLength(1));
        }

        [TestMethod()]
        public void CreateBoardTestBadSize()
        {
            var p = new Player(0,0);

            var board = p.CreateBoard(-1, -1);

            Assert.AreEqual(10, board.GetLength(0));

            Assert.AreEqual(10, board.GetLength(1));
        }

        [TestMethod()]
        public void AddShipTestBadPosition()
        {
            var p = new Player(4, 4);
            var ship = new Ship(4);
            var result = p.AddShip(5, 5, ship, Direction.Horizontal);
            Assert.AreEqual(false, result);
        }



        [TestMethod()]
        public void AddShipTestOversize()
        {
            var p = new Player(4, 4);
            var ship = new Ship(5);
            var result = p.AddShip(1, 1, ship, Direction.Horizontal);
            Assert.AreEqual(false, result);
        }

        [TestMethod()]
        public void AddShipTestGood()
        {
            var p = new Player(10, 10);
            var ship = new Ship(5);
            var result = p.AddShip(5, 5, ship, Direction.Vertical);
            Assert.AreEqual(true, result);
        }

        [TestMethod()]
        public void AddShipTestCount()
        {
            var p = new Player(10, 10);
            var ship = new Ship(5);
            var result = p.AddShip(5, 5, ship, Direction.Vertical);
            var ship2 = new Ship(2);
            var result2 = p.AddShip(1, 1, ship, Direction.Vertical);

            Assert.AreEqual(2, p.ShipCount);
        }

        [TestMethod()]
        public void AddShipTestConflict()
        {
            var p = new Player(10, 10);
            var ship = new Ship(5);
            var result1 = p.AddShip(2, 2, ship, Direction.Vertical);
            var ship2 = new Ship(2);
            Assert.AreEqual(true, result1);
            var result2 = p.AddShip(2,3,ship2, Direction.Vertical);
            Assert.AreEqual(false, result2);
        }

        [TestMethod()]
        public void TakeAttackTestHit()
        {
            var p = new Player(10, 10);
            var ship = new Ship(4);
            var result1 = p.AddShip(2, 2, ship, Direction.Horizontal);
            var isHit = p.TakeAttack(3, 2);
            Assert.AreEqual(true, isHit);
        }

        [TestMethod()]
        public void TakeAttackTestMiss()
        {
            var p = new Player(10, 10);
            var ship = new Ship(4);
            var result1 = p.AddShip(2, 2, ship, Direction.Vertical);
            var isHit = p.TakeAttack(2,9);
            Assert.AreEqual(false, isHit);
        }

        [TestMethod()]
        public void TakeAttackTestBadPosition()
        {
            var p = new Player(10, 10);
         
            var isHit = p.TakeAttack(10, 10);
            Assert.AreEqual(false, isHit);
        }

        [TestMethod()]
        public void PlayerLostGameTestFinished()
        {
            var p = new Player(10, 10);
            var ship1 = new Ship(2);
            var ship2 = new Ship(3);

            p.AddShip(1,1,ship1, Direction.Horizontal);
            p.AddShip(1,2,ship2, Direction.Vertical);

            p.TakeAttack(1, 1);
            p.TakeAttack(2, 1);
            p.TakeAttack(1, 2);
            p.TakeAttack(1, 3);
            p.TakeAttack(1, 4);

            Assert.AreEqual(true, p.PlayerLostGame());
            
        }

        [TestMethod()]
        public void PlayerLostGameTestStillGoing()
        {
            var p = new Player(10, 10);
            var ship1 = new Ship(2);
            var ship2 = new Ship(3);

            p.AddShip(0, 0, ship1, Direction.Horizontal);
            p.AddShip(0, 1, ship2, Direction.Vertical);

            p.TakeAttack(0, 0);
            p.TakeAttack(1, 0);
   
            Assert.AreEqual(false, p.PlayerLostGame());

        }

        [TestMethod()]
        public void PlayerLostGameTestNotStarted()
        {
            var p = new Player(10, 10);
         
            Assert.AreEqual(false, p.PlayerLostGame());

        }

    }
}