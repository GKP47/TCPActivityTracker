namespace NetworkConnections_Extractor
{
    partial class ConsulLogExtractor
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
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SelectedFolderPathLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ConfigurationDataListBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.StartDateTimeLabel = new System.Windows.Forms.Label();
            this.EndDateTimeLabel = new System.Windows.Forms.Label();
            this.DurationLabel = new System.Windows.Forms.Label();
            this.TotalNumberOfEntriesLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ValueDataGridView = new System.Windows.Forms.DataGridView();
            this.ShowOnlyDifferencesCheckBox = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ValueDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(283, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(140, 18);
            this.label8.TabIndex = 27;
            this.label8.Text = "Selected Folder Path:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(181, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 26;
            this.button1.Text = "Select Folder";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 18);
            this.label2.TabIndex = 25;
            this.label2.Text = "Files (in selected folder)";
            // 
            // SelectedFolderPathLabel
            // 
            this.SelectedFolderPathLabel.AutoSize = true;
            this.SelectedFolderPathLabel.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedFolderPathLabel.Location = new System.Drawing.Point(441, 13);
            this.SelectedFolderPathLabel.Name = "SelectedFolderPathLabel";
            this.SelectedFolderPathLabel.Size = new System.Drawing.Size(130, 18);
            this.SelectedFolderPathLabel.TabIndex = 24;
            this.SelectedFolderPathLabel.Text = "SelectedFolderPath";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 18);
            this.label1.TabIndex = 23;
            this.label1.Text = "Select Folder";
            // 
            // ConfigurationDataListBox
            // 
            this.ConfigurationDataListBox.FormattingEnabled = true;
            this.ConfigurationDataListBox.Location = new System.Drawing.Point(41, 77);
            this.ConfigurationDataListBox.Name = "ConfigurationDataListBox";
            this.ConfigurationDataListBox.Size = new System.Drawing.Size(266, 225);
            this.ConfigurationDataListBox.TabIndex = 28;
            this.ConfigurationDataListBox.SelectedIndexChanged += new System.EventHandler(this.ConfigurationDataListBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(343, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 18);
            this.label3.TabIndex = 29;
            this.label3.Text = "Start Date Time:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(343, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 18);
            this.label4.TabIndex = 30;
            this.label4.Text = "End Date Time:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(343, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 18);
            this.label5.TabIndex = 31;
            this.label5.Text = "Duration (in Hours):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(343, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 18);
            this.label6.TabIndex = 32;
            this.label6.Text = "Total no. of entries:";
            // 
            // StartDateTimeLabel
            // 
            this.StartDateTimeLabel.AutoSize = true;
            this.StartDateTimeLabel.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartDateTimeLabel.Location = new System.Drawing.Point(519, 77);
            this.StartDateTimeLabel.Name = "StartDateTimeLabel";
            this.StartDateTimeLabel.Size = new System.Drawing.Size(181, 18);
            this.StartDateTimeLabel.TabIndex = 33;
            this.StartDateTimeLabel.Text = "01/01/0001 00:00:00 AM/PM";
            // 
            // EndDateTimeLabel
            // 
            this.EndDateTimeLabel.AutoSize = true;
            this.EndDateTimeLabel.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndDateTimeLabel.Location = new System.Drawing.Point(519, 124);
            this.EndDateTimeLabel.Name = "EndDateTimeLabel";
            this.EndDateTimeLabel.Size = new System.Drawing.Size(181, 18);
            this.EndDateTimeLabel.TabIndex = 34;
            this.EndDateTimeLabel.Text = "01/01/0001 00:00:00 AM/PM";
            // 
            // DurationLabel
            // 
            this.DurationLabel.AutoSize = true;
            this.DurationLabel.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DurationLabel.Location = new System.Drawing.Point(519, 175);
            this.DurationLabel.Name = "DurationLabel";
            this.DurationLabel.Size = new System.Drawing.Size(48, 18);
            this.DurationLabel.TabIndex = 35;
            this.DurationLabel.Text = "00 hrs.";
            // 
            // TotalNumberOfEntriesLabel
            // 
            this.TotalNumberOfEntriesLabel.AutoSize = true;
            this.TotalNumberOfEntriesLabel.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalNumberOfEntriesLabel.Location = new System.Drawing.Point(519, 223);
            this.TotalNumberOfEntriesLabel.Name = "TotalNumberOfEntriesLabel";
            this.TotalNumberOfEntriesLabel.Size = new System.Drawing.Size(15, 18);
            this.TotalNumberOfEntriesLabel.TabIndex = 36;
            this.TotalNumberOfEntriesLabel.Text = "0";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ValueDataGridView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 346);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1407, 506);
            this.panel1.TabIndex = 37;
            // 
            // ValueDataGridView
            // 
            this.ValueDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ValueDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ValueDataGridView.Location = new System.Drawing.Point(0, 0);
            this.ValueDataGridView.Name = "ValueDataGridView";
            this.ValueDataGridView.Size = new System.Drawing.Size(1407, 506);
            this.ValueDataGridView.TabIndex = 0;
            // 
            // ShowOnlyDifferencesCheckBox
            // 
            this.ShowOnlyDifferencesCheckBox.AutoSize = true;
            this.ShowOnlyDifferencesCheckBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowOnlyDifferencesCheckBox.Location = new System.Drawing.Point(346, 266);
            this.ShowOnlyDifferencesCheckBox.Name = "ShowOnlyDifferencesCheckBox";
            this.ShowOnlyDifferencesCheckBox.Size = new System.Drawing.Size(174, 23);
            this.ShowOnlyDifferencesCheckBox.TabIndex = 38;
            this.ShowOnlyDifferencesCheckBox.Text = "Show Only Differences";
            this.ShowOnlyDifferencesCheckBox.UseVisualStyleBackColor = true;
            this.ShowOnlyDifferencesCheckBox.CheckedChanged += new System.EventHandler(this.ShowOnlyDifferencesCheckBox_CheckedChanged);
            // 
            // ConsulLogExtractor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1407, 852);
            this.Controls.Add(this.ShowOnlyDifferencesCheckBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TotalNumberOfEntriesLabel);
            this.Controls.Add(this.DurationLabel);
            this.Controls.Add(this.EndDateTimeLabel);
            this.Controls.Add(this.StartDateTimeLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ConfigurationDataListBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SelectedFolderPathLabel);
            this.Controls.Add(this.label1);
            this.Name = "ConsulLogExtractor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ConsulLogExtractor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ValueDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label SelectedFolderPathLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox ConfigurationDataListBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label StartDateTimeLabel;
        private System.Windows.Forms.Label EndDateTimeLabel;
        private System.Windows.Forms.Label DurationLabel;
        private System.Windows.Forms.Label TotalNumberOfEntriesLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView ValueDataGridView;
        private System.Windows.Forms.CheckBox ShowOnlyDifferencesCheckBox;
    }
}