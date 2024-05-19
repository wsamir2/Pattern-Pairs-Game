using System;

namespace Pattern_Pairs_Game
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.disposeCardTimer = new System.Windows.Forms.Timer(this.components);
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblTimeLeft = new System.Windows.Forms.Label();
            this.btnRestartGame = new System.Windows.Forms.Button();
            this.numericUpDownRows = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownColumns = new System.Windows.Forms.NumericUpDown();
            this.labelRows = new System.Windows.Forms.Label();
            this.labelColumns = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownColumns)).BeginInit();
            this.SuspendLayout();
            // 
            // disposeCardTimer
            // 
            this.disposeCardTimer.Interval = 1000;
            this.disposeCardTimer.Tick += new EventHandler(TimerEvent);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(33, 55);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(131, 16);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Mismatched: 0 times.";
            // 
            // lblTimeLeft
            // 
            this.lblTimeLeft.AutoSize = true;
            this.lblTimeLeft.Location = new System.Drawing.Point(373, 55);
            this.lblTimeLeft.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTimeLeft.Name = "lblTimeLeft";
            this.lblTimeLeft.Size = new System.Drawing.Size(144, 16);
            this.lblTimeLeft.TabIndex = 1;
            this.lblTimeLeft.Text = "Time Left: 120 seconds";
            // 
            // btnRestartGame
            // 
            this.btnRestartGame.Image = ((System.Drawing.Image)(resources.GetObject("btnRestartGame.Image")));
            this.btnRestartGame.Location = new System.Drawing.Point(226, 40);
            this.btnRestartGame.Margin = new System.Windows.Forms.Padding(4);
            this.btnRestartGame.Name = "btnRestartGame";
            this.btnRestartGame.Size = new System.Drawing.Size(55, 47);
            this.btnRestartGame.TabIndex = 2;
            this.btnRestartGame.UseVisualStyleBackColor = true;
            this.btnRestartGame.Click += new System.EventHandler(this.btnRestartGame_Click);
            // 
            // numericUpDownRows
            // 
            this.numericUpDownRows.Location = new System.Drawing.Point(76, 10);
            this.numericUpDownRows.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownRows.Name = "numericUpDownRows";
            this.numericUpDownRows.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownRows.TabIndex = 3;
            // 
            // numericUpDownColumns
            // 
            this.numericUpDownColumns.Location = new System.Drawing.Point(285, 10);
            this.numericUpDownColumns.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownColumns.Name = "numericUpDownColumns";
            this.numericUpDownColumns.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownColumns.TabIndex = 4;
            // 
            // labelRows
            // 
            this.labelRows.AutoSize = true;
            this.labelRows.Location = new System.Drawing.Point(12, 12);
            this.labelRows.Name = "labelRows";
            this.labelRows.Size = new System.Drawing.Size(41, 16);
            this.labelRows.TabIndex = 5;
            this.labelRows.Text = "Rows";
            // 
            // labelColumns
            // 
            this.labelColumns.AutoSize = true;
            this.labelColumns.Location = new System.Drawing.Point(222, 12);
            this.labelColumns.Name = "labelColumns";
            this.labelColumns.Size = new System.Drawing.Size(59, 16);
            this.labelColumns.TabIndex = 6;
            this.labelColumns.Text = "Columns";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(442, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 600);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelRows);
            this.Controls.Add(this.labelColumns);
            this.Controls.Add(this.btnRestartGame);
            this.Controls.Add(this.lblTimeLeft);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.numericUpDownRows);
            this.Controls.Add(this.numericUpDownColumns);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.Text = "Pattern Pairs Game";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownColumns)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer disposeCardTimer;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblTimeLeft;
        private System.Windows.Forms.Button btnRestartGame;
        private System.Windows.Forms.NumericUpDown numericUpDownRows;
        private System.Windows.Forms.NumericUpDown numericUpDownColumns;
        private System.Windows.Forms.Label labelRows;
        private System.Windows.Forms.Label labelColumns;
        private System.Windows.Forms.Button button1;
    }
}