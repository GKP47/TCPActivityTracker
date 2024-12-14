using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace NetworkConnections_Extractor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetToolTip();
        }

        #region Events

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedFiles = SelectFolder();
                if (selectedFiles != null && selectedFiles.Length > 0)
                {
                    var data = CsvHelperUtility.Instance.ReadCsvFiles(selectedFiles);
                    LoadFileNames(data);
                    if (data != null && data.Count > 2)
                    {
                        SetTotalDuration(data[0].DateTime, data[data.Count() - 1].DateTime);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} {ex.StackTrace}");
            }
        }

        private void FilesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var selectedValue = FilesListBox.SelectedItem;
                if (selectedValue != null && selectedValue is FileByTcpConnections fileByTcpConnections)
                {
                    SelectedFileNameLabel.Text = fileByTcpConnections.FileName;
                    DateLabel.Text = fileByTcpConnections.DateTime.ToString();
                    LoadImportantData(fileByTcpConnections.FileName);

                    if (GroupByProcessAndPortCheckBox.Checked)
                    {
                        ShowDataByFile(fileByTcpConnections.FileName);
                    }
                    else
                    {
                        //ExtractProcessNameInFile(fileByTcpConnections.FileName);
                        ProcessNamesListBox.DataSource = null;
                        ProcessNamesListBox.DataSource = CsvHelperUtility.Instance.GetUniqueProcessNamesBySelectedFile(fileByTcpConnections.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} {ex.StackTrace}");
            }
        }

        private void ProcessNamesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ProcessNamesListBox.SelectedItem != null)
                {
                    var selectedProcessName = ProcessNamesListBox.SelectedItem.ToString();
                    LoadSelectedProcessDetails(selectedProcessName, SelectedFileNameLabel.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} {ex.StackTrace}");
            }
        }

        private void AllPortComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (AllPortComboBox.SelectedItem != null)
                {
                    var selectedRemotePort = Convert.ToInt32(AllPortComboBox.SelectedItem);
                    if (selectedRemotePort == -1)
                    {
                        ShowDataByFile(SelectedFileNameLabel.Text.Trim());
                    }
                    else
                    {
                        FilterDataByPortNumber(SelectedFileNameLabel.Text.Trim(), selectedRemotePort);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} {ex.StackTrace}");
            }
        }

        private void GenerateChartButton_Click(object sender, EventArgs e)
        {
            try
            {
                new Form2().Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} {ex.StackTrace}");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new ChartByProcessForm().Show();
        }


        #endregion

        #region Private Methods

        private void SetToolTip()
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(GenerateDataForSelectedProcessButton, "This button generates data for the selected process and remote port number from all the files loaded in the file name list box.");
            toolTip1.SetToolTip(ConsulPortCountLabel, "Total active Port connection count to Consul Server (:8500) for the selected file in the file name list box");
            toolTip1.SetToolTip(RMQPortCountLabel, "Total active Port connection count to RMQ Server (:5672) for the selected file in the file name list box");
            toolTip1.SetToolTip(TotalAllPortCountLabel, "Total active Port connection count for the selected file in the file name list box");
            toolTip1.SetToolTip(TotalDurationLabel, "Total time monitored");
        }

        private string[] SelectFolder()
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select a folder containing CSV files";

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the selected folder path
                    string selectedFolder = folderDialog.SelectedPath;
                    SelectedFolderPathLabel.Text = selectedFolder;

                    // Load all CSV files from the folder
                    string[] csvFiles = Directory.GetFiles(selectedFolder, "*.csv");

                    if (csvFiles.Any())
                    {
                        return csvFiles;
                    }
                    else
                    {
                        MessageBox.Show("No CSV files found in the selected folder.", "No Files Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                return null;
            }
        }

        private void LoadFileNames(List<FileByTcpConnections> fileByTcpConnections)
        {
            try
            {
                FilesListBox.DataSource = null;
                FilesListBox.DataSource = fileByTcpConnections;
                FilesListBox.DisplayMember = "FileName";
                FilesListBox.ValueMember = "FileName";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} {ex.StackTrace}");
            }
        }

        private void ExtractProcessNameInFile(string selectedFileName)
        {
            var fileTcpConnections = CsvHelperUtility.Instance.GetTcpConnectionsList();
            var tcpConnections = fileTcpConnections.Where(x => x.FileName == selectedFileName).SelectMany(x => x.Connections);
            if (tcpConnections != null)
            {
                ProcessNamesListBox.DataSource = null;
                ProcessNamesListBox.DataSource = tcpConnections.Select(x => x.ExtractedProcessName).Distinct().OrderBy(x => x).ToList();
            }
        }

        private void LoadSelectedProcessDetails(string processName, string selectedFileName)
        {
            var fileTcpConnections = CsvHelperUtility.Instance.GetTcpConnectionsList();
            var tcpConnections = fileTcpConnections.Where(x => x.FileName == selectedFileName).SelectMany(x => x.Connections);
            if (tcpConnections != null)
            {
                var tcpConnectionsByProcess = tcpConnections.Where(x => x.ExtractedProcessName == processName).ToList();

                // ProcessName - Remote Port Number - Total Count
                //var groupBy = tcpConnectionsByProcess.GroupBy(x => x.RemotePort).Select(group =>
                //new
                //{
                //    ProcessName = group.FirstOrDefault(x => x.ExtractedProcessName == processName).ExtractedProcessName,
                //    RemotePort = group.Key,
                //    TotalConnectionsCount = group.Count()
                //}).OrderByDescending(result => result.TotalConnectionsCount).ToList();

                var groupBy = GroupBy(tcpConnectionsByProcess, processName);

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = groupBy;
            }
        }

        private void ShowDataByFile(string selectedFileName)
        {
            var fileTcpConnections = CsvHelperUtility.Instance.GetTcpConnectionsList();
            var tcpConnections = fileTcpConnections.Where(x => x.FileName == selectedFileName).SelectMany(x => x.Connections);
            if (tcpConnections != null)
            {
                var groupBy = tcpConnections.GroupBy(x => new { x.RemotePort, x.ExtractedProcessName }).Select(group =>
               new
               {
                   ProcessName = group.Key.ExtractedProcessName,
                   group.Key.RemotePort,
                   TotalConnectionsCount = group.Count()
               }).OrderByDescending(result => result.TotalConnectionsCount).ToList();

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = groupBy;
            }
        }

        private void LoadImportantData(string selectedFileName)
        {
            var tcpConnections = CsvHelperUtility.Instance.GetTcpConnectionsByFileName(selectedFileName);
            if (tcpConnections != null)
            {
                CsvHelperUtility.Instance.GetConsulRMQPortCount(tcpConnections, out var consulPortCount, out var rmqPortCount);
                var allPorts = tcpConnections.Select(x => x.RemotePort).Distinct().OrderBy(x => x).ToList();
                allPorts.Insert(0, -1);

                ConsulPortCountLabel.Text = consulPortCount.ToString();
                RMQPortCountLabel.Text = rmqPortCount.ToString();
                CsvHelperUtility.Instance.GetAllActivePortCount(tcpConnections, out var allPortCount);
                TotalAllPortCountLabel.Text = allPortCount.ToString();

                AllPortComboBox.DataSource = null;
                AllPortComboBox.DataSource = allPorts;
            }
        }

        private void FilterDataByPortNumber(string selectedFileName, int selectedRemotePort)
        {
            var tcpConnections = CsvHelperUtility.Instance.GetTcpConnectionsByFileName(selectedFileName);
            if (tcpConnections != null)
            {
                var groupBy = tcpConnections.Where(x => x.RemotePort == selectedRemotePort).GroupBy(x => new { x.RemotePort, x.ExtractedProcessName }).Select(group =>
               new
               {
                   ProcessName = group.Key.ExtractedProcessName,
                   group.Key.RemotePort,
                   TotalConnectionsCount = group.Count()
               }).OrderByDescending(result => result.TotalConnectionsCount).ToList();

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = groupBy;
            }
        }

        //private void CalculatePortCountByFileName(out Dictionary<string, int> consulPortCountList, out Dictionary<string, int> rmqPortCountList)
        //{
        //    consulPortCountList = new Dictionary<string, int>();
        //    rmqPortCountList = new Dictionary<string, int>();

        //    var fileTcpConnections = CsvHelperUtility.Instance.GetTcpConnectionsList();
        //    if (fileTcpConnections != null && fileTcpConnections.Count > 0)
        //    {
        //        foreach (var fileTcpConnection in fileTcpConnections)
        //        {
        //            var tcpConnections = fileTcpConnection.Connections;
        //            if (tcpConnections != null)
        //            {
        //                CsvHelperUtility.Instance.GetConsulRMQPortCount(tcpConnections, out var consulPortCount, out var rmqPortCount);
        //                consulPortCountList.Add(fileTcpConnection.DateTime.ToString(), consulPortCount);
        //                rmqPortCountList.Add(fileTcpConnection.DateTime.ToString(), rmqPortCount);
        //            }
        //        }
        //    }
        //}

        //private void GenerateConsulPortTrendChart()
        //{
        //    try
        //    {
        //        CalculatePortCountByFileName(out var consulPortCountList, out var rmqPortCountList);

        //        ChartArea chartArea = new ChartArea("MainArea");
        //        chart1.ChartAreas.Add(chartArea);

        //        Series series = new Series("SampleData")
        //        {
        //            ChartType = SeriesChartType.Column, // Change to Bar, Pie, etc., as needed
        //            BorderWidth = 2
        //        };

        //        AddDataToSeriesPoints(consulPortCountList, series);

        //        chart1.Series.Add(series);

        //        foreach (Series series1 in chart1.Series)
        //        {
        //            series1.ChartType = SeriesChartType.Column;
        //        }

        //        // Add Chart to Form
        //        panel1.Controls.Add(chart1);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"{ex.Message} {ex.StackTrace}");
        //    }
        //}

        //private void AddDataToSeriesPoints(Dictionary<string, int> consulPortCountList, Series series)
        //{
        //    foreach(var item in consulPortCountList)
        //    {
        //        series.Points.AddXY(item.Key, item.Value);
        //    }
        //}

        private void GenerateChart()
        {
            try
            {
                // Create Chart
                //Chart chart = new Chart
                //{
                //    Dock = DockStyle.Right // Adjust to fit the form
                //};

                // Add Chart Area
                //ChartArea chartArea = new ChartArea("MainArea");
                //chart1.ChartAreas.Add(chartArea);

                //// Add Series
                //Series series = new Series("SampleData")
                //{
                //    ChartType = SeriesChartType.Column, // Change to Bar, Pie, etc., as needed
                //    BorderWidth = 2
                //};

                //// Add Data Points
                //series.Points.AddXY("Category 1", 10);
                //series.Points.AddXY("Category 2", 20);
                //series.Points.AddXY("Category 3", 15);
                //series.Points.AddXY("Category 4", 25);

                //chart1.Series.Add(series);

                //foreach (Series series1 in chart1.Series)
                //{
                //    series1.ChartType = SeriesChartType.Column;
                //}

                //// Add Chart to Form
                //panel1.Controls.Add(chart1);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} {ex.StackTrace}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new ConsulLogExtractor().Show();
        }

        private void GenerateDataForSelectedProcessButton_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedRemotePort = -1;
                var fileTcpConnections = CsvHelperUtility.Instance.GetTcpConnectionsList();
                if (fileTcpConnections != null && fileTcpConnections.Count > 0)
                {
                    var selectedProcessName = ProcessNamesListBox.SelectedItem.ToString();
                    if (AllPortComboBox.SelectedItem != null)
                    {
                        selectedRemotePort = Convert.ToInt32(AllPortComboBox.SelectedItem);
                    }

                    if (!string.IsNullOrWhiteSpace(selectedProcessName))
                    {
                        var filteredData = fileTcpConnections.SelectMany(x => x.Connections)
                            .Where(y => y.ExtractedProcessName == selectedProcessName && y.RemotePort == selectedRemotePort).ToList();

                        //SetTotalDuration(fileTcpConnections[0].DateTime, fileTcpConnections[fileTcpConnections.Count() -1].DateTime);
                        var groupByData = GroupBy(filteredData, selectedProcessName, true);
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = groupByData;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} {ex.StackTrace}");
            }
        }

        private void SetTotalDuration(DateTime startDateTime, DateTime endDateTime)
        {
            TimeSpan difference = endDateTime - startDateTime;
            TotalDurationLabel.Text = $"{difference.Days} days, {difference.Hours} hours, {difference.Minutes} minutes, {difference.Seconds} seconds";
        }

        private object GroupBy(List<TcpConnection> tcpConnectionsByProcess, string processName, bool sortByDateTime = false)
        {
            if (sortByDateTime)
            {
                var groupBy = tcpConnectionsByProcess.GroupBy(x => new { x.RemotePort, x.Timestamp }).Select(group =>
               new
               {
                   DateTime = group.Key.Timestamp,
                   ProcessName = group.FirstOrDefault(x => x.ExtractedProcessName == processName).ExtractedProcessName,
                   RemotePort = group.Key,
                   TotalConnectionsCount = group.Count()
               }).OrderBy(result => result.DateTime).ToList();

                return groupBy;
            }
            else
            {
                var groupBy = tcpConnectionsByProcess.GroupBy(x => new { x.RemotePort, x.Timestamp }).Select(group =>
                new
                {
                    DateTime = group.Key.Timestamp,
                    ProcessName = group.FirstOrDefault(x => x.ExtractedProcessName == processName).ExtractedProcessName,
                    RemotePort = group.Key,
                    TotalConnectionsCount = group.Count()
                }).OrderByDescending(result => result.TotalConnectionsCount).ToList();

                return groupBy;
            }

        }



        #endregion
    }
}
