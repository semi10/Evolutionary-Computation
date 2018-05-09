namespace TicTacToe
{
    partial class SettingsGui
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.individualDepth = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.maxInvidualDepth = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.populationSize = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.maxGen = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.bestEvalSelectMethod = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.amountOfBestInd = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.bestIndGen = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.crossProb = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.mutationProb = new System.Windows.Forms.ComboBox();
            this.runEvo = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.funcSet = new System.Windows.Forms.CheckedListBox();
            this.terminalSet = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // individualDepth
            // 
            this.individualDepth.FormattingEnabled = true;
            this.individualDepth.Items.AddRange(new object[] {
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.individualDepth.Location = new System.Drawing.Point(12, 28);
            this.individualDepth.Name = "individualDepth";
            this.individualDepth.Size = new System.Drawing.Size(136, 21);
            this.individualDepth.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Initial Individual Tree Depth";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Maximal Individual Tree Depth";
            // 
            // maxInvidualDepth
            // 
            this.maxInvidualDepth.FormattingEnabled = true;
            this.maxInvidualDepth.Items.AddRange(new object[] {
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.maxInvidualDepth.Location = new System.Drawing.Point(12, 73);
            this.maxInvidualDepth.Name = "maxInvidualDepth";
            this.maxInvidualDepth.Size = new System.Drawing.Size(136, 21);
            this.maxInvidualDepth.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Population Size";
            // 
            // populationSize
            // 
            this.populationSize.FormattingEnabled = true;
            this.populationSize.Items.AddRange(new object[] {
            "0",
            "50",
            "100",
            "150",
            "200",
            "250",
            "300",
            "350",
            "400",
            "450",
            "500"});
            this.populationSize.Location = new System.Drawing.Point(12, 118);
            this.populationSize.Name = "populationSize";
            this.populationSize.Size = new System.Drawing.Size(136, 21);
            this.populationSize.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Maximum Generations";
            // 
            // maxGen
            // 
            this.maxGen.FormattingEnabled = true;
            this.maxGen.Items.AddRange(new object[] {
            "0",
            "5",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "45",
            "50"});
            this.maxGen.Location = new System.Drawing.Point(12, 163);
            this.maxGen.Name = "maxGen";
            this.maxGen.Size = new System.Drawing.Size(136, 21);
            this.maxGen.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(189, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Best evaluated index selection method";
            // 
            // bestEvalSelectMethod
            // 
            this.bestEvalSelectMethod.FormattingEnabled = true;
            this.bestEvalSelectMethod.Items.AddRange(new object[] {
            "Random Maximum"});
            this.bestEvalSelectMethod.Location = new System.Drawing.Point(12, 208);
            this.bestEvalSelectMethod.Name = "bestEvalSelectMethod";
            this.bestEvalSelectMethod.Size = new System.Drawing.Size(136, 21);
            this.bestEvalSelectMethod.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(195, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(170, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Amount of Best individuals to keep";
            // 
            // amountOfBestInd
            // 
            this.amountOfBestInd.FormattingEnabled = true;
            this.amountOfBestInd.Items.AddRange(new object[] {
            "0",
            "5",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "45",
            "50"});
            this.amountOfBestInd.Location = new System.Drawing.Point(198, 28);
            this.amountOfBestInd.Name = "amountOfBestInd";
            this.amountOfBestInd.Size = new System.Drawing.Size(167, 21);
            this.amountOfBestInd.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(195, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(226, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Play against best individual after # generations";
            // 
            // bestIndGen
            // 
            this.bestIndGen.FormattingEnabled = true;
            this.bestIndGen.Items.AddRange(new object[] {
            "0",
            "10",
            "20",
            "30",
            "40",
            "50"});
            this.bestIndGen.Location = new System.Drawing.Point(198, 73);
            this.bestIndGen.Name = "bestIndGen";
            this.bestIndGen.Size = new System.Drawing.Size(167, 21);
            this.bestIndGen.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(195, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Crossover Probability";
            // 
            // crossProb
            // 
            this.crossProb.FormattingEnabled = true;
            this.crossProb.Items.AddRange(new object[] {
            "0.0",
            "0.1",
            "0.2",
            "0.3",
            "0.4",
            "0.5",
            "0.6",
            "0.7",
            "0.8",
            "0.9",
            "1.0"});
            this.crossProb.Location = new System.Drawing.Point(198, 118);
            this.crossProb.Name = "crossProb";
            this.crossProb.Size = new System.Drawing.Size(167, 21);
            this.crossProb.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(195, 146);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Mutation Probability";
            // 
            // mutationProb
            // 
            this.mutationProb.FormattingEnabled = true;
            this.mutationProb.Items.AddRange(new object[] {
            "0.0",
            "0.1",
            "0.2",
            "0.3",
            "0.4",
            "0.5",
            "0.6",
            "0.7",
            "0.8",
            "0.9",
            "1.0"});
            this.mutationProb.Location = new System.Drawing.Point(198, 167);
            this.mutationProb.Name = "mutationProb";
            this.mutationProb.Size = new System.Drawing.Size(167, 21);
            this.mutationProb.TabIndex = 17;
            // 
            // runEvo
            // 
            this.runEvo.Location = new System.Drawing.Point(300, 328);
            this.runEvo.Name = "runEvo";
            this.runEvo.Size = new System.Drawing.Size(114, 37);
            this.runEvo.TabIndex = 18;
            this.runEvo.Text = "Run Evolution";
            this.runEvo.UseVisualStyleBackColor = true;
            this.runEvo.Click += new System.EventHandler(this.runEvo_Click);
            // 
            // label10
            // 
            this.label10.AccessibleName = "";
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 273);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 13);
            this.label10.TabIndex = 19;
            this.label10.Tag = "funcSet";
            this.label10.Text = "Function Set";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(165, 242);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Terminal Set";
            // 
            // funcSet
            // 
            this.funcSet.AccessibleName = "funcSet";
            this.funcSet.FormattingEnabled = true;
            this.funcSet.Items.AddRange(new object[] {
            "If>=",
            "If<=",
            "Plus",
            "Minus",
            "Multi"});
            this.funcSet.Location = new System.Drawing.Point(81, 242);
            this.funcSet.Name = "funcSet";
            this.funcSet.Size = new System.Drawing.Size(67, 79);
            this.funcSet.TabIndex = 21;
            this.funcSet.Tag = "funcSet";
            // 
            // terminalSet
            // 
            this.terminalSet.AccessibleName = "termSet";
            this.terminalSet.FormattingEnabled = true;
            this.terminalSet.Items.AddRange(new object[] {
            "CountNeighbors",
            "CornerCount",
            "WinOrBlock",
            "CountRow",
            "CountColumn",
            "CountDiagMain",
            "CountDiagSec",
            "RowStreak",
            "ColumnStreak",
            "DiagMainStreak",
            "DiagSecStreak",
            "RandVal",
            "IsRandIndex"});
            this.terminalSet.Location = new System.Drawing.Point(237, 208);
            this.terminalSet.Name = "terminalSet";
            this.terminalSet.Size = new System.Drawing.Size(120, 94);
            this.terminalSet.TabIndex = 22;
            this.terminalSet.Tag = "terminalSet";
            // 
            // SettingsGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 377);
            this.Controls.Add(this.terminalSet);
            this.Controls.Add(this.funcSet);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.runEvo);
            this.Controls.Add(this.mutationProb);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.crossProb);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.bestIndGen);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.amountOfBestInd);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.bestEvalSelectMethod);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.maxGen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.populationSize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.maxInvidualDepth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.individualDepth);
            this.Name = "SettingsGui";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox individualDepth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox maxInvidualDepth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox populationSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox maxGen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox bestEvalSelectMethod;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox amountOfBestInd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox bestIndGen;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox crossProb;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox mutationProb;
        private System.Windows.Forms.Button runEvo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckedListBox funcSet;
        private System.Windows.Forms.CheckedListBox terminalSet;
    }
}