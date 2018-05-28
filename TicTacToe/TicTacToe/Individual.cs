using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TicTacToe
{
    public class Individual : IComparable
    {
        private string playerName;
        protected bool isHumanPlayer;
        private int value;
        private double fitness;
        private Tree strategy;
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

        Random rnd = new Random();


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

        public Individual(Individual individual)
        {
            this.playerName = individual.playerName;
            fitness = individual.fitness;
            strategy = new Tree(individual.getStrategy());
            this.setBoard(individual.board);
            setFunctionList(individual.getFunctionList());
            setTerminalList(individual.getTerminalList());
            wins = new int[2];
            losses = new int[2];
            draws = new int[2];
        }

        public void setPlayerName(string playerName)
        {
            this.playerName = playerName;
        }

        public string getPlayerName()
        {
            return playerName;
        }

        public void setValue(int value)
        {
            this.value = value;
        }

        public int getValue()
        {
            return value;
        }
        public void setIsHumanPlayer(bool isHumanPlayer)
        {
            this.isHumanPlayer = isHumanPlayer;
        }

        public bool getIsHumanPlayer()
        {
            return this.isHumanPlayer;
        }

        public void setFunctionList(string[] functionList)
        {
            if (functionList != null)
            {
                this.functionList = new string[functionList.Length];
                functionList.CopyTo(this.functionList, 0);
            }
        }

        public void setTerminalList(string[] terminalList)
        {
            if (terminalList != null)
            {
                this.terminalList = new string[terminalList.Length];
                terminalList.CopyTo(this.terminalList, 0);
            }
        }

        public string[] getFunctionList()
        {
            return this.functionList;
        }

        public string[] getTerminalList()
        {
            return this.terminalList;
        }
        public string getRandomFunction()
        {
            string function = functionList[(int)(rnd.NextDouble() * functionList.Length)];
            return function;
        }

        public string getRandomTerminal()
        {
            string terminal = terminalList[(int)(rnd.NextDouble() * terminalList.Length)];
            return terminal;
        }
        public void addDraw(bool started)
        {
            if (started)
                draws[STARTED_GAME]++;
            else
                draws[NOT_STARTED_GAME]++;
        }

        public void addLoss(bool started)
        {
            if (started)
                losses[STARTED_GAME]++;
            else
                losses[NOT_STARTED_GAME]++;
        }

        public void addWin(bool started)
        {
            if (started)
                wins[STARTED_GAME]++;
            else
                wins[NOT_STARTED_GAME]++;
        }
        public void resetGameStats()
        {
            wins[STARTED_GAME] =
                    wins[NOT_STARTED_GAME] =
                    losses[STARTED_GAME] =
                    losses[NOT_STARTED_GAME] =
                    draws[STARTED_GAME] =
                    draws[NOT_STARTED_GAME] = 0;
        }

        public int getGamesPlayed()
        {
            return (wins[STARTED_GAME] + wins[NOT_STARTED_GAME] + losses[STARTED_GAME] + losses[NOT_STARTED_GAME] + draws[STARTED_GAME] + draws[NOT_STARTED_GAME]);
        }

        public void printStats()
        {
            Console.WriteLine(getPlayerName() + " Stats");
            Console.WriteLine("Fitness: " + fitness);
            Console.WriteLine("Game Played: " + (wins[STARTED_GAME] + wins[NOT_STARTED_GAME] + losses[STARTED_GAME] + losses[NOT_STARTED_GAME] + draws[STARTED_GAME] + draws[NOT_STARTED_GAME]));
            Console.WriteLine("      Started     Not Started");
            Console.WriteLine("Wins    " + wins[STARTED_GAME] + "             " + wins[NOT_STARTED_GAME]);
            Console.WriteLine("Losses  " + losses[STARTED_GAME] + "             " + losses[NOT_STARTED_GAME]);
            Console.WriteLine("Draws   " + draws[STARTED_GAME] + "             " + draws[NOT_STARTED_GAME]);
        }

        public void setStrategy(Tree strategy)
        {
            this.strategy = strategy;
        }

        public Tree getStrategy()
        {
            /*
             * returns the strategy tree (Tree object)
             */
            return strategy;
        }

        public Node getStrategyRoot()
        {
            /*
             * returns the strategy tree root node (Node object)
             */
            return strategy.getRoot();
        }
        public void setBoard(Board board)
        {
            /*
             * sets the individual playing board
             */
            this.board = board;
            if (strategy != null)
                this.getStrategyRoot().setTreeBoard(board);
        }

        public Board getBoard()
        {
            /*
             * returns the individual playing board
             */
            return board;
        }

        public void evalFitness()
        {
            /*
             * fitness calculation
             * the fitness is determined by the tournament results of an individual
             * each result type (win/loss/draw) have a value
             * to evaluate, multiply each result amount by type score factor and sum it all
             */
            fitness = wins[STARTED_GAME] * WIN_START_FACTOR +
                    wins[NOT_STARTED_GAME] * WIN_NOT_START_FACTOR +
                    losses[STARTED_GAME] * LOSE_START_FACTOR +
                    losses[NOT_STARTED_GAME] * LOSE_NOT_START_FACTOR +
                    draws[STARTED_GAME] * DRAW_START_FACTOR +
                    draws[NOT_STARTED_GAME] * DRAW_NOT_START_FACTOR;
        }

        public double getFitness()
        {
            /*
             * returns the individual fitness
             */
            return fitness;
        }
        public Individual[] crossover(Individual otherIndividual)
        {
            /*
             * crossover function
             * clone both parent (the clones will be the new children after the crossover operation)
             * randomly choose a node from each cloned parent
             * swap the nodes
             */
            Random rand = new Random();
            int randNum;
            const int MIN = 2;
            Individual[] children = new Individual[2];
            children[0] = new Individual(this);
            children[1] = new Individual(otherIndividual);
            // Node objects to temporary hold the returned references
            Node swap1 = null;
            Node swap2 = null;

            // randomize a number ranging from 2....nodesAmount of first parent

            randNum = rnd.Next(children[0].getStrategyRoot().countNodes() - MIN + 1) + MIN;
            // paint the selected nodes at the original first parent
            this.getStrategyRoot().getNode(this.getStrategyRoot(), randNum).paintNode(Color.Red);
            // get the first random node reference
            swap1 = children[0].getStrategyRoot().getNode(children[0].getStrategyRoot(), randNum);
            // randomize a number ranging from 2....nodesAmount of second parent
            randNum = rnd.Next(children[1].getStrategyRoot().countNodes() - MIN + 1) + MIN;
            // paint the selected nodes at the original second parent
            otherIndividual.getStrategyRoot().getNode(otherIndividual.getStrategyRoot(), randNum).paintNode(Color.Red);
            // get the second random node reference
            swap2 = children[1].getStrategyRoot().getNode(children[1].getStrategyRoot(), randNum);

            // paint the swapped nodes
            swap1.paintNode(Color.Green);
            swap2.paintNode(Color.Green);

            // make the reference swaps
            //		System.out.println("Swapping " + swap1.TreeStr() + " with " + swap2.TreeStr() + " node #" + temp);
            children[0].getStrategyRoot().swapNodes(swap1, swap2);
            //		System.out.println("Swapping " + swap2.TreeStr() + " with " + swap1.TreeStr() + " node #" + randNum);
            children[1].getStrategyRoot().swapNodes(swap2, swap1);
            return children;
        }

        public Individual crossover2(Individual otherIndividual)
        {
            /*
             * crossover function
             * clone both parent (the clones will be the new children after the crossover operation)
             * randomly choose a node from each cloned parent
             * swap the nodes
             */
            Random rand = new Random();
            int randNum;
            const int MIN = 2;
            // Node objects to temporary hold the returned references
            Node swap1 = null;
            Node swap2 = null;

            // randomize a number ranging from 2....nodesAmount of first parent
            randNum = rnd.Next(this.getStrategyRoot().countNodes() - MIN + 1) + MIN;
            // paint the selected nodes at the original first parent
            this.getStrategyRoot().getNode(this.getStrategyRoot(), randNum).paintNode(Color.Red);
            // get the first random node reference
            swap1 = this.getStrategyRoot().getNode(this.getStrategyRoot(), randNum);
            // randomize a number ranging from 2....nodesAmount of second parent
            randNum = rnd.Next(otherIndividual.getStrategyRoot().countNodes() - MIN + 1) + MIN;
            // paint the selected nodes at the original second parent
            otherIndividual.getStrategyRoot().getNode(otherIndividual.getStrategyRoot(), randNum).paintNode(Color.Red);
            // get the second random node reference
            swap2 = otherIndividual.getStrategyRoot().getNode(otherIndividual.getStrategyRoot(), randNum);

            // paint the swapped nodes
            swap1.paintNode(Color.Green);
            swap2.paintNode(Color.Green);

            // make the reference swaps
            //		System.out.println("Swapping " + swap1.TreeStr() + " with " + swap2.TreeStr() + " node #" + temp);
            this.getStrategyRoot().swapNodes(swap1, swap2.copy(swap2));

            // combine the parents name to create a new name
            this.setPlayerName(otherIndividual.getPlayerName());
            return this;
        }

        public Individual mutate()
        {
            /*
             * randomly choose a node and swap it with randomly generated tree with max depth of 3
             * (not a full tree)
             */
            Random rand = new Random();
            int randNum;
            Individual mutatedIndividual = new Individual(this);
            const int MIN = 2;
            Node mutateNode = null;
            Node mutateNodeSwap = null;
            randNum = rnd.Next(this.getStrategyRoot().countNodes() - MIN + 1) + MIN;
            mutateNode = mutatedIndividual.getStrategyRoot().getNode(mutatedIndividual.getStrategyRoot(), randNum - 1);

            if (mutateNode.GetType() == typeof(Terminal))
            {
                // if the selected node is a terminal,
                // set it to another random terminal
                ((Terminal)mutateNode).setRandTerminal();
            }
		else{
                // if the selected node is a function,
                // generate a random tree (not full) of max depth of 3 and swap the nodes

                // need to research other sizes of random generated mutation tree
                mutateNodeSwap = Node.generateFullTree(3, board, this);
                mutatedIndividual.getStrategyRoot().swapNodes(mutateNode, mutateNodeSwap);
            }
            return mutatedIndividual;
        }

        public void trim(int maxDepth)
        {
            /*
             * trim existing tree to have maximal depth of maxDepth
             */
            this.getStrategyRoot().trim(maxDepth - 1, this);
        }
        public bool generateRandomStrategy(int maxDepth)
        {
            /*
             * generate a random strategy tree by initializing
             * the tree and adding functions and terminals
             */
            if (strategy != null)
                return false;
            strategy = new Tree(board, this);
            return strategy.growRandomTree(maxDepth);
        }



        public bool makeStrategyMove()
        {
            /*
             *  evaluate the board by running the strategy tree on each of the board's indexes
             *  the index with max value is the chosen one
             */
            long[] gradesBoard = new long[strategy.getRoot().getBoard().getBoardSize()];
            long max = int.MinValue;
            for (int i = 0; i < gradesBoard.Length; i++)
            {
                if (strategy.getRoot().getBoard().getIndexValue(i) != 0)
                {
                    // mark occupied spaces (the location is occupied by '1' or '2')
                    gradesBoard[i] = -1;
                }
                else
                {
                    // grade free spaces by running the evaluation tree on the location
                    gradesBoard[i] = Math.Abs(strategy.getRoot().evalIndexGrade(strategy.getRoot(), i))/2;
                    //				gradesBoard[i] = strategy.getRoot().evalIndexGrade(strategy.getRoot(),i);
                    if (gradesBoard[i] >= max)
                        max = gradesBoard[i];
                }
            }

            // find the max index in the board
            int index = getMaxIndex(gradesBoard, max);

            //				printEvaluatedBoard(gradesBoard);
            //		System.out.println("Setting at " + index);

            // double check to attempt move
            return board.attemptMove(index, this);
        }

        public int getMaxIndex(long[] gradesBoard, long max)
        {
            /*
             * return the index of the location with best grade
             * if multiple bests, returns the first which was found or a random max index
             * (depends on selectRandomMaxIndex boolean variable)
             */

            // create an array of indexes
            List<int> maxIndexesAfinalrray = new List<int>();
            // iterate all indexes and add the indexes of the max ones
            for (int i = 0; i < gradesBoard.Length; i++)
            {
                // skip occupied spaces
                if (strategy.getRoot().getBoard().getIndexValue(i) == 0 && gradesBoard[i] == max) // found max, add to the array
                    maxIndexesAfinalrray.Add(i);
            }

            // depending of the individual settings, select first max or a random one
            try
            {
                if (selectRandomMaxIndex)
                    return maxIndexesAfinalrray[  ((int)rnd.NextDouble() * maxIndexesAfinalrray.Count())];
                return maxIndexesAfinalrray[0];
            }
            catch (System.IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                return getRandomFreeIndex();
            }
        }


        public void printEvaluatedBoard(long[] board)
        {
            /*
             *  prints the evaluation grades board
             */
            for (int i = 0; i < board.Length; i++)
            {
                if (i % getBoard().getBoardSizeRow() == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine(i + " | ");
                }
                Console.WriteLine(" " + board[i] + " ");
            }
            Console.WriteLine();
        }
        public int getRandomFreeIndex()
        {
            /*
             * generate random index and attempt to make a move to that index
             * keep on generating and attempting until success to place at the generated index
             */
            int index;
            bool flag = false;
            Random rand = new Random();
            do
            {
                index = rnd.Next(board.getBoardSize());
                if (board.indexEmpty(index))
                {
                    //board.setIndex(index, this);
                    flag = true;
                }
            } while (!flag);
            return index;
        }

        public void setTreeBoard(Board board)
        {
            this.strategy.setTreeBoard(board);
        }

        public int compareTo(Object obj)
        {
            Individual other = (Individual)obj;
            // sort from lower to higher
            //		return new Double(getFitness()).compareTo(new Double(other.getFitness()));
            // sort from higher to lower
            return (other.getFitness().CompareTo(this.getFitness()));
        }

        public bool isIdeal(int popSize)
        {
            return losses[STARTED_GAME] +
                    losses[NOT_STARTED_GAME] +
                    draws[STARTED_GAME] +
                    draws[NOT_STARTED_GAME] == 0;
        }

        public int CompareTo(object obj)
        {
            Individual other = (Individual)obj;
            // sort from higher to lower
            return other.getFitness().CompareTo(getFitness());
        }
    }
}
