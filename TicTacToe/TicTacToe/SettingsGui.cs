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
            initialDepth = inputInitialDepth.getValue();
            maxDepth = inputMaxDepth.getValue();
            // choose whether to select first maximal value index or a random (if there are multiples)
            selectRandomMaxIndex = (inputSelectRandomMaxIndex.getSelectedIndex() == 0) ? true : false;
            popSize = inputPopSize.getValue();
            if (popSize == 0)
                popSize = 1;
            maxGenerations = inputMaxGenerations.getValue();
            // amount of best individuals to keep from the old generation (pop[0],pop[1],...,pop[keepBestIndividualsInGeneration-1])
            keepBestIndividualsInGeneration = inputKeepBestIndividualsInGeneration.getValue();
            // determines how often there will be a game against human player (0 for None)
            playEveryNGame = inputPlayEveryNGame.getValue();
            playTournament = inputPlayEachOther.isSelected();
            playWithFranky = inputFrankyTournament.isSelected();
            if (!playTournament && !playWithFranky)
                validInput = false;
            crossoverProb = inputCrossoverProb.getValue() * 0.1;
            mutationProb = inputMutationProb.getValue() * 0.1;
            progressEvolution.setPercentage(0);
            progressEvolution.setImageSize();

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

            // not finished
            foreach (int i in terminalSet.CheckedItems)
            {
                if (terminalSet.CheckedItems[i].ToString() == "If>=")
                    terminalList.Add("If>=");
                if (terminalSet.CheckedItems[i].ToString() == "If<=")
                    terminalList.Add("If<=");
                if (terminalSet.CheckedItems[i].ToString() == "Plus")
                    terminalList.Add("Plus");
                if (terminalSet.CheckedItems[i].ToString() == "Minus")
                    terminalList.Add("Minus");
                if (terminalSet.CheckedItems[i].ToString() == "Multi")
                    terminalList.Add("Multi");
            }
        }
    }
}
