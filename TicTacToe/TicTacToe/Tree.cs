using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



 // Root is the starting node of the tree (root node)
 // terminalValue is increased each time a terminal node is added and it's value is sent to the Terminal
 // to be set, it is a circular value going from 0,1,2.....,[boardSize-1],0,1,2..... 
namespace TicTacToe
{
    public class Tree
    {
        private Node root;

        public Tree()
        {
            root = null;
        }

        public Tree(Tree _tree)
        {
            root = _tree.getRoot().copy(_tree.getRoot());
            root.setIsRoot(true);
        }

        // Generate a random tree
        public bool growRandomTree(int maxDepth)
        {
            if (root != null) return false;
            root = Node.generateFullTree(maxDepth);
            root.setIsRoot(true);
            return true;
        }

        public Node getRoot()
        {
            return root;
        }

        public void setRoot(Node _root)
        {
            root = _root;
        }


        // Return a copy of a Tree must provide initial root node
        public Tree copyTree(Node _root)
        {
            Tree copy = new Tree();
            copy.root = root.copy(_root);
            copy.setRoot(copy.getRoot());
            return copy;
        }

        public void print()
        {
            root.print();
        }


        public String TreeStrPseudo()
        {
            return root.TreeStrPseudo();
        }

    }
}
