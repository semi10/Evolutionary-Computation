using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Terminal : Node
    {
        private int MAX_RAND_VALUE = 11;    // max randomly generated value for RandVal terminal
        private int value = -1;             // generated value for RandMax terminal
        private int friendOrEnemy;          // generated randomly 1 (1 for FRIEND, 2 for ENEMY)
        private String terminalIdentity = "UNINITIALIZED";
        static Random rnd = new Random();
        private static String[] allowedTerminalList = {
		    "CountNeightbors",
		    "CountRow",
		    "RowStreak",
		    "CountColumn",
		    "ColumnStreak",
		    "CountDiagMain",
		    "DiagMainStreak",
		    "CountDiagSec",
		    "DiagSecStreak",
		    "CornerCount",
		    "RandVal",
		    "IsRandIndex",
	        "WinOrBlock"
        };


        public Terminal() : base(false)
        {

            numChildren = 0;
            setRandTerminal();
        }

        public Terminal(Terminal _terminal) : base(false)
        {
            numChildren = 0;
            terminalIdentity = _terminal.terminalIdentity;
            friendOrEnemy = _terminal.friendOrEnemy;
            value = _terminal.value;
            height = _terminal.height;
        }

        public Terminal copy()
        {
            Terminal clone = new Terminal();
            return clone;
        }

        public void setRandTerminal()
        {
            terminalIdentity = allowedTerminalList[rnd.Next(0, allowedTerminalList.Length)];
        }

        // return the random value/index (depends on terminalIdentity) of RandVal terminal
        public int getTerminalValue()
        {
            return value;
        }

        //  Returns a string representation of the terminal
        public new String toString()
        {
            return terminalIdentity;
        }
    }

}
