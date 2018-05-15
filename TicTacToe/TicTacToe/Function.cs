using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Function : Node
    {
        private Individual individual;
        private String functionlIdentity = "UNINITIALIZED";
        Random rnd = new Random();

        private static String[] allowedFunctionList = {
		    "If <=",
		    "If >=",
		    "Minus",
		    "Plus",
	        "Multi"};

	public Function(bool _isRoot, Board _board, String _functionIdentity, Individual _individual) : base(_isRoot, _board)
        {
            individual = _individual;
            setFunction(_functionIdentity);
            numChildren = getFunctionChildrenAmount(functionlIdentity);
        }


        // TODO Semion create same function for Terminal
        public Function(Function _function) : base(_function.isRoot, _function.board)
        {
            individual = _function.individual;
            functionlIdentity = _function.functionlIdentity;
            numChildren = getFunctionChildrenAmount(functionlIdentity);
            height = _function.height;
        }

        public void setIdentity(String _functionIdentity)
        {
            bool exists = false;
            foreach(String id in allowedFunctionList)
            {
                if (id.Equals(_functionIdentity, StringComparison.OrdinalIgnoreCase))
                    exists = true;
            }

            if (!exists)
                return;
            functionlIdentity = _functionIdentity;
            numChildren = getFunctionChildrenAmount(_functionIdentity);
        }

        public String getIdentity()
        {
            return functionlIdentity;
        }

        public Function copy()
        {
            Function clone = new Function(this);
            return clone;
        }

        public void setRandFunction()
        {
            //if(functionlIdentity.equalsIgnoreCase("UNINITIALIZED"))
            //functionlIdentity = functionList[(int) (Math.random()*functionList.length)];
            functionlIdentity = individual.getRandomFunction();
            if (functionlIdentity == null)
            {
                functionlIdentity = allowedFunctionList[rnd.Next(0, allowedFunctionList.Length)];
            }
        }

        public void setFunction(String _functionIdentity)
        {
            if (functionlIdentity.Equals("UNINITIALIZED", StringComparison.OrdinalIgnoreCase))
            functionlIdentity = _functionIdentity;
        }


        public int getFunctionChildrenAmount(String functionIdentity)
        {
            if (functionIdentity == "If <=")
                return 4;
            if (functionIdentity == "If >=")
                return 4;
            if (functionIdentity == "Minus")
                return 2;
            if (functionIdentity == "Plus")
                return 2;
            if (functionIdentity == "Multi")
                return 2;
            return 0;
        }


        public String toString()
        {
            return functionlIdentity;
        }
    }
}
