
namespace CovidApp
{
    partial class Statistics
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
            this.closeButton = new System.Windows.Forms.Button();
            this.backBbutton = new System.Windows.Forms.Button();
            this.helpButton = new System.Windows.Forms.Button();
            this.viewButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataFieldsCheckBox = new System.Windows.Forms.CheckBox();
            this.dataFieldsCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.dataFieldsLabel = new System.Windows.Forms.Label();
            this.dateCheckBox = new System.Windows.Forms.CheckBox();
            this.dateLabel = new System.Windows.Forms.Label();
            this.dateCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.areaFieldsCheckBox = new System.Windows.Forms.CheckBox();
            this.areaFieldsCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.areaFieldsLabel = new System.Windows.Forms.Label();
            this.iso_codeCheckBox = new System.Windows.Forms.CheckBox();
            this.iso_codeLabel = new System.Windows.Forms.Label();
            this.iso_codeCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.SystemColors.Window;
            this.closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeButton.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.Location = new System.Drawing.Point(665, 548);
            this.closeButton.Margin = new System.Windows.Forms.Padding(4);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(100, 28);
            this.closeButton.TabIndex = 44;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // backBbutton
            // 
            this.backBbutton.BackColor = System.Drawing.SystemColors.Window;
            this.backBbutton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backBbutton.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backBbutton.Location = new System.Drawing.Point(665, 512);
            this.backBbutton.Margin = new System.Windows.Forms.Padding(4);
            this.backBbutton.Name = "backBbutton";
            this.backBbutton.Size = new System.Drawing.Size(100, 28);
            this.backBbutton.TabIndex = 43;
            this.backBbutton.Text = "Back";
            this.backBbutton.UseVisualStyleBackColor = false;
            this.backBbutton.Click += new System.EventHandler(this.backBbutton_Click);
            // 
            // helpButton
            // 
            this.helpButton.BackColor = System.Drawing.SystemColors.Window;
            this.helpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.helpButton.Location = new System.Drawing.Point(665, 476);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(100, 28);
            this.helpButton.TabIndex = 42;
            this.helpButton.Text = "Help";
            this.helpButton.UseVisualStyleBackColor = false;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // viewButton
            // 
            this.viewButton.BackColor = System.Drawing.SystemColors.Window;
            this.viewButton.Enabled = false;
            this.viewButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.viewButton.Location = new System.Drawing.Point(665, 348);
            this.viewButton.Name = "viewButton";
            this.viewButton.Size = new System.Drawing.Size(100, 105);
            this.viewButton.TabIndex = 41;
            this.viewButton.Text = "View Results";
            this.viewButton.UseVisualStyleBackColor = false;
            this.viewButton.Click += new System.EventHandler(this.viewButton_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataFieldsCheckBox);
            this.panel2.Controls.Add(this.dataFieldsCheckedListBox);
            this.panel2.Controls.Add(this.dataFieldsLabel);
            this.panel2.Enabled = false;
            this.panel2.Location = new System.Drawing.Point(243, 348);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(381, 302);
            this.panel2.TabIndex = 40;
            // 
            // dataFieldsCheckBox
            // 
            this.dataFieldsCheckBox.AutoSize = true;
            this.dataFieldsCheckBox.Location = new System.Drawing.Point(21, 52);
            this.dataFieldsCheckBox.Name = "dataFieldsCheckBox";
            this.dataFieldsCheckBox.Size = new System.Drawing.Size(88, 21);
            this.dataFieldsCheckBox.TabIndex = 6;
            this.dataFieldsCheckBox.Text = "Select All";
            this.dataFieldsCheckBox.UseVisualStyleBackColor = true;
            this.dataFieldsCheckBox.CheckedChanged += new System.EventHandler(this.dataFieldsCheckBox_CheckedChanged);
            // 
            // dataFieldsCheckedListBox
            // 
            this.dataFieldsCheckedListBox.FormattingEnabled = true;
            this.dataFieldsCheckedListBox.Location = new System.Drawing.Point(20, 79);
            this.dataFieldsCheckedListBox.Name = "dataFieldsCheckedListBox";
            this.dataFieldsCheckedListBox.Size = new System.Drawing.Size(358, 208);
            this.dataFieldsCheckedListBox.TabIndex = 4;
            // 
            // dataFieldsLabel
            // 
            this.dataFieldsLabel.AutoSize = true;
            this.dataFieldsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dataFieldsLabel.Location = new System.Drawing.Point(20, 17);
            this.dataFieldsLabel.Name = "dataFieldsLabel";
            this.dataFieldsLabel.Size = new System.Drawing.Size(57, 25);
            this.dataFieldsLabel.TabIndex = 5;
            this.dataFieldsLabel.Text = "Data";
            // 
            // dateCheckBox
            // 
            this.dateCheckBox.AutoSize = true;
            this.dateCheckBox.Location = new System.Drawing.Point(36, 400);
            this.dateCheckBox.Name = "dateCheckBox";
            this.dateCheckBox.Size = new System.Drawing.Size(88, 21);
            this.dateCheckBox.TabIndex = 39;
            this.dateCheckBox.Text = "Select All";
            this.dateCheckBox.UseVisualStyleBackColor = true;
            this.dateCheckBox.CheckStateChanged += new System.EventHandler(this.dateCheckBox_CheckStateChanged);
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dateLabel.Location = new System.Drawing.Point(35, 365);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(57, 25);
            this.dateLabel.TabIndex = 38;
            this.dateLabel.Text = "Date";
            // 
            // dateCheckedListBox
            // 
            this.dateCheckedListBox.FormattingEnabled = true;
            this.dateCheckedListBox.Location = new System.Drawing.Point(35, 427);
            this.dateCheckedListBox.Name = "dateCheckedListBox";
            this.dateCheckedListBox.Size = new System.Drawing.Size(147, 191);
            this.dateCheckedListBox.TabIndex = 37;
            this.dateCheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.dateCheckedListBox_ItemCheck);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.areaFieldsCheckBox);
            this.panel1.Controls.Add(this.areaFieldsCheckedListBox);
            this.panel1.Controls.Add(this.areaFieldsLabel);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(243, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(381, 301);
            this.panel1.TabIndex = 36;
            // 
            // areaFieldsCheckBox
            // 
            this.areaFieldsCheckBox.AutoSize = true;
            this.areaFieldsCheckBox.Location = new System.Drawing.Point(25, 48);
            this.areaFieldsCheckBox.Name = "areaFieldsCheckBox";
            this.areaFieldsCheckBox.Size = new System.Drawing.Size(88, 21);
            this.areaFieldsCheckBox.TabIndex = 6;
            this.areaFieldsCheckBox.Text = "Select All";
            this.areaFieldsCheckBox.UseVisualStyleBackColor = true;
            this.areaFieldsCheckBox.CheckedChanged += new System.EventHandler(this.areaFieldsCheckBox_CheckedChanged);
            // 
            // areaFieldsCheckedListBox
            // 
            this.areaFieldsCheckedListBox.FormattingEnabled = true;
            this.areaFieldsCheckedListBox.Location = new System.Drawing.Point(24, 75);
            this.areaFieldsCheckedListBox.Name = "areaFieldsCheckedListBox";
            this.areaFieldsCheckedListBox.Size = new System.Drawing.Size(354, 208);
            this.areaFieldsCheckedListBox.TabIndex = 4;
            // 
            // areaFieldsLabel
            // 
            this.areaFieldsLabel.AutoSize = true;
            this.areaFieldsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.areaFieldsLabel.Location = new System.Drawing.Point(24, 13);
            this.areaFieldsLabel.Name = "areaFieldsLabel";
            this.areaFieldsLabel.Size = new System.Drawing.Size(70, 25);
            this.areaFieldsLabel.TabIndex = 5;
            this.areaFieldsLabel.Text = "Fields";
            // 
            // iso_codeCheckBox
            // 
            this.iso_codeCheckBox.AutoSize = true;
            this.iso_codeCheckBox.Location = new System.Drawing.Point(40, 58);
            this.iso_codeCheckBox.Name = "iso_codeCheckBox";
            this.iso_codeCheckBox.Size = new System.Drawing.Size(88, 21);
            this.iso_codeCheckBox.TabIndex = 35;
            this.iso_codeCheckBox.Text = "Select All";
            this.iso_codeCheckBox.UseVisualStyleBackColor = true;
            this.iso_codeCheckBox.CheckStateChanged += new System.EventHandler(this.iso_codeCheckBox_CheckStateChanged);
            // 
            // iso_codeLabel
            // 
            this.iso_codeLabel.AutoSize = true;
            this.iso_codeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.iso_codeLabel.Location = new System.Drawing.Point(35, 23);
            this.iso_codeLabel.Name = "iso_codeLabel";
            this.iso_codeLabel.Size = new System.Drawing.Size(99, 25);
            this.iso_codeLabel.TabIndex = 34;
            this.iso_codeLabel.Text = "Iso Code";
            // 
            // iso_codeCheckedListBox
            // 
            this.iso_codeCheckedListBox.FormattingEnabled = true;
            this.iso_codeCheckedListBox.Location = new System.Drawing.Point(39, 85);
            this.iso_codeCheckedListBox.Name = "iso_codeCheckedListBox";
            this.iso_codeCheckedListBox.Size = new System.Drawing.Size(147, 174);
            this.iso_codeCheckedListBox.TabIndex = 33;
            this.iso_codeCheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.iso_codeCheckedListBox_ItemCheck);
            // 
            // Statistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(800, 661);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.backBbutton);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.viewButton);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dateCheckBox);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.dateCheckedListBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.iso_codeCheckBox);
            this.Controls.Add(this.iso_codeLabel);
            this.Controls.Add(this.iso_codeCheckedListBox);
            this.Name = "Statistics";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Statistics";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Statistics_FormClosed);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button backBbutton;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.Button viewButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox dataFieldsCheckBox;
        private System.Windows.Forms.CheckedListBox dataFieldsCheckedListBox;
        private System.Windows.Forms.Label dataFieldsLabel;
        private System.Windows.Forms.CheckBox dateCheckBox;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.CheckedListBox dateCheckedListBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox areaFieldsCheckBox;
        private System.Windows.Forms.CheckedListBox areaFieldsCheckedListBox;
        private System.Windows.Forms.Label areaFieldsLabel;
        private System.Windows.Forms.CheckBox iso_codeCheckBox;
        private System.Windows.Forms.Label iso_codeLabel;
        private System.Windows.Forms.CheckedListBox iso_codeCheckedListBox;
    }
}