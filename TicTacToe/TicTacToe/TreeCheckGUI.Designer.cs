namespace TicTacToe
{
    partial class TreeCheckGUI
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
            this.DrawTreebtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DrawTreebtn
            // 
            this.DrawTreebtn.Location = new System.Drawing.Point(93, 40);
            this.DrawTreebtn.Name = "DrawTreebtn";
            this.DrawTreebtn.Size = new System.Drawing.Size(75, 23);
            this.DrawTreebtn.TabIndex = 0;
            this.DrawTreebtn.Text = "Draw Tree";
            this.DrawTreebtn.UseVisualStyleBackColor = true;
            this.DrawTreebtn.Click += new System.EventHandler(this.DrawTreebtn_Click);
            // 
            // TreeCheckGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 152);
            this.Controls.Add(this.DrawTreebtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TreeCheckGUI";
            this.Text = "TreeCheck";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DrawTreebtn;
    }
}