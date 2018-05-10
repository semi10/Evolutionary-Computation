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

        private String[] functionList = new String[] { };
        private String[] terminalList = new String[] { };
        //private List<String> functionList = new ArrayList<String>();
        //private List<String> terminalList = new ArrayList<String>();

        private bool validInput = true;

        //private final String HTML_OPEN = "<html>";
        //private final String HTML_CLOSE = "</html>";
        //private final String HTML_NEWLINE = "<br>";

        public SettingsGui()
        {
            InitializeComponent();
        }

        private void runEvo_Click(object sender, EventArgs e)
        {
            initialDepth = Int32.Parse(individualDepth.SelectedItem.ToString());
            maxDepth = Int32.Parse(maxInvidualDepth.SelectedItem.ToString());
            // choose whether to select first maximal value index or a random (if there are multiples)
            selectRandomMaxIndex = (Int32.Parse(bestEvalSelectMethod.SelectedItem.ToString()) == 0) ? true : false;
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
            crossoverProb = (Int32.Parse(crossProb.SelectedItem.ToString())) * 0.1;
            mutationProbability = (Int32.Parse(mutationProb.SelectedItem.ToString())) * 0.1;
            //progressEvolution.setPercentage(0);
            //progressEvolution.setImageSize();

            initializeFunctionTerminalSets();
        }

        public void initializeFunctionTerminalSets()
        {
            List<string> functionList = new List<string>();
            List<string> terminalList = new List<string>();

            foreach (int i in funcSet.CheckedItems)
            {
                if (funcSet.CheckedItems[i].ToString() == "If>=")
                    functionList.Add("If>=");
                if (funcSet.CheckedItems[i].ToString() == "If<=")
                    functionList.Add("If<=");
                if (funcSet.CheckedItems[i].ToString() == "Plus")
                    functionList.Add("Plus");
                if (funcSet.CheckedItems[i].ToString() == "Minus")
                    functionList.Add("Minus");
                if (funcSet.CheckedItems[i].ToString() == "Multi")
                    functionList.Add("Multi");
            }

            foreach (int i in terminalSet.CheckedItems)
            {
                if (terminalSet.CheckedItems[i].ToString() == "CountNeighbors")
                    terminalList.Add("CountNeighbors");
                if (terminalSet.CheckedItems[i].ToString() == "CornerCount")
                    terminalList.Add("CornerCount");
                if (terminalSet.CheckedItems[i].ToString() == "WinOrBlock")
                    terminalList.Add("WinOrBlock");
                if (terminalSet.CheckedItems[i].ToString() == "CountRow")
                    terminalList.Add("CountRow");
                if (terminalSet.CheckedItems[i].ToString() == "CountColumn")
                    terminalList.Add("CountColumn");
                if (terminalSet.CheckedItems[i].ToString() == "CountDiagMain")
                    terminalList.Add("CountDiagMain");
                if (terminalSet.CheckedItems[i].ToString() == "CountDiagSec")
                    terminalList.Add("CountDiagSec");
                if (terminalSet.CheckedItems[i].ToString() == "RowStreak")
                    terminalList.Add("RowStreak");
                if (terminalSet.CheckedItems[i].ToString() == "ColumnStreak")
                    terminalList.Add("ColumnStreak");
                if (terminalSet.CheckedItems[i].ToString() == "DiagMainStreak")
                    terminalList.Add("DiagMainStreak");
                if (terminalSet.CheckedItems[i].ToString() == "DiagSecStreak")
                    terminalList.Add("DiagSecStreak");
                if (terminalSet.CheckedItems[i].ToString() == "RandVal")
                    terminalList.Add("RandVal");
                if (terminalSet.CheckedItems[i].ToString() == "IsRandIndex")
                    terminalList.Add("IsRandIndex");
            }

            if (functionList.Count == 0 || terminalList.Count == 0)
            {
                Console.WriteLine("Function Set And Terminal Set Must Contain At Least One Item!");
                validInput = false;
            }

        }
    }
}
