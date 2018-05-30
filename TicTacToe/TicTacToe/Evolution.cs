using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
      //  private Individual frankyOriginal;
       // private Individual franky;
        private bool playTournamentBool;
        Stopwatch timer;
        TimeSpan timespan;
        // private bool playWithFranky;
        //private CSV_Writer reportGenerator;

        //private ProgressImage progressBar;

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

        public Individual evolve()
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

            // create the report file
            //createReportFile();
            // scores arrays for graph plotting
            List<double> avgFitness = new List<double>();
            List<double> bestFitness = new List<double>();
            //List<Double> frankyOriginalFitness = new ArrayList<Double>();
            //List<Double> frankyFitness = new ArrayList<Double>();

            Console.WriteLine("Starting Evolution.....");
            for (gen = 1; gen <= maxGenerations; ++gen)
            {
                // get time before starting the next generation
                lastRoundStart = currentTimeMillis();
                // reset all individuals game results
                population.resetGameStats();
                if (playTournamentBool)
                {
                    // play the tournament

                    timer = Stopwatch.StartNew();

                    playTournament();

                    timer.Stop();
                    timespan = timer.Elapsed;
                    Console.WriteLine(String.Format("playTournament() {0:00}:{1:00}:{2:00}", timespan.Minutes, timespan.Seconds, timespan.Milliseconds / 10));
                }
                /*if (playWithFranky)
                {
                    // reset franky's game results
                    frankyOriginal.resetGameStats();
                    franky.resetGameStats();
                    // play a tournament against franky
                    playTournamentAgainstFranky(frankyOriginal);
                    playTournamentAgainstFranky(franky);
                    // evaluate franky's fitness
                    frankyOriginal.evalFitness();
                    frankyOriginal.printStats();
                    franky.evalFitness();
                    franky.printStats();
                    // add franky's fitness to array (for graph)
                    frankyOriginalFitness.add(frankyOriginal.getFitness());
                    frankyFitness.add(franky.getFitness());
                }*/
                // evaluate population fitness


                timer = Stopwatch.StartNew();

                population.evaluatePopulationFitness();

                timer.Stop();
                timespan = timer.Elapsed;
                Console.WriteLine(String.Format("evaluatePopulationFitness() {0:00}:{1:00}:{2:00}", timespan.Minutes, timespan.Seconds, timespan.Milliseconds / 10));

                // sort the individuals by their fitness (higher fitness on lower index)
                timer = Stopwatch.StartNew();

                population.sort();

                timer.Stop();
                timespan = timer.Elapsed;
                Console.WriteLine(String.Format("sort() {0:00}:{1:00}:{2:00}", timespan.Minutes, timespan.Seconds, timespan.Milliseconds / 10));

                // record the current generation data to .csv file
                //writeGenerationData(gen);
                Console.WriteLine("Generation " + gen + " of " + maxGenerations + ": " + getBest().getPlayerName() + " Fitness: " + getBest().getFitness());

                // get the time it took to play the tournament (divide by 1000 since the time is in milliseconds)
                lastRoundTime = (currentTimeMillis() - lastRoundStart) / 1000;
                Console.WriteLine("Last Round Took " + lastRoundTime + " Seconds");
                // multiply the last round time by the amount of rounds remaining (all rounds - current round)
                Console.WriteLine("Estimated Time to finish:");
                Console.WriteLine("In Minutes: " + (((lastRoundTime) * (maxGenerations - gen)) / 60));
                Console.WriteLine("In Seconds: " + (((lastRoundTime) * (maxGenerations - gen))));


                // add average and best fitness results to an array for graph
                avgFitness.Add(population.getAvgPopulationFitness());
                bestFitness.Add(getBest().getFitness());

                if (playEveryNGame != 0)
                {
                    if ((gen % playEveryNGame == 0 || gen == maxGenerations))
                    {
                        // play a game against the top individual
                        getBest().printStats();
                        playHumanVsBest(new Individual(getBest()));
                    }
                }

                if (getBest().isIdeal(population.getPopSize()))
                {
                    Console.WriteLine("Found Best Individual!!!");
                    playHumanVsBest(new Individual(getBest()));
                    break;
                }

                // produce the next generation (crossover, mutation....)
                if (gen < maxGenerations) // do crossover, mutation, etc... if at last generation
                    population.nextGeneration();
                //progressBar.setPercentage(gen * 100 / maxGenerations);
                //			progressBar.setValue(gen*100/maxGenerations);
            }

            end = currentTimeMillis();
            Console.WriteLine("Evolution Process Took " + (end - start) / 1000 + " Seconds");


            if (gen - 1 == maxGenerations)
                Console.WriteLine("Best attempt: " + getBest());
            else
                Console.WriteLine("Solution: " + getBest());

            return getBest();
        }

        public void playTournament()
        {
            int temp = 0;
            int popSize = population.getPopSize();

            for (int i = 0; i < popSize; i++)
            {
                // if the population size is divisible by 10, there will be a progress indication every 10% (0% - 90%)
                if (((float)(i * 100) / popSize) % 10 == 0)
                {
                    // print percentage of population which done competing
                    Console.WriteLine(" " + (i * 100 / popSize) + "%");
                }
                for (int j = i + 1; j < popSize; j++)
                {
                    // play a match with individual at index [i] against individual at index [j]
                    game.playTwoSetMatch(population.getIndividualAtIndex(i), population.getIndividualAtIndex(j));
                }

            }
            


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
