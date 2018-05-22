namespace TicTacToe
{
    partial class TreeCheck
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
            this.CreateTreebtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CreateTreebtn
            // 
            this.CreateTreebtn.Location = new System.Drawing.Point(666, 21);
            this.CreateTreebtn.Name = "CreateTreebtn";
            this.CreateTreebtn.Size = new System.Drawing.Size(109, 28);
            this.CreateTreebtn.TabIndex = 0;
            this.CreateTreebtn.Text = "Create Tree";
            this.CreateTreebtn.UseVisualStyleBackColor = true;
            this.CreateTreebtn.Click += new System.EventHandler(this.CreateTreebtn_Click);
            // 
            // TreeCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CreateTreebtn);
            this.Name = "TreeCheck";
            this.Text = "TreeCheck";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CreateTreebtn;
    }
}