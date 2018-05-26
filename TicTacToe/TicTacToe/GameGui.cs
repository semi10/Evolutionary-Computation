using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class GameGui : Form
    {
        //private Game game;
        private readonly int WIDTH = 600;
        private readonly int HEIGHT = 600;
        //private Individual playerOne;
        //private Individual playerTwo;
        private readonly int CONTINUE = 0;
        private readonly int ANOTHER_GAME = 1;
        private readonly int QUIT = 2;
        private readonly int DRAW = -1;
        private readonly int HORIZONTAL_MARGIN = 66;
        private readonly int VERTICAL_MARGIN = 74;
        private readonly int BOARD_SIZE = 16;
        private int playerTurn = 1;
        private int playerValue;
        private int SIZE = 4;
        private int streak = 3;
        public Button[] cell;
        Player2 player2;

        public GameGui(/*Game game, Individual opponent*/)
        {
            InitializeComponent();
            //this.game = game;
            //this.playerTwo = opponent;
            //playerOne = new Individual(game.getBoard(), "Player One", false, null, null);
            //playerOne.setValue(1);
            //playerOne.setIsHumanPlayer(true);
            //this.treeDraw = treeDraw;
            //this.playerTwo.setBoard(game.getBoard());

        }

        private void GameGui_Load(object sender, EventArgs e)
        {
            cell = new Button[BOARD_SIZE];
            Size cellSize = new Size(HORIZONTAL_MARGIN, VERTICAL_MARGIN);

            for (int i = 0; i < BOARD_SIZE; i++)
            {
                cell[i] = new Button();
                cell[i].Size = cellSize;
                cell[i].Top = cellSize.Height * (i / (int)Math.Sqrt(BOARD_SIZE));
                cell[i].Left = cellSize.Width * (i % (int)Math.Sqrt(BOARD_SIZE));
                cell[i].Click += new System.EventHandler(cellClick);
                cell[i].Name = Convert.ToString(i);
                cell[i].Tag = "0";
                cell[i].BackColor = Color.White;
                Controls.Add(cell[i]);
            }

            player2 = new Player2(this);
        }
        
        void cellClick(Object sender, EventArgs e)
        { 
            Button currentCell = (Button)sender;
            if (!isEmpty(currentCell))
            {
                MessageBox.Show("This cell is already occupied", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                currentCell.Text = "O";
                currentCell.Tag = "2";
                currentCell.BackColor = Color.Red;
                checkWin(playerTurn);
                if (checkWin(playerTurn) == 2)
                {
                    MessageBox.Show("Player two is the Winner!!!", "Winner!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    resetGame();
                    return;
                }
                playerTurn = 1;
                playerTurn = player2.makeMove();
            }
        }

        public void resetGame()
        {
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                cell[i].Text = " ";
                cell[i].BackColor = Color.White;
                cell[i].Tag = "0";
            }
        } 

        public bool isEmpty(Button currentCell)
        {
            if (currentCell.Text != "X" && currentCell.Text != "O")
                return true;
            return false;
        }

        public int checkWin(int player)
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
                if (Convert.ToInt32(cell[i].Tag) == player)
                    count++;
                else // streak is broken --> reset the counter
                    count = 0;
                // if the counter has sufficient streak, return the player as the winner
                if (count == streak)
                {
                    return player; // player won
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
                if (Convert.ToInt32(cell[col + (i % SIZE) * SIZE].Tag) == player)
                    count++;
                else // streak is broken --> reset the counter
                    count = 0;
                // if the counter has sufficient streak, return the player as the winner
                if (count == streak)
                {
                    return player; // player won
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

            /////// ABORTED DUE TO CHECKING OF EACH COORDINATE'S DIAGONALS ///////
            //		// check main diagonal
            //		count=0;
            //		for(int i=0; i<SIZE*SIZE; i+=SIZE+1){
            //			/*
            //			 * main diagonal checking example:
            //			 *     0 1 2
            //			 *  ---------  
            //			 * 0|  0 1 2
            //			 * 1|  3 4 5
            //			 * 2|  6 7 8
            //			 * 
            //			 * for location 0, 4, 8 checking
            //			 * location 0: i=0 SIZE=3
            //			 * location 4: i increased by SIZE + 1 --> 0 += SIZE+1 --> 0 += 3+1 --> i=4
            //			 * location 8: i increased by SIZE + 1 --> 4 += SIZE+1 --> 4 += 3+1 --> 4 += 4 --> i=8 
            //			 */
            //			if(board[i] == player.getValue())
            //				count++;
            //			else
            //				count = 0;
            //			if (count == SIZE/2)
            //				return player.getValue();
            //		}
            //		//		if (count == SIZE)
            //		//			return player.getValue();
            //
            //		// check secondary diagonal
            //		count=0;
            //		for(int i=SIZE-1; i<SIZE*SIZE-1; i+=SIZE-1){
            //			/*
            //			 * secondary diagonal checking example:
            //			 *     0 1 2
            //			 *  ---------  
            //			 * 0|  0 1 2
            //			 * 1|  3 4 5
            //			 * 2|  6 7 8
            //			 * 
            //			 * for location 2, 4, 6 checking
            //			 * location 0: i=SIZE-1 --> i=3-1 --> i=2 SIZE=3
            //			 * location 4: i increased by SIZE - 1 --> 2 += SIZE-1 --> 2 += 3-1 --> 2 += 2 --> i=4
            //			 * location 6: i increased by SIZE - 1 --> 4 += SIZE-1 --> 4 += 3-1 --> 4 += 2 --> i=6
            //			 */
            //			if(board[i] == player.getValue())
            //				count++;
            //			else
            //				count = 0;
            //			if (count == SIZE/2)
            //				return player.getValue();
            //		}

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
                    if (Convert.ToInt32(cell[j].Tag) == player)
                        count++;
                    else // reset the counter if the streak is broken
                        count = 0;
                    // check if the count streak is sufficient for a win
                    if (count == streak)
                        return player;
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
                    if (Convert.ToInt32(cell[j].Tag) == player)
                        count++;
                    else // reset the counter if the streak is broken
                        count = 0;
                    // check if the count streak is sufficient for a win
                    if (count == streak)
                        return player;
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
                if (Convert.ToInt32(cell[i].Tag) == 0)
                    return 0;
            }
            // none of the above returns invoked --> game ended as a draw
            return -1;
        }
    }


    public class Player2 
    {
        GameGui gui;
        public Player2(GameGui _gui)
        {
            gui = _gui;
        }

        public int makeMove()
        {
            Random rnd = new Random();
            bool successfulMove = false;
            while (!successfulMove)
            {
                int i = rnd.Next(15);
                if (gui.cell[i].Tag == "0")
                {
                    gui.cell[i].Text = "X";
                    gui.cell[i].Tag = "1";
                    gui.cell[i].BackColor = Color.Green;
                    successfulMove = true;
                }

            }
            return 2;
        }
    }

}
