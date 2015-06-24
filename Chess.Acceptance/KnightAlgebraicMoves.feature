Feature: Knight Algebraic Moves

Scenario: A knight in its beginning position on an empty board
	When there is a chess board set up as
	   |  a  |  b  |  c  |  d  |  e  |  f  |  g  |  h  |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     | WKn |     |     |     |     |     |     |
	Then the piece at algebraic notation (b1) should have exactly the following moves
	   | Coordinate |
	   | a3         |
	   | c3         |
	   | d2         |
