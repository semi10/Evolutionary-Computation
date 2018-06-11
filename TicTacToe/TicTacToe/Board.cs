using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Board
    {
        private int[] board;
        private const int SIZE = 5; // sets the row/column length
        //private static int DIV_FACTOR = 2;
        private int streak = 3; // sets the streak length required to win

        public Board()
        {
            board = new int[SIZE * SIZE];
            resetBoard();
        }

        public void resetBoard()
        {
            /*
              Resets the board to blanks
             */
            for (int i = 0; i < SIZE * SIZE; i++)
                board[i] = 0;
        }

        public bool indexEmpty(int index)
        {
            /*
             * returns true if the location in the board is a blank
             * else: returns false
             */
            return board[index] == 0;
        }

        public bool attemptMove(int index, Individual player)
        {
            if (this.indexEmpty(index))
            {
                setIndex(index, player);
                return true;
            }
            return false;
        }
        public void setIndex(int index, Individual player)
        {
            /*
             * sets the location on the board with a player piece (1 for 'X', 2 for 'O')
             */
            board[index] = player.getValue();
        }
        public void setIndex(int index, int value)
        {
            /*
             * sets the location on the board with a player value (1 for 'X', 2 for 'O')
             */
            board[index] = value;
        }

        public int getIndexValue(int index)
        {
            /*
             * returns the value of an index of the board
             */
            return board[index];
        }

        public bool willWinBlock(int index, int playerNum)
        {
            /*
             * return whether placing at location will result in a win/block (depends on playerNum)
             * basically it's a streak of playerNum, so it's context dependent
             */
            // streak-1 will result a more aggressive behavior (better for blocking ahead on one side)
            bool answer;
            answer = ((countRowStreak(index, playerNum) >= streak) ||
                    (countColumnStreak(index, playerNum) >= streak) ||
                    (countDiagMainStreak(index, playerNum) >= streak) ||
                    (countDiagSecStreak(index, playerNum) >= streak));

            return answer;
        }

        public int countNeighbors(int index, int playerNum)
        {
            /*
             * counts amount of neighbors of given index with player number == playerNum
             * index / SIZE will give the row number 0...SIZE-1
             * index % SIZE will give the column number 0...SIZE-1
             */
            int count = 0;
            int left = index - 1; // left index
            int leftUp = index - SIZE - 1; // left upper index
            int leftBot = index + SIZE - 1; // left bottom index
            int up = index - SIZE; // upper index
            int bot = index + SIZE; // bottom index
            int right = index + 1; // right index
            int rightUp = index - SIZE + 1; // right bottom index
            int rightBot = index + SIZE + 1; // right bottom index
                                             // check left
                                             // check if left and index are on the same row and that left index is legal
            if (left / SIZE == index / SIZE && left >= 0)
                if (board[left] == playerNum)
                    count++;
            // check left upper
            // check if leftUp row is equal to one row above index
            // and leftUp column equals to one column to the left of index column
            // and that leftUp index is legal
            if (leftUp / SIZE == (index - SIZE) / SIZE && leftUp % SIZE == ((index - 1) % SIZE) && leftUp >= 0)
                if (board[leftUp] == playerNum)
                    count++;
            // check lower left
            // check if leftBot row is equal to one row below index
            // and leftBot column equals to one column to the left of index column
            // and that leftBot index is legal
            if (leftBot / SIZE == (index + SIZE) / SIZE && leftUp % SIZE == ((index - 1) % SIZE) && leftBot < SIZE * SIZE)
                if (board[leftBot] == playerNum)
                    count++;
            // check up
            // check if up and index are on the same column and that up index is legal
            if (up % SIZE == ((index - SIZE) % SIZE) && up >= 0)
                if (board[up] == playerNum)
                    count++;
            // check bottom
            // check if bot and index are on the same row and that up index is legal
            if (bot % SIZE == ((index + SIZE) % SIZE) && bot < SIZE * SIZE)
                if (board[bot] == playerNum)
                    count++;
            // check right
            // check if right and index are on the same column and that up index is legal
            if (right / SIZE == index / SIZE && right < SIZE * SIZE)
                if (board[right] == playerNum)
                    count++;
            // check right upper
            // check if rightUp row is equal to one above above index
            // and rightUp column equals to one column to the right of index column
            // and that rightUp index is legal
            if (rightUp / SIZE == (index - SIZE) / SIZE && rightUp % SIZE == ((index + 1) % SIZE) && rightUp >= 0)
                if (board[rightUp] == playerNum)
                    count++;
            // check right bottom
            // check if rightBot row is equal to one above below index
            // and rightBot column equals to one column to the right of index column
            // and that rightBot index is legal
            if (rightBot / SIZE == (index + SIZE) / SIZE && rightBot % SIZE == ((index + 1) % SIZE) && rightBot < SIZE * SIZE)
                if (board[rightBot] == playerNum)
                    count++;
            return count;
        }

        public int countRow(int index, int playerNum)
        {
            /*
             * count amount of pieces with playerNum value in the same row that index is
             */
            int count = 0;
            int row = index / SIZE; // find the row
            int runner = row * SIZE; // initialize a runner index which will run from the START of the row
                                     // while in the same row, count the player pieces in that row
            while (runner / SIZE == row)
            {
                if (board[runner] == playerNum)
                    count++;
                runner++; // advance to the next column (same row)
            }
            return count;
        }

        public int countRowStreak(int index, int playerNum)
        {
            /*
             * count amount of streak (row) with playerNum value starting from the given index
             */
            int count = 0;
            int row = index / SIZE; // find the row
            int runner = index - 1; // initialize a runner index which start running from left of the index
                                    // while in a legal index and in the same row, count the player streak in that row (TO THE LEFT)
            while (runner >= 0 && runner / SIZE == row && board[runner] == playerNum)
            {
                if (board[runner] == playerNum)
                    count++;
                runner--; // advance to the previous column (same row)
            }
            runner = index + 1; // initialize the runner with one place right to the original index
                                // while in a legal index and in same row, count the player streak (TO THE RIGHT)
            while (runner < SIZE * SIZE && runner / SIZE == row && board[runner] == playerNum)
            {
                if (board[runner] == playerNum)
                    count++;
                runner++; // advance to the next column (same row)
            }
            return count + 1;
        }

        public int countColumn(int index, int playerNum)
        {
            /*
             * count amount of pieces with playerNum value in the same column that index is
             */
            int count = 0;
            int col = index % SIZE; // find the column
            int runner = col; // initialize the runner index
            while (runner < SIZE * SIZE)
            { // run on the column and count player pieces
                if (board[runner] == playerNum)
                    count++;
                runner += SIZE; // advance to next row (same column)
            }
            return count;
        }

        public int countColumnStreak(int index, int playerNum)
        {
            /*
             * count amount of streak (column) with playerNum value starting from the given index
             */
            int count = 0;
            int runner = index - SIZE; // initialize the runner index to one row above index row (same column)
                                       // while in a legal and the value on the board is same as playerNum
            while (runner >= 0 && board[runner] == playerNum)
            { // run on the column and count player streak UPWARD
                if (board[runner] == playerNum)
                    count++;
                runner -= SIZE; // advance to previous row (same column)
            }
            runner = index + SIZE; // initialize the runner to one row below index row
                                   // while in a legal index and the value on the board is same as playerNum
            while (runner < SIZE * SIZE && board[runner] == playerNum)
            { // run on the column and count player streak DOWNWARD
                if (board[runner] == playerNum)
                    count++;
                runner += SIZE; // advance to next row (same column)
            }
            return count + 1;
        }  

        public int countDiagMainStreak(int index, int playerNum)
        {
            /*
             * count amount of streak with playerNum value
             */
            int count = 0;
            int runner = index - SIZE - 1; // initialize starting position to left upper from index
                                           // prevent checking if original index is on the left edge (left up to it is right edge)
            if (runner % SIZE != SIZE - 1)
            {
                // run while in legal index and the piece belongs to playerNum
                while (runner >= 0 && board[runner] == playerNum)
                {
                    count++;
                    // break if reached left border
                    if (runner % SIZE == 0)
                        break;
                    runner = runner - SIZE - 1;
                }
            }
            runner = index + SIZE + 1; // initialize starting position to right bottom from index
                                       // prevent checking if original index is on the right edge (right bottom to it is left edge)
            if (runner % SIZE != 0)
            {
                // run while in legal index and the piece belongs to playerNum
                while (runner < SIZE * SIZE && board[runner] == playerNum)
                {
                    count++;
                    if (runner % SIZE == SIZE - 1)
                        break;
                    runner += SIZE + 1;
                }
            }
            return count + 1;
        }

        //public int countDiagSec(int index, int playerNum)
        //{
        //    /*
        //     * count amount of pieces with playerNum value in the same
        //     * upper left to bottom right diagonal that the index is in
        //     */
        //    int count = 0;
        //    int runner = index;
        //    // find the starting position (run left and down until reaching bottom or left boundary)
        //    // if runner+SIZE-1 equals or greater than SIZE*SIZE, we reached the bottom border
        //    // if runner % SIZE equals zero, reached left border
        //    while (runner + SIZE - 1 < SIZE * SIZE && runner % SIZE != 0)
        //    {
        //        runner = runner + SIZE - 1;
        //    }
        //    // run until reaching the top border
        //    // if runner equals or greater than SIZE*SIZE, we passed the bottom border
        //    while (runner >= 0)
        //    {
        //        if (board[runner] == playerNum)
        //            count++;
        //        // if runner % SIZE equals SIZE-1, we have reached the right border, stop counting
        //        if (runner % SIZE == SIZE - 1)
        //            break;
        //        runner = runner - SIZE + 1;
        //    }
        //    return count;
        //}

        public int countDiagSecStreak(int index, int playerNum)
        {
            /*
             * count amount of streak with playerNum value
             */
            int count = 0;
            int runner = index - SIZE + 1; // initialize starting position to right upper from index

            if (runner % SIZE != 0)
            {
                // run while in legal index and the piece belongs to playerNum
                while (runner >= 0 && board[runner] == playerNum)
                {
                    count++;
                    // break if reached right border
                    if (runner % SIZE == SIZE - 1)
                        break;
                    runner = runner - SIZE + 1;
                }
            }
            runner = index + SIZE - 1; // initialize starting position to right bottom from index

            if (runner % SIZE != SIZE - 1)
            {
                // run while in legal index and the piece belongs to playerNum
                while (runner < SIZE * SIZE && board[runner] == playerNum)
                {
                    count++;
                    if (runner % SIZE == 0)
                        break;
                    runner = runner + SIZE - 1;
                }
            }
            return count + 1;
        }

        //public int countCorners(int playerNum)
        //{
        //    int count = 0;
        //    if (board[0] == playerNum)
        //        count++;
        //    if (board[SIZE - 1] == playerNum)
        //        count++;
        //    if (board[SIZE * SIZE - SIZE] == playerNum)
        //        count++;
        //    if (board[SIZE * SIZE - 1] == playerNum)
        //        count++;
        //    return count;
        //}

        public int checkWin(Individual player)
        {
            /*
             * Checks whether a board has a winning state in it
             * row, column or a diagonal streak of SIZE/2
             * 
             * player == 1 --> 'X'
             * player == 2 --> 'O'
             * returned value of 0 means there is no winner and there are still blank locations to play
             * returned value of -1 means the game ended as a draw
             */

            // counter for a streak of player pieces
            int count = 0;
            // check rows
            for (int i = 0; i < SIZE * SIZE; i++)
            {
                // encountered player piece --> increase counter
                if (board[i] == player.getValue())
                    count++;
                else // streak is broken --> reset the counter
                    count = 0;
                // if the counter has sufficient streak, return the player as the winner
                if (count == streak)
                {
                    return player.getValue(); // player won
                }
                // reached the end of a row (last column) --> reset the counter
                if (i % SIZE == SIZE - 1)
                {
                    count = 0;
                }
            }

            // check columns
            for (int i = 0, col = 0; i < SIZE * SIZE; i++)
            {
                /* col is a variable which represent the current column and is increased when starting a new column count
                 * board[col + (i%SIZE)*SIZE] example:
                 *     0 1 2
                 *  ---------  
                 * 0|  0 1 2
                 * 1|  3 4 5
                 * 2|  6 7 8
                 * 
                 * for location 0, 3, 6 checking
                 * location 0: col=0 i=0 SIZE=3 --> col + (i%SIZE)*SIZE = 0 + (0%3)*3 = 0 + 0 = 0
                 * location 3: col=0 i=1 SIZE=3 --> col + (i%SIZE)*SIZE = 0 + (1%3)*3 = 0 + 3 = 3
                 * location 6: col=0 i=2 SIZE=3 --> col + (i%SIZE)*SIZE = 0 + (2%3)*3 = 0 + 6 = 6
                 * 
                 * for location 1, 4, 7 checking
                 * location 0: col=1 i=3 SIZE=3 --> col + (i%SIZE)*SIZE = 1 + (3%3)*3 = 1 + 0 = 1
                 * location 3: col=1 i=4 SIZE=3 --> col + (i%SIZE)*SIZE = 1 + (4%3)*3 = 1 + 3 = 3
                 * location 6: col=1 i=5 SIZE=3 --> col + (i%SIZE)*SIZE = 1 + (5%3)*3 = 1 + 6 = 6
                 * 
                 * for location 2, 5, 8 checking
                 * location 0: col=2 i=6 SIZE=3 --> col + (i%SIZE)*SIZE = 2 + (6%3)*3 = 2 + 0 = 2
                 * location 3: col=2 i=7 SIZE=3 --> col + (i%SIZE)*SIZE = 2 + (7%3)*3 = 2 + 3 = 5
                 * location 6: col=2 i=8 SIZE=3 --> col + (i%SIZE)*SIZE = 2 + (8%3)*3 = 2 + 6 = 8
                 * 
                 */
                // encountered player piece --> increase counter
                if (board[col + (i % SIZE) * SIZE] == player.getValue())
                    count++;
                else // streak is broken --> reset the counter
                    count = 0;
                // if the counter has sufficient streak, return the player as the winner
                if (count == streak)
                {
                    return player.getValue(); // player won
                }
                // reached the end of a column (last row) --> reset the counter
                if (i % SIZE == SIZE - 1)
                {
                    count = 0;
                    // only increase col variable after the first iteration (the above 'if' is invoked at i==0)
                    if (i > 0)
                        col++;
                }
            }

            // check Left To Right diagonals from top to bottom (main diagonals)
            for (int i = 0; i < SIZE * SIZE; i++)
            {
                // for each iteration of i, reset the counter
                count = 0;
                // start at i and iterate to the last index
                // increment j with SIZE+1
                // (+SIZE will result in getting the next row, +1 will result in one index to the right)
                for (int j = i; j < SIZE * SIZE; j += SIZE + 1)
                {
                    // count player pieces
                    if (board[j] == player.getValue())
                        count++;
                    else // reset the counter if the streak is broken
                        count = 0;
                    // check if the count streak is sufficient for a win
                    if (count == streak)
                        return player.getValue();
                    // if j is out of bound of the array index
                    // or reached the right border (j % SIZE == SIZE-1), break the loop
                    if (j >= SIZE * SIZE || j % SIZE == SIZE - 1)
                        break;
                }
            }
            // check Left To Right diagonals from bottom to top (secondary diagonals)
            // start at the end of the board (last index) and go backward until reaching 0
            for (int i = SIZE * SIZE - 1; i >= 0; i--)
            {
                // for each iteration of i, reset the counter
                count = 0;
                // start at i and iterate to the last index
                // decrement j with SIZE-1
                // (-SIZE will result in getting the previous row, -1 will result in one index to the left)
                for (int j = i; j > 0; j -= (SIZE - 1))
                {
                    // count player pieces
                    if (board[j] == player.getValue())
                        count++;
                    else // reset the counter if the streak is broken
                        count = 0;
                    // check if the count streak is sufficient for a win
                    if (count == streak)
                        return player.getValue();
                    // if j is out of bound of the array index
                    // or reached the right border (j % SIZE == 0), break the loop
                    if (j < 0 || j % SIZE == SIZE - 1)
                        break;
                }
            }

            // check draw
            for (int i = 0; i < SIZE * SIZE; i++)
            {
                // if encountered a blank location, return 0 meaning the game can still be played
                if (board[i] == 0)
                    return 0;
            }
            // none of the above returns invoked --> game ended as a draw
            return -1;
        }
        public void printBoard()
        {
            /*
             * prints the board
             */
            Console.WriteLine("  ");
            for (int i = 0; i < SIZE; i++)
                Console.WriteLine(" " + i);

            for (int i = 0, col = 0; i < SIZE * SIZE; i++)
            {
                if (i % SIZE == 0)
                {
                    Console.WriteLine("");
                    for (int j = 0; j < SIZE - 1; j++)
                        Console.WriteLine("  -");
                    Console.WriteLine("");
                    Console.WriteLine((col++) + " |");
                }

                if (board[i] == 0)
                    Console.WriteLine(" ");
                if (board[i] == 1)
                    Console.WriteLine("X");
                if (board[i] == 2)
                    Console.WriteLine("O");
                Console.WriteLine("|");
            }
            Console.WriteLine("\n");
        }

        public int getBoardSize()
        {
            return SIZE * SIZE;
        }

        public int getBoardSizeRow()
        {
            return SIZE;
        }

        public int getStreak()
        {
            return streak;
        }
    }
}
