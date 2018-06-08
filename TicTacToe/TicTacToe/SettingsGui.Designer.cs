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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.bestEvalSelectMethod = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.runEvo = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.funcSet = new System.Windows.Forms.CheckedListBox();
            this.terminalSet = new System.Windows.Forms.CheckedListBox();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.individualDepth = new System.Windows.Forms.TrackBar();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.maxInvidualDepth = new System.Windows.Forms.TrackBar();
            this.label13 = new System.Windows.Forms.Label();
            this.maxGen = new System.Windows.Forms.TrackBar();
            this.label14 = new System.Windows.Forms.Label();
            this.populationSize = new System.Windows.Forms.TrackBar();
            this.label15 = new System.Windows.Forms.Label();
            this.amountOfBestInd = new System.Windows.Forms.TrackBar();
            this.label16 = new System.Windows.Forms.Label();
            this.bestIndGen = new System.Windows.Forms.TrackBar();
            this.label17 = new System.Windows.Forms.Label();
            this.crossProb = new System.Windows.Forms.TrackBar();
            this.label18 = new System.Windows.Forms.Label();
            this.mutationProb = new System.Windows.Forms.TrackBar();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.individualDepth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxInvidualDepth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxGen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.populationSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.amountOfBestInd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bestIndGen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.crossProb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mutationProb)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Initial Individual Tree Depth";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Maximal Individual Tree Depth";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 266);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Population Size";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Maximum Generations";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(189, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Best evaluated index selection method";
            // 
            // bestEvalSelectMethod
            // 
            this.bestEvalSelectMethod.FormattingEnabled = true;
            this.bestEvalSelectMethod.Items.AddRange(new object[] {
            "Random Maximum",
            "First Maximum"});
            this.bestEvalSelectMethod.Location = new System.Drawing.Point(29, 232);
            this.bestEvalSelectMethod.Name = "bestEvalSelectMethod";
            this.bestEvalSelectMethod.Size = new System.Drawing.Size(136, 21);
            this.bestEvalSelectMethod.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(464, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(170, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Amount of Best individuals to keep";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(205, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(226, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Play against best individual after # generations";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(473, 172);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Mutation Probability";
            // 
            // runEvo
            // 
            this.runEvo.Location = new System.Drawing.Point(469, 304);
            this.runEvo.Name = "runEvo";
            this.runEvo.Size = new System.Drawing.Size(128, 29);
            this.runEvo.TabIndex = 18;
            this.runEvo.Text = "Run Evolution";
            this.runEvo.UseVisualStyleBackColor = true;
            this.runEvo.Click += new System.EventHandler(this.runEvo_Click);
            // 
            // label10
            // 
            this.label10.AccessibleName = "";
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(205, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 13);
            this.label10.TabIndex = 19;
            this.label10.Tag = "funcSet";
            this.label10.Text = "Function Set";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(299, 9);
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
            "If >=",
            "If <=",
            "Plus",
            "Minus",
            "Multi"});
            this.funcSet.Location = new System.Drawing.Point(205, 39);
            this.funcSet.Name = "funcSet";
            this.funcSet.Size = new System.Drawing.Size(67, 49);
            this.funcSet.TabIndex = 21;
            this.funcSet.Tag = "funcSet";
            // 
            // terminalSet
            // 
            this.terminalSet.AccessibleName = "termSet";
            this.terminalSet.FormattingEnabled = true;
            this.terminalSet.Items.AddRange(new object[] {
            "WinMove",
            "LoseMove",
            "NeighborsAmount",
            "RowAmount",
            "RowStreak",
            "ColumnAmount",
            "ColumnStreak",
            "PrimaryDiagStreak",
            "SecDiagStreak",
            "RandVal"});
            this.terminalSet.Location = new System.Drawing.Point(302, 39);
            this.terminalSet.Name = "terminalSet";
            this.terminalSet.Size = new System.Drawing.Size(120, 49);
            this.terminalSet.TabIndex = 22;
            this.terminalSet.Tag = "terminalSet";
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(212, 304);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(225, 29);
            this.progressBar2.TabIndex = 23;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // individualDepth
            // 
            this.individualDepth.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.individualDepth.Location = new System.Drawing.Point(19, 25);
            this.individualDepth.Minimum = 3;
            this.individualDepth.Name = "individualDepth";
            this.individualDepth.Size = new System.Drawing.Size(129, 45);
            this.individualDepth.TabIndex = 24;
            this.individualDepth.Value = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(467, 92);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(105, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "Crossover Probability";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "3   4   5   6   7   8   9  10";
            // 
            // maxInvidualDepth
            // 
            this.maxInvidualDepth.Location = new System.Drawing.Point(19, 92);
            this.maxInvidualDepth.Minimum = 3;
            this.maxInvidualDepth.Name = "maxInvidualDepth";
            this.maxInvidualDepth.Size = new System.Drawing.Size(132, 45);
            this.maxInvidualDepth.TabIndex = 28;
            this.maxInvidualDepth.Value = 3;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(26, 124);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(121, 13);
            this.label13.TabIndex = 29;
            this.label13.Text = "3   4   5   6   7   8   9  10";
            // 
            // maxGen
            // 
            this.maxGen.Location = new System.Drawing.Point(19, 162);
            this.maxGen.Maximum = 50;
            this.maxGen.Name = "maxGen";
            this.maxGen.Size = new System.Drawing.Size(128, 45);
            this.maxGen.SmallChange = 5;
            this.maxGen.TabIndex = 30;
            this.maxGen.TickFrequency = 5;
            this.maxGen.Scroll += new System.EventHandler(this.maxGen_Scroll);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(29, 193);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(115, 13);
            this.label14.TabIndex = 31;
            this.label14.Text = "0                              50";
            // 
            // populationSize
            // 
            this.populationSize.LargeChange = 50;
            this.populationSize.Location = new System.Drawing.Point(19, 282);
            this.populationSize.Maximum = 500;
            this.populationSize.Name = "populationSize";
            this.populationSize.Size = new System.Drawing.Size(129, 45);
            this.populationSize.SmallChange = 50;
            this.populationSize.TabIndex = 32;
            this.populationSize.TickFrequency = 50;
            this.populationSize.Scroll += new System.EventHandler(this.populationSize_Scroll);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(29, 320);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(118, 13);
            this.label15.TabIndex = 33;
            this.label15.Text = "0                             500";
            // 
            // amountOfBestInd
            // 
            this.amountOfBestInd.Location = new System.Drawing.Point(467, 25);
            this.amountOfBestInd.Maximum = 50;
            this.amountOfBestInd.Name = "amountOfBestInd";
            this.amountOfBestInd.Size = new System.Drawing.Size(128, 45);
            this.amountOfBestInd.SmallChange = 5;
            this.amountOfBestInd.TabIndex = 34;
            this.amountOfBestInd.TickFrequency = 5;
            this.amountOfBestInd.Scroll += new System.EventHandler(this.amountOfBestInd_Scroll);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(480, 57);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(115, 13);
            this.label16.TabIndex = 35;
            this.label16.Text = "0                              50";
            // 
            // bestIndGen
            // 
            this.bestIndGen.LargeChange = 10;
            this.bestIndGen.Location = new System.Drawing.Point(207, 140);
            this.bestIndGen.Maximum = 50;
            this.bestIndGen.Name = "bestIndGen";
            this.bestIndGen.Size = new System.Drawing.Size(225, 45);
            this.bestIndGen.SmallChange = 5;
            this.bestIndGen.TabIndex = 36;
            this.bestIndGen.TickFrequency = 5;
            this.bestIndGen.Scroll += new System.EventHandler(this.bestIndGen_Scroll);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(214, 166);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(214, 13);
            this.label17.TabIndex = 37;
            this.label17.Text = "0                                                               50";
            // 
            // crossProb
            // 
            this.crossProb.LargeChange = 1;
            this.crossProb.Location = new System.Drawing.Point(467, 114);
            this.crossProb.Name = "crossProb";
            this.crossProb.Size = new System.Drawing.Size(104, 45);
            this.crossProb.TabIndex = 38;
            this.crossProb.Scroll += new System.EventHandler(this.crossProb_Scroll);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(480, 146);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(88, 13);
            this.label18.TabIndex = 39;
            this.label18.Text = "0.0                 1.0";
            // 
            // mutationProb
            // 
            this.mutationProb.LargeChange = 1;
            this.mutationProb.Location = new System.Drawing.Point(470, 193);
            this.mutationProb.Name = "mutationProb";
            this.mutationProb.Size = new System.Drawing.Size(104, 45);
            this.mutationProb.TabIndex = 40;
            this.mutationProb.Scroll += new System.EventHandler(this.mutationProb_Scroll);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(480, 225);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(88, 13);
            this.label19.TabIndex = 41;
            this.label19.Text = "0.0                 1.0";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(143, 165);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(13, 13);
            this.label20.TabIndex = 42;
            this.label20.Text = "5";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(143, 286);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(19, 13);
            this.label21.TabIndex = 43;
            this.label21.Text = "50";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(427, 142);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(19, 13);
            this.label22.TabIndex = 44;
            this.label22.Text = "10";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(592, 27);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(13, 13);
            this.label23.TabIndex = 45;
            this.label23.Text = "0";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(570, 116);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(22, 13);
            this.label24.TabIndex = 46;
            this.label24.Text = "0.8";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(570, 195);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(22, 13);
            this.label25.TabIndex = 47;
            this.label25.Text = "0.2";
            // 
            // SettingsGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 410);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.mutationProb);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.crossProb);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.bestIndGen);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.amountOfBestInd);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.populationSize);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.maxGen);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.maxInvidualDepth);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.individualDepth);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.terminalSet);
            this.Controls.Add(this.funcSet);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.runEvo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.bestEvalSelectMethod);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SettingsGui";
            this.Text = "Initialize Evolution";
            ((System.ComponentModel.ISupportInitialize)(this.individualDepth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxInvidualDepth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxGen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.populationSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.amountOfBestInd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bestIndGen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.crossProb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mutationProb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox bestEvalSelectMethod;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button runEvo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckedListBox funcSet;
        private System.Windows.Forms.CheckedListBox terminalSet;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TrackBar individualDepth;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TrackBar maxInvidualDepth;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TrackBar maxGen;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TrackBar populationSize;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TrackBar amountOfBestInd;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TrackBar bestIndGen;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TrackBar crossProb;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TrackBar mutationProb;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
    }
}