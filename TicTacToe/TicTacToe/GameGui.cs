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
        private readonly int WIDTH = 600;
        private readonly int HEIGHT = 600;
        private Individual playerOne;
        private Individual playerTwo;
        private readonly int CONTINUE = 0;
        private readonly int ANOTHER_GAME = 1;
        private readonly int QUIT = 2;
        private readonly int DRAW = -1;
        private readonly int HORIZONTAL_MARGIN = 66;
        private readonly int VERTICAL_MARGIN = 74;
        private readonly int BOARD_SIZE = 16;
        private int playerTurn = 1;
        private int playerValue;

        public GameGui(/*Game game, Individual opponent*/)
        {
            InitializeComponent();


        }

        private void GameGui_Load(object sender, EventArgs e)
        {
            Button[] cell = new Button[BOARD_SIZE];
            Size cellSize = new Size(HORIZONTAL_MARGIN, VERTICAL_MARGIN);

            for (int i = 0; i < BOARD_SIZE; i++)
            {
                cell[i] = new Button();
                cell[i].Size = cellSize;
                cell[i].Top = cellSize.Height * (i / (int)Math.Sqrt(BOARD_SIZE));
                cell[i].Left = cellSize.Width * (i % (int)Math.Sqrt(BOARD_SIZE));
                cell[i].Click += new System.EventHandler(cellClick);
                Controls.Add(cell[i]);
            }
        }
        
        void cellClick(Object sender, EventArgs e)
        { 
            Button currentCell = (Button)sender;
            if (playerTurn == 1)
            {
                currentCell.Text = "O";
                playerTurn = 2;
            }
            else
            {
                currentCell.Text = "X";
                playerTurn = 1;
            }
        }

    }
}
