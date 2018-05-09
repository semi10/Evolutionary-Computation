using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Individual
    {
        private string playerName;
        private double fitness;
        private GPTree strategy;
        private Board board;
        private bool selectRandomMaxIndex; // decides whether to choose first encountered max index, or a random in case of multiple maximums
                                              // the arrays of game results (draws, losses, wins) represent a game result
                                              // index 0 represent the result when the player started the game
                                              // index 1 represent the result when the player has not started the game
        private string[] functionList = null;
        private string[] terminalList = null;

        private int[] wins;
        private int[] losses;
        private int[] draws;
        // index values for wins, losses, draws arrays
        private readonly int STARTED_GAME = 0;
        private readonly int NOT_STARTED_GAME = 1;
        // constants for fitness evaluation
        private readonly double WIN_START_FACTOR = 1;
        private readonly double WIN_NOT_START_FACTOR = 2;
        private readonly double LOSE_START_FACTOR = 0;
        private readonly double LOSE_NOT_START_FACTOR = 0;
        private readonly double DRAW_START_FACTOR = 0.3;
        private readonly double DRAW_NOT_START_FACTOR = 0.7;


        public Individual(Board board, string playerName, bool selectRandomMaxIndex, string[] functionList, string[] terminalList)
        {
            this.playerName = playerName;
            fitness = 0;
            strategy = null;
            this.board = board;
            this.selectRandomMaxIndex = selectRandomMaxIndex;
            setFunctionList(functionList);
            setTerminalList(terminalList);
            wins = new int[2];
            losses = new int[2];
            draws = new int[2];
        }
    }
}
