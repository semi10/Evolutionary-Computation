using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class GameGui : Form
    {
        private Game game;
        private Individual playerOne;
        private Individual playerTwo;
        private readonly int HORIZONTAL_MARGIN = Screen.PrimaryScreen.Bounds.Width/20;
        private readonly int VERTICAL_MARGIN = Screen.PrimaryScreen.Bounds.Height/13;
        private readonly int BOARD_SIZE = 25;
        private int playerTurn = 1;
        private int SIZE = 5;
        private int streak = 3;
        private Button[] cell;
        DrawTree drawTree;
        public GameGui(Game game, Individual opponent)
        {
            InitializeComponent();
            this.game = game;
            this.playerTwo = opponent;
            playerOne = new Individual(game.getBoard(), "Player One", false, null, null);
            playerOne.setValue(1);
            playerOne.setIsHumanPlayer(true);
            this.playerTwo.setBoard(game.getBoard());
            drawTree = new DrawTree(opponent.getStrategy());
        }

        private void GameGui_Load(object sender, EventArgs e)
        {
            cell = new Button[BOARD_SIZE];
            Size cellSize = new Size(HORIZONTAL_MARGIN, VERTICAL_MARGIN);

            for (int i = 0; i < BOARD_SIZE; i++)
            {
                cell[i] = new Button();
                cell[i].Size = cellSize;
                cell[i].Top = cellSize.Height * (i / (int)Math.Sqrt(BOARD_SIZE + 10))+55;
                cell[i].Left = cellSize.Width* (i % (int)Math.Sqrt(BOARD_SIZE));
                cell[i].Click += new System.EventHandler(cellClick);
                cell[i].Name = Convert.ToString(i);
                cell[i].Tag = "0";
                cell[i].BackColor = Color.White;
                Controls.Add(cell[i]);
            }
        }
         public void markOpponentMove()
        {
            for(int i=0;i< BOARD_SIZE; i++)
            {
                if(game.getBoard().getIndexValue(i)==1)
                {
                    cell[i].Text = "X";
                    cell[i].Tag = 1;
                    cell[i].BackColor = Color.Green;
                }
                if (game.getBoard().getIndexValue(i) == 2)
                {
                    cell[i].Text = "O";
                    cell[i].Tag = 2;
                    cell[i].BackColor = Color.Red;
                }
            }
        }
        void cellClick(Object sender, EventArgs e)
        { 
            Button currentCell = (Button)sender;
            if (!isEmpty(currentCell) || game.getBoard().getIndexValue(Convert.ToInt32(currentCell.Name)) != 0)
            {
                MessageBox.Show("This cell is already occupied", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (playerTurn == 1)
                {
                    currentCell.Text = "X";
                    currentCell.Tag = "1";
                    currentCell.BackColor = Color.Green;
                    game.getBoard().setIndex(Convert.ToInt32(currentCell.Name), playerOne);
                    if (checkWin(playerTurn) == 1)
                    {
                        MessageBox.Show("Player one is the Winner!!!", "Winner!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        resetGame();
                        game.getBoard().resetBoard();
                        playerTurn = 1;                       
                        return;
                    }
                    playerTurn = 2;
                    if(playerTwo.makeStrategyMove()&&playerTurn==2)
                    {
                        markOpponentMove();
                        playerTwo.printEvaluatedBoard();
                        checkWin(playerTurn);
                        if (checkWin(playerTurn) == 2)
                        {
                            MessageBox.Show("Player two is the Winner!!!", "Winner!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            resetGame();
                            game.getBoard().resetBoard();
                            playerTwo.makeStrategyMove();
                            markOpponentMove();
                            playerTurn = 1;
                            return;
                        }
                        playerTurn = 1;
                    }
                }

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

        private void anotherGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Board board = new Board();
            Game game = new Game(board);
            GameGui gui = new GameGui(game, playerTwo);
            this.Close();
            gui.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
