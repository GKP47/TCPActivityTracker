namespace NetworkConnections_Extractor
{
    partial class Form1
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SelectedFolderPathLabel = new System.Windows.Forms.Label();
            this.FilesListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SelectedFileNameLabel = new System.Windows.Forms.Label();
            this.DateLabel = new System.Windows.Forms.Label();
            this.ProcessNamesListBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.label4 = new System.Windows.Forms.Label();
            this.GroupByProcessAndPortCheckBox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ConsulPortCountLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.RMQPortCountLabel = new System.Windows.Forms.Label();
            this.AllPortComboBox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.GenerateChartButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.GenerateDataForSelectedProcessButton = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.TotalDurationLabel = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.TotalAllPortCountLabel = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(55, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Folder";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // SelectedFolderPathLabel
            // 
            this.SelectedFolderPathLabel.AutoSize = true;
            this.SelectedFolderPathLabel.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedFolderPathLabel.Location = new System.Drawing.Point(438, 29);
            this.SelectedFolderPathLabel.Name = "SelectedFolderPathLabel";
            this.SelectedFolderPathLabel.Size = new System.Drawing.Size(130, 18);
            this.SelectedFolderPathLabel.TabIndex = 1;
            this.SelectedFolderPathLabel.Text = "SelectedFolderPath";
            // 
            // FilesListBox
            // 
            this.FilesListBox.FormattingEnabled = true;
            this.FilesListBox.Location = new System.Drawing.Point(58, 90);
            this.FilesListBox.Name = "FilesListBox";
            this.FilesListBox.Size = new System.Drawing.Size(252, 251);
            this.FilesListBox.TabIndex = 3;
            this.FilesListBox.SelectedIndexChanged += new System.EventHandler(this.FilesListBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(55, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Files (in selected folder)";
            // 
            // SelectedFileNameLabel
            // 
            this.SelectedFileNameLabel.AutoSize = true;
            this.SelectedFileNameLabel.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedFileNameLabel.Location = new System.Drawing.Point(328, 90);
            this.SelectedFileNameLabel.Name = "SelectedFileNameLabel";
            this.SelectedFileNameLabel.Size = new System.Drawing.Size(128, 18);
            this.SelectedFileNameLabel.TabIndex = 5;
            this.SelectedFileNameLabel.Text = "Selected File Name";
            // 
            // DateLabel
            // 
            this.DateLabel.AutoSize = true;
            this.DateLabel.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateLabel.Location = new System.Drawing.Point(523, 131);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(76, 18);
            this.DateLabel.TabIndex = 6;
            this.DateLabel.Text = "01/01/0001";
            // 
            // ProcessNamesListBox
            // 
            this.ProcessNamesListBox.FormattingEnabled = true;
            this.ProcessNamesListBox.Location = new System.Drawing.Point(786, 90);
            this.ProcessNamesListBox.Name = "ProcessNamesListBox";
            this.ProcessNamesListBox.Size = new System.Drawing.Size(252, 251);
            this.ProcessNamesListBox.TabIndex = 8;
            this.ProcessNamesListBox.SelectedIndexChanged += new System.EventHandler(this.ProcessNamesListBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(783, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(216, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "List of Process(es) in selected File";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(58, 415);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(980, 274);
            this.dataGridView1.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(198, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Select Folder";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1165, 25);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(321, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 18);
            this.label4.TabIndex = 13;
            this.label4.Text = "Selected File Date Time :";
            // 
            // GroupByProcessAndPortCheckBox
            // 
            this.GroupByProcessAndPortCheckBox.AutoSize = true;
            this.GroupByProcessAndPortCheckBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupByProcessAndPortCheckBox.Location = new System.Drawing.Point(342, 257);
            this.GroupByProcessAndPortCheckBox.Name = "GroupByProcessAndPortCheckBox";
            this.GroupByProcessAndPortCheckBox.Size = new System.Drawing.Size(199, 23);
            this.GroupByProcessAndPortCheckBox.TabIndex = 14;
            this.GroupByProcessAndPortCheckBox.Text = "Group By Process and Port";
            this.GroupByProcessAndPortCheckBox.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(336, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 18);
            this.label5.TabIndex = 16;
            this.label5.Text = "Total :8500 Port Count:";
            // 
            // ConsulPortCountLabel
            // 
            this.ConsulPortCountLabel.AutoSize = true;
            this.ConsulPortCountLabel.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConsulPortCountLabel.Location = new System.Drawing.Point(523, 164);
            this.ConsulPortCountLabel.Name = "ConsulPortCountLabel";
            this.ConsulPortCountLabel.Size = new System.Drawing.Size(36, 18);
            this.ConsulPortCountLabel.TabIndex = 15;
            this.ConsulPortCountLabel.Text = "0000";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(336, 194);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 18);
            this.label7.TabIndex = 18;
            this.label7.Text = "Total :5672 Port Count:";
            // 
            // RMQPortCountLabel
            // 
            this.RMQPortCountLabel.AutoSize = true;
            this.RMQPortCountLabel.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RMQPortCountLabel.Location = new System.Drawing.Point(525, 194);
            this.RMQPortCountLabel.Name = "RMQPortCountLabel";
            this.RMQPortCountLabel.Size = new System.Drawing.Size(36, 18);
            this.RMQPortCountLabel.TabIndex = 17;
            this.RMQPortCountLabel.Text = "0000";
            // 
            // AllPortComboBox
            // 
            this.AllPortComboBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AllPortComboBox.FormattingEnabled = true;
            this.AllPortComboBox.Location = new System.Drawing.Point(491, 289);
            this.AllPortComboBox.Name = "AllPortComboBox";
            this.AllPortComboBox.Size = new System.Drawing.Size(189, 27);
            this.AllPortComboBox.TabIndex = 19;
            this.AllPortComboBox.SelectedIndexChanged += new System.EventHandler(this.AllPortComboBox_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(339, 298);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(146, 18);
            this.label9.TabIndex = 20;
            this.label9.Text = "Filter By Port Number:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(327, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 18);
            this.label6.TabIndex = 21;
            this.label6.Text = "Selected File Name:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(287, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(140, 18);
            this.label8.TabIndex = 22;
            this.label8.Text = "Selected Folder Path:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(57, 714);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(356, 18);
            this.label10.TabIndex = 23;
            this.label10.Text = "PROD - APP4 & APP5 (in GMT), WWW10 & WWW11 (in EST)";
            // 
            // GenerateChartButton
            // 
            this.GenerateChartButton.Enabled = false;
            this.GenerateChartButton.Location = new System.Drawing.Point(421, 376);
            this.GenerateChartButton.Name = "GenerateChartButton";
            this.GenerateChartButton.Size = new System.Drawing.Size(101, 23);
            this.GenerateChartButton.TabIndex = 25;
            this.GenerateChartButton.Text = "Generate Chart";
            this.GenerateChartButton.UseVisualStyleBackColor = true;
            this.GenerateChartButton.Click += new System.EventHandler(this.GenerateChartButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(872, 376);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(166, 23);
            this.button2.TabIndex = 26;
            this.button2.Text = "Launch Consul Extractor";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // GenerateDataForSelectedProcessButton
            // 
            this.GenerateDataForSelectedProcessButton.Location = new System.Drawing.Point(58, 376);
            this.GenerateDataForSelectedProcessButton.Name = "GenerateDataForSelectedProcessButton";
            this.GenerateDataForSelectedProcessButton.Size = new System.Drawing.Size(207, 23);
            this.GenerateDataForSelectedProcessButton.TabIndex = 27;
            this.GenerateDataForSelectedProcessButton.Text = "Show Connection History";
            this.GenerateDataForSelectedProcessButton.UseVisualStyleBackColor = true;
            this.GenerateDataForSelectedProcessButton.Click += new System.EventHandler(this.GenerateDataForSelectedProcessButton_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(331, 337);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(143, 18);
            this.label11.TabIndex = 28;
            this.label11.Text = "Total time monitored:";
            // 
            // TotalDurationLabel
            // 
            this.TotalDurationLabel.AutoSize = true;
            this.TotalDurationLabel.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalDurationLabel.Location = new System.Drawing.Point(493, 337);
            this.TotalDurationLabel.Name = "TotalDurationLabel";
            this.TotalDurationLabel.Size = new System.Drawing.Size(37, 18);
            this.TotalDurationLabel.TabIndex = 29;
            this.TotalDurationLabel.Text = "0 hrs";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(56, 749);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(239, 18);
            this.label12.TabIndex = 30;
            this.label12.Text = "UAT - APP4 (in GMT), WWW1 (in EST)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(351, 222);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(131, 18);
            this.label13.TabIndex = 32;
            this.label13.Text = "Total All Port Count:";
            // 
            // TotalAllPortCountLabel
            // 
            this.TotalAllPortCountLabel.AutoSize = true;
            this.TotalAllPortCountLabel.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalAllPortCountLabel.Location = new System.Drawing.Point(524, 222);
            this.TotalAllPortCountLabel.Name = "TotalAllPortCountLabel";
            this.TotalAllPortCountLabel.Size = new System.Drawing.Size(36, 18);
            this.TotalAllPortCountLabel.TabIndex = 31;
            this.TotalAllPortCountLabel.Text = "0000";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(574, 376);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(185, 23);
            this.button3.TabIndex = 33;
            this.button3.Text = "Generate Chart (By Process & Port)";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 776);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.TotalAllPortCountLabel);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.TotalDurationLabel);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.GenerateDataForSelectedProcessButton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.GenerateChartButton);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.AllPortComboBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.RMQPortCountLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ConsulPortCountLabel);
            this.Controls.Add(this.GroupByProcessAndPortCheckBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ProcessNamesListBox);
            this.Controls.Add(this.DateLabel);
            this.Controls.Add(this.SelectedFileNameLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FilesListBox);
            this.Controls.Add(this.SelectedFolderPathLabel);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label SelectedFolderPathLabel;
        private System.Windows.Forms.ListBox FilesListBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label SelectedFileNameLabel;
        private System.Windows.Forms.Label DateLabel;
        private System.Windows.Forms.ListBox ProcessNamesListBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox GroupByProcessAndPortCheckBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label ConsulPortCountLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label RMQPortCountLabel;
        private System.Windows.Forms.ComboBox AllPortComboBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button GenerateChartButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button GenerateDataForSelectedProcessButton;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label TotalDurationLabel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label TotalAllPortCountLabel;
        private System.Windows.Forms.Button button3;
    }
}

