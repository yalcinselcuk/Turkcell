﻿namespace taskMechanism
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.buttonShow = new System.Windows.Forms.Button();
            this.labelCounter = new System.Windows.Forms.Label();
            this.buttonCounter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(165, 281);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(284, 29);
            this.progressBar1.TabIndex = 7;
            // 
            // buttonShow
            // 
            this.buttonShow.Location = new System.Drawing.Point(542, 141);
            this.buttonShow.Name = "buttonShow";
            this.buttonShow.Size = new System.Drawing.Size(94, 29);
            this.buttonShow.TabIndex = 6;
            this.buttonShow.Text = "Göster";
            this.buttonShow.UseVisualStyleBackColor = true;
            this.buttonShow.Click += new System.EventHandler(this.buttonShow_Click);
            // 
            // labelCounter
            // 
            this.labelCounter.AutoSize = true;
            this.labelCounter.Location = new System.Drawing.Point(311, 210);
            this.labelCounter.Name = "labelCounter";
            this.labelCounter.Size = new System.Drawing.Size(0, 20);
            this.labelCounter.TabIndex = 5;
            // 
            // buttonCounter
            // 
            this.buttonCounter.Location = new System.Drawing.Point(237, 140);
            this.buttonCounter.Name = "buttonCounter";
            this.buttonCounter.Size = new System.Drawing.Size(164, 35);
            this.buttonCounter.TabIndex = 4;
            this.buttonCounter.Text = "Sayacı Başlat";
            this.buttonCounter.UseVisualStyleBackColor = true;
            this.buttonCounter.Click += new System.EventHandler(this.buttonCounter_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.buttonShow);
            this.Controls.Add(this.labelCounter);
            this.Controls.Add(this.buttonCounter);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ProgressBar progressBar1;
        private Button buttonShow;
        private Label labelCounter;
        private Button buttonCounter;
    }
}