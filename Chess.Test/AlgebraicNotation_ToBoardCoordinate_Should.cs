using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chess.Test.BoardTests
{
    [TestClass]
    public class AlgebraicNotation_ToBoardCoordinate_Should
    {
        [TestMethod, Owner("gmb"), TestCategory("Proven"), TestCategory("Unit")]
        public void Result_In_BoardCoordinate_1_1_For_a1()
        {
            var target = AlgebraicNotation.ToBoardCoordinate("a1");
            Assert.IsTrue(target.Matches(1, 1));
        }

        [TestMethod, Owner("gmb"), TestCategory("Proven"), TestCategory("Unit")]
        public void Result_In_BoardCoordinate_8_8_For_h8()
        {
            var target = AlgebraicNotation.ToBoardCoordinate("h8");
            Assert.IsTrue(target.Matches(8, 8));
        }

        [TestMethod, Owner("gmb"), TestCategory("Proven"), TestCategory("Unit")]
        public void Throw_ArgumentException_For_A1()
        {
            ExtendedAssert.Throws<ArgumentException>(() => AlgebraicNotation.ToBoardCoordinate("A1"));
        }

        [TestMethod, Owner("gmb"), TestCategory("Proven"), TestCategory("Unit")]
        public void Throw_ArgumentException_For_i1()
        {
            ExtendedAssert.Throws<ArgumentException>(() => AlgebraicNotation.ToBoardCoordinate("i1"));
        }

        [TestMethod, Owner("gmb"), TestCategory("Proven"), TestCategory("Unit")]
        public void Throw_ArgumentException_For_a9()
        {
            ExtendedAssert.Throws<ArgumentException>(() => AlgebraicNotation.ToBoardCoordinate("a9"));
        }

        [TestMethod, Owner("gmb"), TestCategory("Proven"), TestCategory("Unit")]
        public void Throw_ArgumentException_For_1a()
        {
            ExtendedAssert.Throws<ArgumentException>(() => AlgebraicNotation.ToBoardCoordinate("1a"));
        }

        [TestMethod, Owner("gmb"), TestCategory("Proven"), TestCategory("Unit")]
        public void Throw_ArgumentException_For_11()
        {
            ExtendedAssert.Throws<ArgumentException>(() => AlgebraicNotation.ToBoardCoordinate("11"));
        }
          
        [TestMethod, Owner("gmb"), TestCategory("Proven"), TestCategory("Unit")]
        public void ThrowArgumentException_For_a()
        {
            ExtendedAssert.Throws<ArgumentException>(() => AlgebraicNotation.ToBoardCoordinate("a"));
        }
    }
}
   
