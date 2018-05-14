﻿using System;
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
        private Individual individual;
        Random rnd = new Random();
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


        public Terminal(Board _board, String _terminalIdentity, Individual _individual) : base(false, _board)
        {

            numChildren = 0;
            _individual = individual;
            _terminalIdentity = terminalIdentity;
            setIdentity(terminalIdentity); ;

        }

        public Terminal(Terminal _terminal) : base(false, _terminal.board)
        {
            numChildren = 0;
            individual = _terminal.individual;
            terminalIdentity = _terminal.terminalIdentity;
            friendOrEnemy = _terminal.friendOrEnemy;
            value = _terminal.value;
            height = _terminal.height;
        }

        public Terminal copy()
        {
            Terminal clone = new Terminal(board, terminalIdentity, individual);
            return clone;
        }

        public int Eval(int index)
        {
            /*
             * evaluation of a terminal
             * calls the proper method according to the terminal type (methods are in Board class)
             */
            int grade = 0;
            int playerNum = 0;
            if (friendOrEnemy == 1)
            {
                // if the terminal checks for friendly pieces
                // check if the individual value is 1 ('X') and assign 1 to playerNum, else assign 2
                if (individual.getValue() == 1)
                    playerNum = 1;
                else
                    playerNum = 2;
            }
            else
            {
                // if the terminal checks for enemy pieces
                // check if the individual value is ('X') and assign 2 to playerNum, else assign 1
                if (individual.getValue() == 1)
                    playerNum = 2;
                else
                    playerNum = 1;
            }
            // call the proper method (stored as a string in terminalIdentity variable)
            // all methods but the countCorners receives 2 arguments:
            // index argument and playerNum argument which represent looking for a friend or an enemy

            if (terminalIdentity.Equals("CountNeightbors", StringComparison.OrdinalIgnoreCase))
                grade = board.countNeighbors(index, playerNum);
            if (terminalIdentity.Equals("CountRow", StringComparison.OrdinalIgnoreCase))
                grade = board.countRow(index, playerNum);
            if (terminalIdentity.Equals("RowStreak", StringComparison.OrdinalIgnoreCase))
                grade = board.countRowStreak(index, playerNum);
            if (terminalIdentity.Equals("CountColumn", StringComparison.OrdinalIgnoreCase))
                grade = board.countColumn(index, playerNum);
            if (terminalIdentity.Equals("ColumnStreak", StringComparison.OrdinalIgnoreCase))
                grade = board.countColumnStreak(index, playerNum);
            if (terminalIdentity.Equals("CountDiagMain", StringComparison.OrdinalIgnoreCase))
                grade = board.countDiagMain(index, playerNum);
            if (terminalIdentity.Equals("DiagMainStreak", StringComparison.OrdinalIgnoreCase))
                grade = board.countDiagMainStreak(index, playerNum);
            if (terminalIdentity.Equals("CountDiagSec", StringComparison.OrdinalIgnoreCase))
                grade = board.countDiagSec(index, playerNum);
            if (terminalIdentity.Equals("DiagSecStreak", StringComparison.OrdinalIgnoreCase))
                grade = board.countDiagSecStreak(index, playerNum);
            if (terminalIdentity.Equals("CornerCount", StringComparison.OrdinalIgnoreCase))
                grade = board.countCorners(playerNum);
            if (terminalIdentity.Equals("RandVal", StringComparison.OrdinalIgnoreCase))
                grade = value;
            if (terminalIdentity.Equals("IsRandIndex", StringComparison.OrdinalIgnoreCase))
                grade = (value == index) ? 1 : 0;
            if (terminalIdentity.Equals("WinOrBlock", StringComparison.OrdinalIgnoreCase))
                grade = (board.willWinBlock(index, playerNum)) ? Int32.MaxValue : 0;
            return grade;
        }

        public void setIdentity(String _terminalIdentity)
        {
            bool exists = false;
            foreach(String id in allowedTerminalList)
            {
                if (id.Equals(terminalIdentity, StringComparison.OrdinalIgnoreCase))
                    exists = true;
            }

            if (!exists)
                return;

            terminalIdentity = _terminalIdentity;

            if (terminalIdentity.Equals("RandVal", StringComparison.OrdinalIgnoreCase))
                value = rnd.Next(0, MAX_RAND_VALUE);
            else if (terminalIdentity.Equals("IsRandIndex", StringComparison.OrdinalIgnoreCase))
                value = (rnd.Next(0, board.getBoardSize()));
            else
                friendOrEnemy = rnd.Next(1,2);
        }

        public void setFriendOrEnemy(int _friendOrEnemy)
        {
            if (_friendOrEnemy == 1 || _friendOrEnemy == 2)
                friendOrEnemy = _friendOrEnemy;
        }


        public void setRandTerminal()
        {
            /*
             * set the terminal randomly by randomly selecting index from the terminalList
             * and assigning the terminalIdentity with it
             * ******************
             * if the terminal that was selected is RandVal, also assign a random value
             * randomly select whether the terminal refers to friend or enemy when evaluating
             * ******************
             * if the terminal that was selected is IsRandIndex, also assign a random index value
             * this terminal will return if the inspected index equals to the generated index value (1/0)
             * ******************
             * all terminals besides ..Rand.. returns amount of friendly/enemy pieces at various scenarios
             */
            terminalIdentity = individual.getRandomTerminal();
            if (terminalIdentity == null)
            {
                terminalIdentity = allowedTerminalList[rnd.Next(0, allowedTerminalList.Length)];
            }
            if (terminalIdentity.Equals("RandVal", StringComparison.OrdinalIgnoreCase))
                value = rnd.Next(0, MAX_RAND_VALUE);
            else if (terminalIdentity.Equals("IsRandIndex", StringComparison.OrdinalIgnoreCase))
                value = rnd.Next(0, board.getBoardSize());
            else
                friendOrEnemy = rnd.Next(1, 2);
        }

        // return the random value/index (depends on terminalIdentity) of RandVal terminal
        public int getTerminalValue()
        {
            return value;
        }


        /*
         * returns a string representation of the terminal
         * if the terminal is RandVal return RandVal 'VALUE'
         * else
         * return <terminalName> <friendOrEnemy>
         */
        public String toString()
        {
            if ((terminalIdentity.Equals("RandVal", StringComparison.OrdinalIgnoreCase)) || (terminalIdentity.Equals("IsRandIndex", StringComparison.OrdinalIgnoreCase)))
                return terminalIdentity + " " + value;
            return terminalIdentity + " " + ((friendOrEnemy == 1) ? "f" : "e");
        }
    }

}