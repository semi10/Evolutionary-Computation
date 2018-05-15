using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace TicTacToe
{
    public class Node
    {
        Node[] children;
        protected int numChildren;
        protected Board board;
        protected int height;
        protected Boolean isRoot;
        protected Color color;
        static int counter = 0;
        private Color defaultColor = Color.AliceBlue;
        static Random rnd = new Random();
        
        public Node(bool _isRoot, Board _board)
        {
            children = null;
            numChildren = 0;
            board = _board;
            isRoot = _isRoot;
            color = defaultColor;
        }

        public Node copy(Node rootSource)
        {
            Node root;
            if (rootSource is Terminal)
                root = new Terminal((Terminal)rootSource);
            else
            { //if(rootSource instanceof Function)
                root = new Function((Function)rootSource);
                root.children = new Node[root.getNumChildren()];
            }
            for (int i = 0; i < root.getNumChildren(); i++)
            {
                root.children[i] = rootSource.copy(rootSource.children[i]);
            }
            return root;
        }

        public static Node generateFullTree(int maxDepth, Board board, Individual individual)
        {
            /*
             * generate a full grown tree
             */
            Node root;
            //If we are not at the max depth, choose a function  
            if (maxDepth > 1)
            {
                // create new function
                root = new Function(false, board, individual.getRandomFunction(), individual);
                // create the proper amount of children (according to the function that was just created)
                root.children = new Node[root.getNumChildren()];
            }
            //Otherwise, choose a terminal  
            else
            {
                // create new terminal
                root = new Terminal(board, individual.getRandomTerminal(), individual);
            }
            root.height = maxDepth;
            //Recursively assign child nodes  
            for (int i = 0; i < root.getNumChildren(); i++)
            {
                root.children[i] = Node.generateFullTree(maxDepth - 1, board, individual);
            }
            // return the created root
            return root;
        }

        public static Node generateTree(int maxDepth, Board board, Individual individual)
        {
            /*
             * works very similarly to generateFullTree
             * instead of ALWAYS creating a function if the maximum depth hasn't reached
             * randomly select either terminal or a function, causing some branches to stop developing
             */
            Node root;
            //If we are not at the max depth, choose a function  
            if (maxDepth > 1)
            {
                Random rand = new Random();
                if (rnd.NextDouble() >= 0.5)
                {
                    root = new Function(false, board, individual.getRandomFunction(), individual);
                    root.children = new Node[root.getNumChildren()];
                }
                else
                    root = new Terminal(board, individual.getRandomTerminal(), individual);
            }
            //Otherwise, choose a terminal  
            else
                root = new Terminal(board, individual.getRandomTerminal(), individual);
            root.height = maxDepth;
            //Recursively assign child nodes  
            for (int i = 0; i < root.getNumChildren(); i++)
            {
                root.children[i] = Node.generateTree(maxDepth - 1, board, individual);
            }
            return root;
        }

        public void trim(int maxDepth, Individual individual)
        {
            /*
             * traverse all nodes and check depths
             * if reached maximum depth-1, check if the children of the current node (if there are any)
             * are functions, and if so, replace them with random terminals, otherwise, do nothing
             */
            for (int i = 0; i < this.getNumChildren(); i++)
            {
                if (maxDepth == 1)
                {
                    // one level below is the maximal depth,
                    // if the child is a function,
                    // swap with a terminal, else, do nothing
                    if (children[i] is Function)
                        this.children[i] = new Terminal(board, individual.getRandomTerminal(), individual);
                }
                else if (this.children[i] != null)
                {
                    // if haven't reached the maximal depth, and the child is a function,
                    // recursively call each child with the trim method
                    this.children[i].trim(maxDepth - 1, individual);
                }
            }
        }

        // Traverse the entire tree and set each node board
        public void setTreeBoard(Board _board)
        {
            // set the board of the current node
            setBoard(_board);
            // if no children to the current node (it's a terminal) return
            if (numChildren == 0) return;
            // visit each node recursively
            for (int i = 0; i < numChildren; i++)
            {
                if (children[i] != null)
                    children[i].setTreeBoard(_board);
            }
            return;
        }


        // Count the tree nodes can also be used to reset each node's color
        public int countNodes()
        {
            // recursively count the nodes of the tree	
            color = defaultColor;
            // if no children to the current node (it's a terminal) return 1 as the count of the node itself
            if (numChildren == 0) return 1;
            // 1 is the node itself
            int size = 1;

            // visit each node and count the terminals + functions
            for (int i = 0; i < numChildren; i++)
            {
                if (children[i] != null)
                    size += children[i].countNodes();
            }
            return size;
        }


        public long evalIndexGrade(Node root, int index)
        {
            /*
             * evaluation function
             * traverse the entire tree and returns the result of the evaluation
             */
            long grade = 0;
            //		root.color = Color.red;
            // if the current root is a terminal, return it's evaluation
            if (root is Terminal){
                grade = ((Terminal)root).Eval(index);
                return grade;
            }

            // if the root is 'If <=' function, check if arg0 is <= than arg1, if so, return arg2, else, return arg3
            if (((Function)root).getIdentity().Equals("If <=", StringComparison.OrdinalIgnoreCase))
            {
                if (evalIndexGrade(root.getChildAtIndex(0), index) <= evalIndexGrade(root.getChildAtIndex(1), index))
                    grade = evalIndexGrade(root.getChildAtIndex(2), index);
                else
                    grade = evalIndexGrade(root.getChildAtIndex(3), index);
            }
            if (((Function)root).getIdentity().Equals("If >=", StringComparison.OrdinalIgnoreCase))         
            {
                if (evalIndexGrade(root.getChildAtIndex(0), index) >= evalIndexGrade(root.getChildAtIndex(1), index))
                    grade = evalIndexGrade(root.getChildAtIndex(2), index);
                else
                    grade = evalIndexGrade(root.getChildAtIndex(3), index);
            }
            if (((Function)root).getIdentity().Equals("Minus", StringComparison.OrdinalIgnoreCase))
            {
                grade = evalIndexGrade(root.getChildAtIndex(0), index) -
                        evalIndexGrade(root.getChildAtIndex(1), index);
            }
            if (((Function)root).getIdentity().Equals("Plus", StringComparison.OrdinalIgnoreCase))
            {
                grade = evalIndexGrade(root.getChildAtIndex(0), index) +
                        evalIndexGrade(root.getChildAtIndex(1), index);
            }
            if (((Function)root).getIdentity().Equals("Multi", StringComparison.OrdinalIgnoreCase))
            {
                grade = evalIndexGrade(root.getChildAtIndex(0), index) *
                        evalIndexGrade(root.getChildAtIndex(1), index);
            }

            return grade;
        }

        public Board getBoard()
        {
            return board;
        }

        public void setBoard(Board board)
        {
            this.board = board;
        }

        public int getNumChildren()
        {
            return this.numChildren;
        }

        public String toString()
        {
        if (this is Function)
			return ((Function)this).toString();
		else if (this is Terminal)
			return ((Terminal)this).toString();
            return null;
        }

        public bool getIsRoot()
        {
            return isRoot;
        }

        // Swap between arguments: original node and swap node traverse the tree until reaching the original node, then make the swap
        public void swapNodes(Node original, Node swap)
        {
            for (int i = 0; i < this.numChildren; i++)
            {
                if (children[i] == null) return;

                if (children[i] == original)
                {
                    children[i] = swap;
                    //	System.out.println("Swapped " + original + " With " + swap);
                    return;
                }
                if (children[i] != null)
                    children[i].swapNodes(original, swap);
            }
            return;
        }


        public void setIsRoot(bool _isRoot)
        {
            isRoot = _isRoot;
        }

        public Node getChildAtIndex(int index)
        {
            if (index >= 0 && index < numChildren)
                return children[index];
            return null;
        }


        public void setNodeColor(Color color)
        {
            this.color = color;
        }


        // Paints the tree with the color that was sent
        public void paintNode(Color _color)
        {
            color = _color;
            for (int i = 0; i < numChildren; i++)
            {
                if (children[i] != null)
                    children[i].paintNode(color);
            }
        }


        // Resets the static variable counter which is used to count traversed nodes when using the method getNodeN
        public void resetCounter()
        {
            counter = 0;
        }

        // Return the max depth of the tree (the node or nodes with maximal depth)
        public int getMaxDepth(Node root)
        {
            if (root is Terminal){
                // return one as an extra depth of the node
                return 1;
            }
            // create heights array for the children nodes
            int[] height = new int[root.numChildren];
            for (int i = 0; i < root.numChildren; i++)
            {
                // recursively find each child depth
                height[i] = getMaxDepth(root.children[i]);
            }
            return maxDepth(height) + 1;
        }

        // Returns the maximum value in the array of heights
        public int maxDepth(int[] heights)
        {
            int max = 0;
            for (int i = 0; i < heights.Length; i++)
            {
                if (heights[i] > max)
                    max = heights[i];
            }
            return max;
        }

        public int getHeight()
        {
            return height;
        }

        public void assignNodeHeights(Node root, int currentHeight)
        {
            if (root == null)
                return;
            root.height = currentHeight;
            for (int i = 0; i < root.getNumChildren(); i++)
            {
                root.assignNodeHeights(root.children[i], currentHeight - 1);
            }
        }

        // reset the counter and call getNodeN which returns the requested node (pre-order traversal) root, left, right
        public Node getNode(Node root, int n)
        {
            counter = 0;
            return getNodeN(root, n);
        }

        
        // returns the Nth node of the tree
        // received parameters are the root node of the tree and a number n
        // the method works by counting a static variable and when the counter reaches the number n,
        // the method will return the current node
        // n value is ranged from 1....nodeCount
        // the traversal method is pre-order traversal 
        public Node getNodeN(Node root, int n)
        {
            counter++;
            Node returnRoot = null;
            // if the counter reached n, return the current root
            if (counter == n)
                return root;

            for (int i = 0; i < root.getNumChildren(); i++)
            {
                if (root.getChildAtIndex(i) != null)
                {
                    returnRoot = root.getChildAtIndex(i).getNodeN(root.getChildAtIndex(i), n);
                    if (returnRoot != null)
                        return returnRoot;
                }
            }
            return null;
        }

        public void print()
        {
            if (this is Function){
                Console.WriteLine("Function: " + ((Function)this).toString());
            }
		    else if (this is Terminal){
                Console.WriteLine("Terminal: " + ((Terminal)this).toString());
            }

            for (int i = 0; i < numChildren; i++)
            {
                if (children[i] != null) children[i].print();
            }
        }


        // Returns a pseudo-code like representation of the tree
        // Reminder: the program which evolves is an evaluator for a location on the game board
        public String TreeStrPseudo()
        {
            String line = "(";
            if (this is Function){
                if (this.numChildren == 4)
                {
                    if (this.getIsRoot())
                        line += "[";
                    line += "if:";
                    if (this.getIsRoot())
                        line += "]\n";
                    line += children[0].TreeStrPseudo();
                    line += ((((Function)this).getIdentity() == "If >=") ? ">=" : "<=");
                    line += children[1].TreeStrPseudo();
                    line += "\nthen:\n" + children[2].TreeStrPseudo();
                    line += "\nelse:\n" + children[3].TreeStrPseudo();
                }
                else
                {
                    line += children[0].TreeStrPseudo();
                    if (this.getIsRoot())
                        line += "\n[";
                    line += ((Function)this);
                    if (this.getIsRoot())
                        line += "]\n";
                    line += children[1].TreeStrPseudo();
                }
            }
		    else if (this is Terminal)
            {
                    line += "T: " + ((Terminal)this);
            }

            return line + ")";
        }

        public String TreeStrFlat()
        {
            String line = "(";
            if (this.getIsRoot()) line += "[";

            if (this is Function)
            {
                line += "F: " + ((Function)this);
            }
            else if (this is Terminal)
            {
                line += "T: " + ((Terminal)this);
            }

            if (getIsRoot()) line += "]";

            for (int i = 0; i < numChildren; i++)
            {
                if (children[i] != null) line += children[i].TreeStrFlat();
            }

            return line + ")";
        }

    }

}

