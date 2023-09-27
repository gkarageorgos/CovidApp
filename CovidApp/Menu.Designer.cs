
namespace CovidApp
{
    partial class Menu
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.aboutButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.preventiveMeasuresButton = new System.Windows.Forms.Button();
            this.SymptomsButton = new System.Windows.Forms.Button();
            this.StatisticsButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // aboutButton
            // 
            this.aboutButton.BackColor = System.Drawing.SystemColors.Window;
            this.aboutButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.aboutButton.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutButton.Location = new System.Drawing.Point(615, 289);
            this.aboutButton.Margin = new System.Windows.Forms.Padding(4);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(100, 28);
            this.aboutButton.TabIndex = 22;
            this.aboutButton.Text = "About";
            this.aboutButton.UseVisualStyleBackColor = false;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.SystemColors.Window;
            this.closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeButton.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.Location = new System.Drawing.Point(615, 324);
            this.closeButton.Margin = new System.Windows.Forms.Padding(4);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(100, 28);
            this.closeButton.TabIndex = 21;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // preventiveMeasuresButton
            // 
            this.preventiveMeasuresButton.BackColor = System.Drawing.SystemColors.Window;
            this.preventiveMeasuresButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.preventiveMeasuresButton.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.preventiveMeasuresButton.Location = new System.Drawing.Point(575, 62);
            this.preventiveMeasuresButton.Margin = new System.Windows.Forms.Padding(4);
            this.preventiveMeasuresButton.Name = "preventiveMeasuresButton";
            this.preventiveMeasuresButton.Size = new System.Drawing.Size(189, 52);
            this.preventiveMeasuresButton.TabIndex = 20;
            this.preventiveMeasuresButton.Text = "Preventive Measures";
            this.preventiveMeasuresButton.UseVisualStyleBackColor = false;
            this.preventiveMeasuresButton.Click += new System.EventHandler(this.preventiveMeasuresButton_Click);
            // 
            // SymptomsButton
            // 
            this.SymptomsButton.BackColor = System.Drawing.SystemColors.Window;
            this.SymptomsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SymptomsButton.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SymptomsButton.Location = new System.Drawing.Point(575, 214);
            this.SymptomsButton.Margin = new System.Windows.Forms.Padding(4);
            this.SymptomsButton.Name = "SymptomsButton";
            this.SymptomsButton.Size = new System.Drawing.Size(189, 52);
            this.SymptomsButton.TabIndex = 19;
            this.SymptomsButton.Text = "Symptoms";
            this.SymptomsButton.UseVisualStyleBackColor = false;
            this.SymptomsButton.Click += new System.EventHandler(this.SymptomsButton_Click);
            // 
            // StatisticsButton
            // 
            this.StatisticsButton.BackColor = System.Drawing.SystemColors.Window;
            this.StatisticsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StatisticsButton.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatisticsButton.Location = new System.Drawing.Point(575, 138);
            this.StatisticsButton.Margin = new System.Windows.Forms.Padding(4);
            this.StatisticsButton.Name = "StatisticsButton";
            this.StatisticsButton.Size = new System.Drawing.Size(189, 52);
            this.StatisticsButton.TabIndex = 18;
            this.StatisticsButton.Text = "Statistics";
            this.StatisticsButton.UseVisualStyleBackColor = false;
            this.StatisticsButton.Click += new System.EventHandler(this.StatisticsButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(484, 413);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.preventiveMeasuresButton);
            this.Controls.Add(this.SymptomsButton);
            this.Controls.Add(this.StatisticsButton);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button preventiveMeasuresButton;
        private System.Windows.Forms.Button SymptomsButton;
        private System.Windows.Forms.Button StatisticsButton;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}