using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    class Evolution
    {

        private Population population;
        private int maxGenerations;
        private Board board;
        private Game game;
        private int playEveryNGame;
        private bool selectRandomMaxIndex;
        private bool playTournamentBool;
        Stopwatch timer;
        TimeSpan timespan;

        public Evolution(Population population, int maxGenerations, int playEveryNGame, bool playTournament, bool selectRandomMaxIndex)
        {

            this.population = population;
            this.maxGenerations = maxGenerations;
            this.board = population.getBoard();
            this.game = new Game(board);
            this.selectRandomMaxIndex = selectRandomMaxIndex;
            this.playEveryNGame = playEveryNGame;
            this.playTournamentBool = playTournament;

        }

        public Individual getBest()
        {
            return population.getBest();
        }

        public Individual getWorst()
        {
            return population.getWorst();
        }

        private static readonly DateTime Jan1st1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static long currentTimeMillis()
        {
            return (long)(DateTime.UtcNow - Jan1st1970).TotalMilliseconds;
        }

        public void setTournaments(bool playTournament)
        {
            this.playTournamentBool = playTournament;
        }

        public Individual evolve(BackgroundWorker worker)
        {
            /*
             * evolution engine
             * each generation is a tournament where each individual play a two set game against all other individuals
             */
            int gen;
            if (!playTournamentBool)
            {
                Console.WriteLine("You must play a game!");
                // need exit here
            }

            // variables for estimating time left for evaluation
            double start = currentTimeMillis();
            double lastRoundStart = 0;
            double lastRoundTime = 0;
            double end;

            // scores arrays for graph plotting
            List<double> avgFitness = new List<double>();
            List<double> bestFitness = new List<double>();

            Console.WriteLine("Starting Evolution.....");
            DateTime startDate = DateTime.Now;
            for (gen = 1; gen <= maxGenerations; ++gen)
            {
                worker.ReportProgress(gen * 100 / maxGenerations);
                // get time before starting the next generation
                lastRoundStart = currentTimeMillis();
                // reset all individuals game results
                population.resetGameStats();
                if (playTournamentBool)
                {
                    // play the tournament


                    playTournament(worker);
                }


                population.evaluatePopulationFitness();


                // sort the individuals by their fitness (higher fitness on lower index)
                population.sort();


                // record the current generation data to .csv file
                //writeGenerationData(gen);
                Console.WriteLine("Gen " + gen + "/" + maxGenerations + ": " + getBest().getPlayerName() + " Fitness: " + getBest().getFitness());

                // get the time it took to play the tournament (divide by 1000 since the time is in milliseconds)
                lastRoundTime = (currentTimeMillis() - lastRoundStart) / 1000;
                Console.WriteLine("Last Round Took " + lastRoundTime + " sec.");

                // add average and best fitness results to an array for graph
                avgFitness.Add(population.getAvgPopulationFitness());
                bestFitness.Add(getBest().getFitness());

                if (playEveryNGame != 0)
                {
                    if ((gen % playEveryNGame == 0 || gen == maxGenerations))
                    {
                        // play a game against the top individual
                        getBest().printStats();
                        printFinalStats(start, startDate, avgFitness, bestFitness);
                        playHumanVsBest(new Individual(getBest()));
                    }
                }

                if (getBest().isIdeal(population.getPopSize()))
                {
                    Console.WriteLine("Found Best Individual!!!");
                    printFinalStats(start, startDate, avgFitness, bestFitness);
                    playHumanVsBest(new Individual(getBest()));
                    break;
                }

                // produce the next generation (crossover, mutation....)
                if (gen < maxGenerations) // do crossover, mutation, etc... if at last generation
                    population.nextGeneration();
                //progressBar.setPercentage(gen * 100 / maxGenerations);
                //			progressBar.setValue(gen*100/maxGenerations);
            }


            if (gen - 1 == maxGenerations)
                Console.WriteLine("Best attempt: " + getBest());
            else
                Console.WriteLine("Solution: " + getBest());

            return getBest();
        }

        private void printFinalStats(double start, DateTime startDate, List<double> avgFitness, List<double> bestFitness)
        {
            Console.WriteLine("Evolution Process Took: " + (currentTimeMillis() - start) / 1000 + " Seconds");
            Console.WriteLine("Start time: " + startDate);
            Console.WriteLine("End time: " + DateTime.Now);

            for (int i = 0; i < maxGenerations - 1; i++)
            {
                Console.WriteLine("Avg Fitness {0}: {1}", i + 1, avgFitness[i]);
                Console.WriteLine("Best Fitness {0}: {1}", i + 1, bestFitness[i]);
                Console.WriteLine();
            }
        }

        public void playTournament(BackgroundWorker worker)
        {
            int popSize = population.getPopSize();

            for (int i = 0; i < popSize; i++)          
            {
                //worker.ReportProgress(i * 100 / popSize);
                // if the population size is divisible by 10, there will be a progress indication every 10% (0% - 90%)
                if (((float)(i * 100) / popSize) % 10 == 0)
                {
                    // print percentage of population which done competing
                    Console.Write(" " + (i * 100 / popSize) + "% ");
                }
                for (int j = i + 1; j < popSize; j++)
                {
                    // play a match with individual at index [i] against individual at index [j]
                    game.playTwoSetMatch(population.getIndividualAtIndex(i), population.getIndividualAtIndex(j));
                }
            }
            Console.WriteLine();
        }

        public void playHumanVsBest(Individual best)
        {
            Board board = new Board();
            Game game = new Game(board);
            best.setValue(2);
            //TreeDraw td = new TreeDraw(best);
            GameGui gui = new GameGui(game, best);
            gui.ShowDialog();
        }

    }
}
