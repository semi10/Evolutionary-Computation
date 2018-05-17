using System;
namespace TicTacToe
{
    public class Population
    {
        private Individual[] individuals;
        private Board board;
        private readonly Selection  selection;
        private int initialDepth;
        private int maxDepth;

        private string[] functionList = null;
        private string[] terminalList = null;

        private readonly int SELECT_RANDOM_BEST = 0;
        private readonly int SELECT_RANDOM = 1;
        private readonly int SELECT_ELITE = 2;
        private int KEEP_BEST = 0;

        public Population(int size, Selection selection, int initialDepth, int maxDepth, bool selectRandomMaxIndex, int KEEP_BEST, string[] functionList, string[] terminalList)
        {
            individuals = new Individual[size];
            board = new Board();
            this.initialDepth = initialDepth;
            this.maxDepth = maxDepth;
            setFunctionList(functionList);
            setTerminalList(terminalList);
            generateRandomPopulation(this.initialDepth, selectRandomMaxIndex);
            this.KEEP_BEST = KEEP_BEST;
            this.selection = selection;
        }

        public Board getBoard()
        {
            return board;
        }

        public Individual getBest()
        {
            return individuals[0];
        }

        public Individual getWorst()
        {
            return individuals[individuals.Length - 1];
        }

        public int getPopSize()
        {
            return individuals.Length;
        }

        public void nextGeneration()
        {
            /*
             * generate the next generation
             */
            // initialize new population array
            Individual[] newPop = new Individual[individuals.Length];
            Random rand = new Random();
            for (int index = 0; index < newPop.Length; ++index)
            {
                // generate random reproduction method
                int reproduceMethod = rand.Next(2);
                // 0: produces a new individual from best parents [index 0 and index 1] (crossover and mutation may occur)
                // 1: produces a new individual from completely random parents (crossover and mutation may occur)
                // 2: produces a new individual from a given top percentile of the population (returns copy)
                if (index < KEEP_BEST) // keep best individuals of the population for the next generation
                    newPop[index] = new Individual(individuals[index]);
                else if (reproduceMethod == SELECT_RANDOM_BEST)
                    newPop[index] = selection.reproduceBest(individuals);
                else if (reproduceMethod == SELECT_RANDOM)
                    newPop[index] = selection.reproduce(individuals);
                else if (reproduceMethod == SELECT_ELITE)
                    newPop[index] = selection.copyElite(individuals);
                // trim each individual tree if it exceeds the allowed given depth
                newPop[index].trim(maxDepth);
            }
            individuals = newPop;
            //sort();
        }

        public void generateRandomPopulation(int maxDepth, bool selectRandomMaxIndex)
        {
            /*
             * generate initial population of having strategy tree with a given maximal depth
             */
            // random name generator initialization
           // NameGenerator randName = new NameGenerator();
            for (int i = 0; i < individuals.Length; i++)
            {
                // create a new individual
                individuals[i] = new Individual(board, "Mosa", selectRandomMaxIndex, functionList, terminalList);
                // create random strategy for the individual
                individuals[i].generateRandomStrategy(maxDepth);
                //          individuals[i].setFunctionList(functionList);
                //          individuals[i].setTerminalList(terminalList);
            }
        }

        public Individual getIndividualAtIndex(int index)
        {
            /*
             * returns individual at a given index from the individuals array
             */
            return individuals[index];
        }

        public void evaluatePopulationFitness()
        {
            /*
             * evaluate the population fitness by calculating each individual wins, losses, draws
             */
            for (int i = 0; i < getPopSize(); i++)
            {
                getIndividualAtIndex(i).evalFitness();
            }
        }

        public void printPopulation()
        {
            /*
             * prints the population after sorting
             * prints individual name and fitness and the strategy representation string
             */
           // sort();
            for (int i = 0; i < getPopSize(); i++)
            {
                Console.WriteLine(getIndividualAtIndex(i).getPlayerName() + " fitness " +
                        getIndividualAtIndex(i).getFitness());
                Console.WriteLine(getIndividualAtIndex(i).getStrategyRoot().TreeStrFlat());
            }
        }

        //public void sort()
        //{
        //    Arrays.sort(individuals);
        //}

        public double getAvgPopulationFitness()
        {
            /*
             * return the population's average fitness
             */
            double sum = 0;
            foreach (Individual ind in individuals)
                sum += ind.getFitness();
            return sum / getPopSize();
        }



        public void resetGameStats()
        {
            /*
             * iterate all individuals and resets all their game results (wins, losses, draws)
             */
            for (int i = 0; i < individuals.Length; i++)
                individuals[i].resetGameStats();
        }

        public Selection getSelection()
        {
            return selection;
        }

        public int getInitialDepth()
        {
            return initialDepth;
        }

        public int getMaxDepth()
        {
            return maxDepth;
        }

        public void setFunctionList(string[] functionList)
        {
            if (functionList != null)
                this.functionList = functionList;
        }

        public void setTerminalList(string[] terminalList)
        {
            if (terminalList != null)
                this.terminalList = terminalList;
        }

        public string[] getFunctionList()
        {
            return this.functionList;
        }

        public string[] getTerminalList()
        {
            return this.terminalList;
        }
    }
}
