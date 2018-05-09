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
        private double mutationProb = 0.2;
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
    }
}
