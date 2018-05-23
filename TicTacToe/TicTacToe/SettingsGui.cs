using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class SettingsGui : Form
    {
        private int initialDepth = 4;
        private int maxDepth = 6;
        private bool selectRandomMaxIndex = true; // choose whether to select first maximal value index or a random (if there are multiples)
        private int popSize = 100;
        private int maxGenerations = 50;
        private int keepBestIndividualsInGeneration = 0; // amount of best individuals to keep from the old generation (pop[0],pop[1],...,pop[keepBestIndividualsInGeneration-1])
        private int playEveryNGame = 100; // determines how often there will be a game against human player (-1 for None)
        private bool playTournament = false;
        //private bool playWithFranky = true;
        private double mutationProbability = 0.2;
        private double crossoverProb = 0.8;

        private Individual bestIndividual = null;

        private string[] functionList = new string[] { };
        private string[] terminalList = new string[] { };

        private bool validInput = true;

        public SettingsGui()
        {
            InitializeComponent();
            individualDepth.SelectedIndex = 1;
            maxInvidualDepth.SelectedIndex = 1;
            bestEvalSelectMethod.SelectedIndex = 1;
            populationSize.SelectedIndex = 1;
            maxGen.SelectedIndex = 1;
            amountOfBestInd.SelectedIndex = 1;
            bestIndGen.SelectedIndex = 1;
            crossProb.SelectedIndex = 1;
            mutationProb.SelectedIndex = 1;
        }

        private void runEvo_Click(object sender, EventArgs e)
        {
            initialDepth = Int32.Parse(individualDepth.SelectedItem.ToString());
            maxDepth = Int32.Parse(maxInvidualDepth.SelectedItem.ToString());
            // choose whether to select first maximal value index or a random (if there are multiples)
            selectRandomMaxIndex = bestEvalSelectMethod.SelectedIndex == 0;
            popSize = (Int32.Parse(populationSize.SelectedItem.ToString()));
            if (popSize == 0)
                popSize = 1;
            maxGenerations = (Int32.Parse(maxGen.SelectedItem.ToString()));
            // amount of best individuals to keep from the old generation (pop[0],pop[1],...,pop[keepBestIndividualsInGeneration-1])
            keepBestIndividualsInGeneration = (Int32.Parse(amountOfBestInd.SelectedItem.ToString()));
            // determines how often there will be a game against human player (0 for None)
            playEveryNGame = (Int32.Parse(bestIndGen.SelectedItem.ToString()));
            //playTournament = (Int32.Parse(inputPlayEachOther.SelectedItem.ToString()));
            playTournament = true;
            //playWithFranky = (Int32.Parse(inputFrankyTournament.SelectedItem.ToString()));
            /*if (!playTournament)
                validInput = false;*/
            crossoverProb = Convert.ToDouble((crossProb.SelectedItem)) * 0.1;
            mutationProbability = Convert.ToDouble(mutationProb.SelectedItem) * 0.1;
            //progressEvolution.setPercentage(0);
            //progressEvolution.setImageSize();

            initializeEvolutionValuesAndRun();
        }

        public void initializeEvolutionValuesAndRun()
        {
            initialDepth = Int32.Parse(individualDepth.SelectedItem.ToString());
            maxDepth = Int32.Parse(maxInvidualDepth.SelectedItem.ToString());
            // choose whether to select first maximal value index or a random (if there are multiples)
            selectRandomMaxIndex = bestEvalSelectMethod.SelectedIndex == 0;
            popSize = (Int32.Parse(populationSize.SelectedItem.ToString()));
            if (popSize == 0)
                popSize = 1;
            maxGenerations = (Int32.Parse(maxGen.SelectedItem.ToString()));
            // amount of best individuals to keep from the old generation (pop[0],pop[1],...,pop[keepBestIndividualsInGeneration-1])
            keepBestIndividualsInGeneration = (Int32.Parse(amountOfBestInd.SelectedItem.ToString()));
            // determines how often there will be a game against human player (0 for None)
            playEveryNGame = (Int32.Parse(bestIndGen.SelectedItem.ToString()));
            //playTournament = (Int32.Parse(inputPlayEachOther.SelectedItem.ToString()));
            //playWithFranky = (Int32.Parse(inputFrankyTournament.SelectedItem.ToString()));
            /*if (!playTournament && !playWithFranky)
                validInput = false;*/
            crossoverProb = Convert.ToDouble((crossProb.SelectedItem)) * 0.1;
            mutationProbability = Convert.ToDouble(mutationProb.SelectedItem) * 0.1;
            //progressEvolution.setPercentage(0);
            //progressEvolution.setImageSize();

            initializeFunctionTerminalSets();

            if (!validInput)
            {
                //JOptionPane.showMessageDialog(frame, "Missing Input!\nEither Tournament Mode is Unselected Or Missing Function/Terminal");
                validInput = true;
                return;
            }
            //Function.setFunctionList(functionList);
            //Terminal.setTerminalList(terminalList);

            // initialize the selection method and the new population
            Selection selection = new Selection(mutationProbability, crossoverProb);
            Population population = new Population(popSize, selection, initialDepth, maxDepth, selectRandomMaxIndex, keepBestIndividualsInGeneration, functionList, terminalList);
            // initialize the evolution and start the evolution engine
            Evolution evolution = new Evolution(population, maxGenerations, playEveryNGame, playTournament, selectRandomMaxIndex);
            bestIndividual = evolution.evolve();
            /*Thread runEvolutionThread = new Thread()
            {

            public void run()
        {
            btnRunEvolution.setEnabled(false);
            bestIndividual = evolution.evolve();
            if (comboBoxPlayerTwo.getItemCount() == 4)
                comboBoxPlayerTwo.addItem("Best Individual From Last Evolution");
            btnRunEvolution.setEnabled(true);
        }
    };
    runEvolutionThread.start();
        */
        }


        public void initializeFunctionTerminalSets()
        {
            List<string> functionList = new List<string>();
            List<string> terminalList = new List<string>();

            foreach (var i in funcSet.CheckedItems)
            {
                if (i.ToString() == "If >=")
                    functionList.Add("If >=");
                if (i.ToString() == "If <=")
                    functionList.Add("If <=");
                if (i.ToString() == "Plus")
                    functionList.Add("Plus");
                if (i.ToString() == "Minus")
                    functionList.Add("Minus");
                if (i.ToString() == "Multi")
                    functionList.Add("Multi");
            }

            foreach (var i in terminalSet.CheckedItems)
            {
                if (i.ToString() == "CountNeighbors")
                    terminalList.Add("CountNeighbors");
                if (i.ToString() == "CornerCount")
                    terminalList.Add("CornerCount");
                if (i.ToString() == "WinOrBlock")
                    terminalList.Add("WinOrBlock");
                if (i.ToString() == "CountRow")
                    terminalList.Add("CountRow");
                if (i.ToString() == "CountColumn")
                    terminalList.Add("CountColumn");
                if (i.ToString() == "CountDiagMain")
                    terminalList.Add("CountDiagMain");
                if (i.ToString() == "CountDiagSec")
                    terminalList.Add("CountDiagSec");
                if (i.ToString() == "RowStreak")
                    terminalList.Add("RowStreak");
                if (i.ToString() == "ColumnStreak")
                    terminalList.Add("ColumnStreak");
                if (i.ToString() == "DiagMainStreak")
                    terminalList.Add("DiagMainStreak");
                if (i.ToString() == "DiagSecStreak")
                    terminalList.Add("DiagSecStreak");
                if (i.ToString() == "RandVal")
                    terminalList.Add("RandVal");
                if (i.ToString() == "IsRandIndex")
                    terminalList.Add("IsRandIndex");
            }

            this.functionList = functionList.ToArray();
            this.terminalList = terminalList.ToArray();

            if (functionList.Count == 0 || terminalList.Count == 0)
            {
                Console.WriteLine("Function Set And Terminal Set Must Contain At Least One Item!");
                validInput = false;
            }

        }

        private void playAgainst_Click(object sender, EventArgs e)
        {
            initializeFunctionTerminalSets();
            Board board = new Board();
            Game game = new Game(board);
            selectRandomMaxIndex = bestEvalSelectMethod.SelectedIndex == 0;
            Individual PlayerOne = new Individual(board, "Player One", selectRandomMaxIndex, functionList, terminalList);
            Individual PlayerTwo = new Individual(board, "Player Two", selectRandomMaxIndex, functionList, terminalList);
            PlayerOne.setValue(1);
            PlayerTwo.setValue(2);
            GameGui gui = new GameGui(game, PlayerTwo);
            this.Hide();
            gui.ShowDialog();
            this.Show();
            PlayerOne.setIsHumanPlayer(true);
            PlayerTwo.setIsHumanPlayer(true);
            PlayerOne.setBoard(board);
            PlayerTwo.setBoard(board);
        }
    }
}
