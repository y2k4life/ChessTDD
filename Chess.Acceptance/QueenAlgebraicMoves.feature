Feature: Queen Algebraic Moves

Scenario: A queen in her beginning position on an empty board
	When there is a chess board set up as
	   |  a  |  b  |  c  |  d  |  e  |  f  |  g  |  h  |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |  WQ |     |     |     |     |
	Then the piece at (d1) should have exactly the following range of moves
		| START | END |
		| d1    | d8  |
		| d1    | a1  |
		| d1    | h1  |
		| d1    | a4  |
		| d1    | h5  |

Scenario: A queen surrounded by enemy pieces
	When there is a chess board set up as
	   |  a  |  b  |  c  |  d  |  e  |  f  |  g  |  h  |
	   |     |     |     |  BQ |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |     |     |     |     |     |     |
	   |     |     |  BB |  BB |  BP |     |     |     |
	   |     |     |  BR |  WQ |  BR |     |     |     |
	Then the piece at (d1) should have exactly the following range of moves
         | START | END |
         | d1    | c1  |
         | d1    | c2  |
         | d1    | d2  |
         | d1    | e2  |
         | d1    | e1  |