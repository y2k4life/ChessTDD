using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class AlgebraicNotation
    {
        private AlgebraicNotation()
        {
        }

        /// <summary>
        /// Converts a given algebraic notation to a <see cref="BoardCoordinate"/>.
        /// </summary>
        /// <param name="algebraicNotation">The algebraic notation.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">
        /// algebraicNotation
        /// </exception>
        public static BoardCoordinate ToBoardCoordinate(string algebraicNotation)
        {
            if (algebraicNotation.Length < 2)
                throw new ArgumentException("algebraicNotation");

            int x = Convert.ToInt32(algebraicNotation[0]) - 96;
            int y = Convert.ToInt32(algebraicNotation[1]) - 48;

            if (x > 8 || x < 0 || y > 8)
                throw new ArgumentException("algebraicNotation");

            return new BoardCoordinate(x, y);
        }

        public static string For(BoardCoordinate boardCoordinate)
        {
            if (!boardCoordinate.IsCoordinateValidForBoardSize(8))
                throw new ArgumentException("boardCoordinate");

            char x = (char)(boardCoordinate.X + 96);
            char y = (char)(boardCoordinate.Y + 48);

            return string.Concat(x, y);
        }
    }
}
