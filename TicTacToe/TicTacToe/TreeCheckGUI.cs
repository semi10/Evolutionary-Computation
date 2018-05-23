using System;
using System.Drawing;
using System.Windows.Forms;

namespace TicTacToe
{   
    public partial class TreeCheckGUI : Form
    {
        private const int MAX_DEPTH = 5;
        int indentation = 0;
        Tree mainTree;

        public TreeCheckGUI()
        {
            InitializeComponent();
        }

        private void TreeCheckGUI_Load(object sender, EventArgs e)
        {
            mainTree = new Tree();
            mainTree.growRandomTree(MAX_DEPTH);

            Node currentNode = mainTree.getRoot();
            drawTreeConsole(currentNode);
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

        private void TreeCheckGUI_Paint(object sender, PaintEventArgs e)
        {
            Point point1 = new Point(Size.Width / 2, 0);
            Point point2 = new Point(Size.Width / 3, 70);
            Point point3 = new Point((Size.Width / 3) * 2, 70);

            Console.WriteLine(Size.Width);

            int size = 16;
            Size radius = new Size(size, size);
            Color color = Color.Blue;

            DrawEllipse(e, point1, radius, color);
            DrawString(e, "1", point1, 9);
            DrawEllipse(e, point2, radius, color);
            DrawString(e, "2", point2, 9);
            DrawEllipse(e, point3, radius, color);
            DrawString(e, "3", point3, 9);

            DrawLine(e, point1, point2);
            DrawLine(e, point1, point3);
        }

        private void DrawEllipse(PaintEventArgs e, Point position, Size radius, Color color)
        {
            SolidBrush brush = new SolidBrush(color);
            Rectangle circle = new Rectangle(position, radius);
            e.Graphics.FillEllipse(brush, circle);
            // formGraphics.Dispose();
        }

        private void DrawLine(PaintEventArgs e, Point begin, Point end)
        {
            Pen blackPen = new Pen(Color.Black, 2);
            e.Graphics.DrawLine(blackPen, begin, end);
        }

        public void DrawString(PaintEventArgs e, String drawString, Point position, int size)
        {
            Font drawFont = new Font("Arial", size);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            PointF drawPoint = new PointF(150.0F, 150.0F);
            e.Graphics.DrawString(drawString, drawFont, drawBrush, position);
        }

    }
}
