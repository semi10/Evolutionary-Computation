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
    public partial class TreeCheckGUI : Form
    {
        private const int MAX_DEPTH = 5;
        int indentation = 0;

        public TreeCheckGUI()
        {
            InitializeComponent();
        }

        private void drawTreeConsole(Node currentNode)
        {
            int numOfChildren = currentNode.getNumChildren();

            for (int i = 0; i < indentation; i++)
                Console.Write("\t");
            Console.WriteLine(currentNode.toString());

            indentation++;
            for (int i = 0; i < numOfChildren; i++)
            {
                drawTreeConsole(currentNode.getChildAtIndex(i));
            }
            indentation--;
        }

        private void TreeCheckGUI_Load(object sender, EventArgs e)
        {
            Tree mainTree = new Tree();
            mainTree.growRandomTree(MAX_DEPTH);

            Node currentNode = mainTree.getRoot();
            drawTreeConsole(currentNode);
        }
    }
}
