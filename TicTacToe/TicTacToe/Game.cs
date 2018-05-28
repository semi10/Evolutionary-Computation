using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Game
    {
        private Board board;
        private const int DRAW = -1;
        private const int START_WIN = 1;
        private const int SECOND_WIN = 2;
        private const int INCOMPLETE_TREE = 0;

        public Game(Board board)
        {
            this.board = board;
        }

        public void setBoard(Board board)
        {
            this.board = board;
        }

        public Board getBoard()
        {
            return board;
        }
        public void playTwoSetMatch(Individual player1, Individual player2)
        {
            /*
             *  play a two game match, each time another player get to start
             */
            int result;
            // set both players the same board instance
            player1.setBoard(board);
            player2.setBoard(board);

            //		System.out.println("Game Between: " + player1.getPlayerName() + " And " + player2.getPlayerName());;
            // make two iteration, each time let another player start (change the order of parameters in playGame method)
            for (int i = 0; i < 2; i++)
            {
                // reset the game board
                board.resetBoard();
                //			System.out.println("Game #" + (i+1));
                if (i % 2 == 0)
                    result = playGame(player1, player2);
                else
                    result = playGame(player2, player1);
                //////////// ONLY PRINTS THE GAME RESULT
                //			switch(result){
                //			case DRAW:
                //				System.out.println("Draw");
                //				break;
                //			case START_WIN:
                //				if(i==0)
                //					System.out.println(player1.getPlayerName() + " Wins");
                //				else
                //					System.out.println(player2.getPlayerName() + " Wins");
                //				break;
                //			case SECOND_WIN:
                //				if(i==0)
                //					System.out.println(player2.getPlayerName() + " Wins");
                //				else
                //					System.out.println(player1.getPlayerName() + " Wins");
                //				break;
                //			case INCOMPLETE_TREE:
                //				break;
                //			default:
                //				break;
                //			}
            }
        }
        public int playGame(Individual startingPlayer, Individual secondPlayer)
        {
            int result = -1;

            // set the starting player value to 1 ('X')
            startingPlayer.setValue(1);
            // set the second player value to 2 ('O')
            secondPlayer.setValue(2);
            //		System.out.println(startingPlayer.getPlayerName() + " Is 'X'");
            //		System.out.println(secondPlayer.getPlayerName() + " Is 'O'");
            //		System.out.println("Player " + startingPlayer.getPlayerName() + " Starts");
            while (true)
            {

                // starting player code block
                //////////////////////////////////////
                // can make either a random move or a move using the strategy tree
                //startingPlayer.makeRandomMove();
                if (!startingPlayer.makeStrategyMove())
                {
                    // an attempt to make a move on an occupied space was made
                    // abort the game
                    Console.WriteLine("Move " + startingPlayer.getValue() + " Failed");
                    Console.WriteLine("SHUTTING GAME DOWN: OBSOLETE GARBAGE");
                    break;
                }
                // check if the starting player move resulted in a win
                result = board.checkWin(startingPlayer);
                if (result != 0)
                    break;
                //////////////////////////////////////
                // starting player code block end

                // second player code block
                //////////////////////////////////////
                //secondPlayer.makeRandomMove();
                if (!secondPlayer.makeStrategyMove())
                {
                    Console.WriteLine("Move " + secondPlayer.getValue() + " Failed");
                    Console.WriteLine("SHUTTING GAME DOWN: OBSOLETE GARBAGE");
                    break;
                }

                result = board.checkWin(secondPlayer);
                if (result != 0)
                    break;
                //////////////////////////////////////
            }
            // add the result accordingly
            switch (result)
            {
                case DRAW:
                    startingPlayer.addDraw(true);
                    secondPlayer.addDraw(false);
                    break;
                case START_WIN:
                    startingPlayer.addWin(true);
                    secondPlayer.addLoss(false);
                    break;
                case SECOND_WIN:
                    secondPlayer.addWin(false);
                    startingPlayer.addLoss(true);
                    break;
                case INCOMPLETE_TREE:
                    Console.WriteLine("Incomplete Tree Error");
                    break;
                default:
                    Console.WriteLine("CATASTROPHIC FAILURE!!!");
                    break;
            }
            //		System.out.println("Final Board State:");
            //		printBoard();
            return result;
        }

        public void printBoard()
        {
            board.printBoard();
        }

        public void resetBoard()
        {
            board.resetBoard();
        }
    }
}
