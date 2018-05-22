using System;
using System.Drawing;
using System.Windows.Forms;

namespace TicTacToe
{   
    public partial class TreeCheckGUI : Form
    {
        private const int MAX_DEPTH = 5;

        public TreeCheckGUI()
        {
            InitializeComponent();
        }

        private void DrawTreebtn_Click(object sender, EventArgs e)
        {
            Tree mainTree = new Tree();
            mainTree.growRandomTree(MAX_DEPTH);

            DrawTree newTreeDrawing = new DrawTree(mainTree);
        }

    }
}
