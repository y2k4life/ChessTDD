using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chess.Test
{
    [TestClass]
    public class AlgebraicNotation_For_Should
    {
        [TestMethod, Owner("gmb"), TestCategory("Proven"), TestCategory("Unit")]
        public void Retrun_a1_Given_BoardCoordinate_1_1()
        {
            var target = AlgebraicNotation.For(BoardCoordinate.For(1, 1));

            Assert.AreEqual<string>("a1", target);
        }

        [TestMethod, Owner("gmb"), TestCategory("Proven"), TestCategory("Unit")]
        public void Retrun_a2_Given_BoardCoordinate_1_2()
        {
            var target = AlgebraicNotation.For(new BoardCoordinate(1, 2));

            Assert.AreEqual<string>("a2", target);
        }
        
        [TestMethod, Owner("gmb"), TestCategory("Proven"), TestCategory("Unit")]
        public void Throw_ArgumentException_Given_BoardCoordinate_9_9()
        {
            ExtendedAssert.Throws<ArgumentException>(() => AlgebraicNotation.For(new BoardCoordinate(9, 9)));
        }
    }
}
