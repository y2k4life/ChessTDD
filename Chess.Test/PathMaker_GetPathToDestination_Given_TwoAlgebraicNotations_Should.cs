using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Chess.Test
{
    [TestClass]
    public class PathMaker_GetPathToDestination_Given_TwoAlgebraicNotations_Should
    {
        [TestMethod, Owner("gmb"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_7_Spaces_Given_a1_And_a8()
        {
            var target = new PathMaker(AlgebraicNotation.ToBoardCoordinate("a1"), AlgebraicNotation.ToBoardCoordinate("a8"));
            Assert.AreEqual<int>(7, target.GetPathToDestination().Count());
        }

        [TestMethod, Owner("gmb"), TestCategory("Proven"), TestCategory("Unit")]
        public void Retrun_Empty_Collection_For_a1_and_b3()
        {
            var origin = AlgebraicNotation.ToBoardCoordinate("a1");
            var destination = AlgebraicNotation.ToBoardCoordinate("b3");

            var target = new PathMaker(origin, destination);

            Assert.IsFalse(target.GetPathToDestination().Any());
        }

        [TestMethod, Owner("gmb"), TestCategory("Proven"), TestCategory("Unit")]
        public void Retrun_Empty_Collection_For_Origin_Same_As_Destination()
        {
            var origin = AlgebraicNotation.ToBoardCoordinate("a1");
            var destination = AlgebraicNotation.ToBoardCoordinate("a1");

            var target = new PathMaker(origin, destination);

            Assert.IsFalse(target.GetPathToDestination().Any());
        }

        
        [TestMethod, Owner("gmb"), TestCategory("Proven"), TestCategory("Unit")]
        public void Retrun_Single_Point_For_Single_Move()
        {
            var origin = AlgebraicNotation.ToBoardCoordinate("d8");
            var destination = AlgebraicNotation.ToBoardCoordinate("d7");

            var target = new PathMaker(origin, destination);

            var path = target.GetPathToDestination();
            Assert.IsTrue(AlgebraicNotation.For(path.First()) == "d7");
        }
    }
}
