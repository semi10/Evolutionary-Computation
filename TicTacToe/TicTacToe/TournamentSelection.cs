using System;
namespace TicTacToe.Properties
{
    public class TournamentSelection
    {
        private readonly double mutationProb;
        private readonly double crossoverProb;
        private readonly double PERCENT = 0.1;
        public TournamentSelection(double mutationProb, double crossoverProb)
        {
            this.mutationProb = mutationProb;
            this.crossoverProb = crossoverProb;
        }

        public Individual Reproduce(Individual[] pop)
        {
            /*
             * apply crossover and mutation to random individuals in the population
             * return the new individual
             */
            Random rnd = new Random();
            Individual p1 = select(pop);
            Individual prototype = new Individual(p1);

            if (rnd.NextDouble() < crossoverProb)
            {
                Individual p2 = select(pop);
                prototype = prototype.crossover2(p2);
            }

            if (rnd.NextDouble() < mutationProb)
            {
                prototype = prototype.mutate();
            }

            return prototype;
        }

        public Individual ReproduceBest(Individual[] pop)
        {
            /*
             * apply crossover and mutation to top individuals in the population
             * return the new individual
             */
            Random rnd = new Random();
            Individual p1 = selectBest(pop);
            Individual prototype = new Individual(p1);
            if (rnd.NextDouble() < crossoverProb)
            {
                Individual p2 = selectBest(pop);
                prototype = prototype.crossover2(p2);
            }

            if (rnd.NextDouble() < mutationProb)
            {
                prototype = prototype.mutate();
            }
            return prototype;
        }

        public Individual copyElite(Individual[] pop)
        {
            /*
             * select individual from the top percentile of the population and return a copy of it
             */
            Individual elite = pop[randomIndex((int)(pop.Length * PERCENT))];
            Individual prototype = new Individual(elite);
            return prototype;
        }

        private Individual selectBest(Individual[] pop)
        {
            /*
             * select individuals from the top percentile of the population for crossover operation
             */
            Individual i1 = pop[randomIndex((int)(pop.Length * PERCENT))];
            Individual i2 = pop[randomIndex((int)(pop.Length * PERCENT))];

            if (i1.compareTo(i2) <= 0)
                return i1;
            else
                return i2;
        }

        private Individual select(Individual[] pop)
        {
            /*
             * select random individual from the population for crossover operation
             */
            Individual i1 = pop[randomIndex(pop.Length)];
            Individual i2 = pop[randomIndex(pop.Length)];

            if (i1.compareTo(i2) <= 0)
                return i1;
            else
                return i2;
        }

        private int randomIndex(int max)
        {
            Random rnd = new Random();
            return (int)(rnd.NextDouble() * max);
        }

        public double getMutationProb()
        {
            return mutationProb;
        }

        public double getCrossoverProb()
        {
            return crossoverProb;
        }

    }

}
