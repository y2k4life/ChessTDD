using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace Chess.Acceptance
{
    [Binding]
    public class NormalBoardSetupScenarios
    {
        [When(@"there is a chess board set up as")]
        public void SetBoardInContextFromTable(Table table)
        {
            var builderGenerateBoard = BuildBoardFromTable(table);

            SetInContext(builderGenerateBoard);
        }

        [When(@"there is a move from \((.*),(.*)\) to \((.*),(.*)\)")]
        public void ThereIsAMoveFrom(int startX, int startY, int destinationX, int destinationY)
        {
            var board = GetFromContext<Board>();
            board.MovePiece(BoardCoordinate.For(startX, startY), BoardCoordinate.For(destinationX, destinationY));
        }
                
        [Then(@"the piece at \((.*),(.*)\) should have exactly the following moves")]
        public void ThenThePieceAtShouldHaveTheFollowingMoves(int xCoordinate, int yCoordinate, Table table)
        {
            var board = GetFromContext<Board>();
            var boardMoves = board.GetMovesFrom(BoardCoordinate.For(xCoordinate, yCoordinate)).ToList();

            var tableCoordinates = GetCoordinatesFromTable(table);

            CollectionAssert.AreEquivalent(tableCoordinates, boardMoves);
        }

        [Then(@"the piece at \((.*)\) should have exactly the following range of moves")]
        public void ThenThePieceAtShouldHaveExactlyTheFollowingRangeOfMoves(string coordinate, Table table)
        {
            var board = GetFromContext<Board>();
            
            var boardMoves = board.GetMovesFrom(AlgebraicNotation.ToBoardCoordinate(coordinate)).ToList();

            var tableCoordinates = GetRangeCoordinatesFromAlgebraicTable(table);

            CollectionAssert.AreEquivalent(tableCoordinates, boardMoves);
        }

        [Then(@"the piece at algebraic notation \((.*)\) should have exactly the following moves")]
        public void ThenThePieceAtShouldHaveExactlyTheFollowingMoves(string coordinate, Table table)
        {
            var board = GetFromContext<Board>();
            var boardMoves = board.GetMovesFrom(AlgebraicNotation.ToBoardCoordinate(coordinate)).ToList();

            var tableCoordinates = GetCoordinatesFromAlgebraicTable(table);

            CollectionAssert.AreEquivalent(tableCoordinates, boardMoves);
        }



        private Board BuildBoardFromTable(Table table)
        {
            var builder = new AsciiBoardBuilder();
            var indeces = Enumerable.Range(0, 8).ToList();
            indeces.ForEach(ri => indeces.ForEach(ci => AddNonEmptyPiece(builder, table, ri, ci)));
            var builderGenerateBoard = builder.GenerateBoard();
            return builderGenerateBoard;
        }

        private void AddNonEmptyPiece(AsciiBoardBuilder builder, Table table, int rowIndex, int columnIndex)
        {
            var xCoordinate = columnIndex + 1;
            var yCoordinate = 8 - rowIndex;
            var pieceString = table.Rows[rowIndex][columnIndex];

            if (!string.IsNullOrEmpty(pieceString))
                builder.AddPiece(BoardCoordinate.For(xCoordinate, yCoordinate), pieceString);

        }


        private static T GetFromContext<T>()
        {
            return ScenarioContext.Current.Get<T>();
        }

        private static void SetInContext<T>(T data)
        {
            ScenarioContext.Current.Set<T>(data);
        }

        private static List<BoardCoordinate> GetCoordinatesFromTable(Table tableOfBoardCoordinates)
        {
            return tableOfBoardCoordinates.Rows.Select(r => BoardCoordinate.For(int.Parse(r[0]), int.Parse(r[1]))).ToList();
        }

        private static List<BoardCoordinate> GetCoordinatesFromAlgebraicTable(Table tableOfBoardCoordinates)
        {
            return tableOfBoardCoordinates.Rows.Select(r => AlgebraicNotation.ToBoardCoordinate(r[0])).ToList();
        }

        private static List<BoardCoordinate> GetRangeCoordinatesFromAlgebraicTable(Table tableOfBoardCoordinates)
        {
            var cordinates = new List<BoardCoordinate>();
            foreach (var coordinates in tableOfBoardCoordinates.Rows)
            {
                var path = new PathMaker(AlgebraicNotation.ToBoardCoordinate(coordinates[0]), AlgebraicNotation.ToBoardCoordinate(coordinates[1]));
                cordinates.AddRange(path.GetPathToDestination());
            }

            return cordinates;
        }
    }
}
