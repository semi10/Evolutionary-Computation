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
        private static readonly long serialVersionUID = 1L;
        private Game game;
        private readonly int WIDTH = 600;
        private readonly int HEIGHT = 600;
        private Individual playerOne;
        private Individual playerTwo;
        private readonly int CONTINUE = 0;
        private readonly int ANOTHER_GAME = 1;
        private readonly int QUIT = 2;
        private readonly int DRAW = -1;
        private int playerTurn = 1;

        public GameGui(Game game, Individual opponent)
        {
            InitializeComponent();

           // super("GUI Game");
            this.game = game;
            this.playerTwo = opponent;
            playerOne = new Individual(game.getBoard(), "Player One", false, null, null);
            playerOne.setValue(1);
            playerOne.setIsHumanPlayer(true);
            //this.treeDraw = treeDraw;
            this.playerTwo.setBoard(game.getBoard());
            //this.setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);

           // menuBar = new JMenuBar();
           // this.setJMenuBar(menuBar);
           // JMenuGame = new JMenu("Game");

           // JMenuItemNewGame = new JMenuItem("New Game");
           // JMenuItemExit = new JMenuItem("Exit");
           // JMenuGame.add(JMenuItemNewGame);
           // JMenuGame.add(JMenuItemExit);

           // menuBar.add(JMenuGame);
           // this.setBounds(500, 100, WIDTH, HEIGHT);
           // initializeButtons();
           // this.getContentPane().add(buttonsPanel, BorderLayout.CENTER);
           // setListeners();
        }
        public bool setIndex(int index, int value)
        {
            String side = "";
            switch(index)
            {
                case 0:

                    break;
                case 1:

                    break;
                case 2:

                    break;
                case 3:

                    break;
                case 4:

                    break;
                case 5:

                    break;
                case 6:

                    break;
                case 7:

                    break;
                case 8:

                    break;
                case 9:

                    break;
                case 10:

                    break;
                case 11:

                    break;
                case 12:

                    break;
                case 13:

                    break;
                case 14:

                    break;
                case 15:

                    break;
                default:
                    break;
            }




            if (buttons[index].getText() != "" || game.getBoard().getIndexValue(index) != 0)
                return false;
            if (value == 1)
            {
                side = "X";
            }
            else
            {
                side = "O";
            }
            buttons[index].setText(side);
            game.getBoard().setIndex(index, value);
            return true;
        }
        private void GameGui_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            setIndex(0,)
        }
    }
}
