﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        private Individual frankyOriginal;
        private Individual franky;
        private bool playTournament;
        private bool playWithFranky;
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
            this.playTournament = playTournament;

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
            this.playTournament = playTournament;
        }

        public Individual evolve()
        {
            /*
             * evolution engine
             * each generation is a tournament where each individual play a two set game against all other individuals
             */
            int gen;
            if (!playTournament)
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
            List<Double> avgFitness = new ArrayList();
            List<Double> bestFitness = new ArrayList();
            //List<Double> frankyOriginalFitness = new ArrayList<Double>();
            //List<Double> frankyFitness = new ArrayList<Double>();

            Console.WriteLine("Starting Evolution.....");
            for (gen = 1; gen <= maxGenerations; ++gen)
            {
                // get time before starting the next generation
                lastRoundStart = currentTimeMillis();
                // reset all individuals game results
                population.resetGameStats();
                if (playTournament)
                {
                    // play the tournament
                    playTournament();
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
                population.evaluatePopulationFitness();
                // sort the individuals by their fitness (higher fitness on lower index)
                population.sort();
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
                avgFitness.add(population.getAvgPopulationFitness());
                bestFitness.add(getBest().getFitness());

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

            // plot result graphs
            population.showGraph(avgFitness, "Average Fitness Graph");
            population.showGraph(bestFitness, "Best Fitness Graph");
            /*if (playWithFranky)
            {
                population.showGraph(frankyOriginalFitness, "Original Franky Fitness Graph");
                population.showGraph(frankyFitness, "Franky Fitness Graph");
            }*/

            //runDemo(getBest(),franky);

            // prints the entire population stats
            //		population.printPopulation();
            return getBest();
        }

        public void playTournament()
        {

        }

        public void playHumanVsBest(Individual best)
        {

        }

    }
}