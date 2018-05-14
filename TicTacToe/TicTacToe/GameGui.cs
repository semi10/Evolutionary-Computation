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
        private int playerTurn = 1;
        private int playerValue;

        public GameGui(/*Game game, Individual opponent*/)
        {
            InitializeComponent();

           // super("GUI Game");
            //this.game = game;
            //this.playerTwo = opponent;
            //playerOne = new Individual(game.getBoard(), "Player One", false, null, null);
            //playerOne.setValue(1);
            //playerOne.setIsHumanPlayer(true);
            //playerValue = 1;
            //this.treeDraw = treeDraw;
            //this.playerTwo.setBoard(game.getBoard());
            //this.ShowDialog();
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
            //String side = "";
            switch(index)
            {
                case 0:
                    if (value == 1)
                        button1.Text = "X";
                    else
                        button1.Text = "O";
                    break;
                case 1:
                    if (value == 1)
                        button2.Text = "X";
                    else
                        button2.Text = "O";
                    break;
                case 2:
                    if (value == 1)
                        button3.Text = "X";
                    else
                        button3.Text = "O";
                    break;
                case 3:
                    if (value == 1)
                        button4.Text = "X";
                    else
                        button4.Text = "O";
                    break;
                case 4:
                    if (value == 1)
                        button5.Text = "X";
                    else
                        button5.Text = "O";
                    break;
                case 5:
                    if (value == 1)
                        button6.Text = "X";
                    else
                        button6.Text = "O";
                    break;
                case 6:
                    if (value == 1)
                        button7.Text = "X";
                    else
                        button7.Text = "O";
                    break;
                case 7:
                    if (value == 1)
                        button8.Text = "X";
                    else
                        button8.Text = "O";
                    break;
                case 8:
                    if (value == 1)
                        button9.Text = "X";
                    else
                        button9.Text = "O";
                    break;
                case 9:
                    if (value == 1)
                        button10.Text = "X";
                    else
                        button10.Text = "O";
                    break;
                case 10:
                    if (value == 1)
                        button11.Text = "X";
                    else
                        button11.Text = "O";
                    break;
                case 11:
                    if (value == 1)
                        button12.Text = "X";
                    else
                        button12.Text = "O";
                    break;
                case 12:
                    if (value == 1)
                        button13.Text = "X";
                    else
                        button13.Text = "O";
                    break;
                case 13:
                    if (value == 1)
                        button14.Text = "X";
                    else
                        button14.Text = "O";
                    break;
                case 14:
                    if (value == 1)
                        button15.Text = "X";
                    else
                        button15.Text = "O";
                    break;
                case 15:
                    if (value == 1)
                        button16.Text = "X";
                    else
                        button16.Text = "O";
                    break;
                default:
                    break;              
            }
            if (value == 1)
                playerValue = 2;
            else
                playerValue = 1;


            /*if (buttons[index].getText() != "" || game.getBoard().getIndexValue(index) != 0)
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
            */
            return true;
        }
        private void GameGui_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            setIndex(0, playerValue);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            setIndex(4, playerValue);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            setIndex(8, playerValue);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            setIndex(12, playerValue);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            setIndex(1, playerValue);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            setIndex(2, playerValue);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            setIndex(3, playerValue);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            setIndex(5, playerValue);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            setIndex(6, playerValue);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            setIndex(7, playerValue);
        }
        private void button10_Click(object sender, EventArgs e)
        {
            setIndex(9, playerValue);
        }
        private void button11_Click(object sender, EventArgs e)
        {
            setIndex(10, playerValue);
        }
        private void button12_Click(object sender, EventArgs e)
        {
            setIndex(11, playerValue);
        }
        private void button14_Click(object sender, EventArgs e)
        {
            setIndex(13, playerValue);
        }
        private void button15_Click(object sender, EventArgs e)
        {
            setIndex(14, playerValue);
        }
        private void button16_Click(object sender, EventArgs e)
        {
            setIndex(15, playerValue);
        }

    }
}
