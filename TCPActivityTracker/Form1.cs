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
                    LoadConnectionLogs(data);
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
                if (selectedValue != null && selectedValue is ConnectionLog connectionLog)
                {
                    SelectedFileNameLabel.Text = connectionLog.FileName;
                    DateLabel.Text = connectionLog.DateTime.ToString();
                    LoadImportantData(connectionLog.FileName);

                    if (GroupByProcessAndPortCheckBox.Checked)
                    {
                        ShowDataByLogFile(connectionLog.FileName);
                    }
                    else
                    {
                        ProcessNamesListBox.DataSource = null;
                        ProcessNamesListBox.DataSource = CsvHelperUtility.Instance.GetUniqueProcessNamesBySelectedLogFile(connectionLog.FileName);
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
                        ShowDataByLogFile(SelectedFileNameLabel.Text.Trim());
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

        private void button2_Click(object sender, EventArgs e)
        {
            new ConsulLogExtractor().Show();
        }

        private void GenerateDataForSelectedProcessButton_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedRemotePort = -1;
                var connectionLogs = CsvHelperUtility.Instance.GetConnectionLogs();
                if (connectionLogs != null && connectionLogs.Count > 0)
                {
                    var selectedProcessName = ProcessNamesListBox.SelectedItem.ToString();
                    if (AllPortComboBox.SelectedItem != null)
                    {
                        selectedRemotePort = Convert.ToInt32(AllPortComboBox.SelectedItem);
                    }

                    if (!string.IsNullOrWhiteSpace(selectedProcessName))
                    {
                        var filteredData = connectionLogs.SelectMany(x => x.Connections)
                            .Where(y => y.ExtractedProcessName == selectedProcessName && y.RemotePort == selectedRemotePort).ToList();

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

        #endregion

        #region Private Methods

        private void SetToolTip()
        {
            SetToolTip(GenerateDataForSelectedProcessButton, "This button generates data for the selected process and remote port number from all the files loaded in the file name list box.");
            SetToolTip(ConsulPortCountLabel, "Total active Port connection count to Consul Server (:8500) for the selected file in the file name list box");
            SetToolTip(RMQPortCountLabel, "Total active Port connection count to RMQ Server (:5672) for the selected file in the file name list box");
            SetToolTip(TotalAllPortCountLabel, "Total active Port connection count for the selected file in the file name list box");
            SetToolTip(TotalDurationLabel, "Total time monitored");
        }

        private void SetToolTip(Control control, string message)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(control, message);
        }

        private string[] SelectFolder()
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select a folder containing CSV files";

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the selected folder path
                    string selectedFolderPath = folderDialog.SelectedPath;
                    SelectedFolderPathLabel.Text = selectedFolderPath;

                    // Load all CSV files from the folder
                    return LoadFilesInDirectory(selectedFolderPath);
                }

                return null;
            }
        }

        private string[] LoadFilesInDirectory(string selectedFolderPath)
        {
            string[] csvFiles = Directory.GetFiles(selectedFolderPath, "*.csv");

            if (csvFiles.Any())
            {
                return csvFiles;
            }
            else
            {
                MessageBox.Show("No CSV files found in the selected folder.", "No Files Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return null;
        }

        private void LoadConnectionLogs(List<ConnectionLog> connectionLogs)
        {
            try
            {
                FilesListBox.DataSource = null;
                FilesListBox.DataSource = connectionLogs;
                FilesListBox.DisplayMember = "FileName";
                FilesListBox.ValueMember = "FileName";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} {ex.StackTrace}");
            }
        }

        private void LoadSelectedProcessDetails(string processName, string selectedLogFile)
        {
            var tcpConnections = CsvHelperUtility.Instance.GetTcpConnectionsFromLogFile(selectedLogFile);
            //var tcpConnections = connectionLogs.Where(x => x.FileName == selectedLogFile).SelectMany(x => x.Connections);
            if (tcpConnections != null)
            {
                var tcpConnectionsByProcess = tcpConnections.Where(x => x.ExtractedProcessName == processName).ToList();
                var groupBy = GroupBy(tcpConnectionsByProcess, processName);

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = groupBy;
            }
        }

        private void ShowDataByLogFile(string selectedLogFile)
        {
            var tcpConnections = CsvHelperUtility.Instance.GetTcpConnectionsFromLogFile(selectedLogFile);
            //var tcpConnections = connectionLogs.Where(x => x.FileName == selectedLogFile).SelectMany(x => x.Connections);
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

        private void LoadImportantData(string selectedLogFile)
        {
            var tcpConnections = CsvHelperUtility.Instance.GetTcpConnectionsFromLogFile(selectedLogFile);
            if (tcpConnections != null)
            {
                CsvHelperUtility.Instance.GetSelectedPortTotalCount(tcpConnections, 8500, out var consulPortCount);
                CsvHelperUtility.Instance.GetSelectedPortTotalCount(tcpConnections, 5672, out var rmqPortCount);
                CsvHelperUtility.Instance.GetAllActivePortCount(tcpConnections, out var allPortCount);

                var allPorts = tcpConnections.Select(x => x.RemotePort).Distinct().OrderBy(x => x).ToList();
                allPorts.Insert(0, -1);

                ConsulPortCountLabel.Text = consulPortCount.ToString();
                RMQPortCountLabel.Text = rmqPortCount.ToString();
                TotalAllPortCountLabel.Text = allPortCount.ToString();

                AllPortComboBox.DataSource = null;
                AllPortComboBox.DataSource = allPorts;
            }
        }

        private void FilterDataByPortNumber(string selectedLogFile, int selectedRemotePort)
        {
            var tcpConnections = CsvHelperUtility.Instance.GetTcpConnectionsFromLogFile(selectedLogFile);
            if (tcpConnections != null)
            {
                var groupBy = tcpConnections.Where(x => x.RemotePort == selectedRemotePort).GroupBy(x => new { x.RemotePort, x.ExtractedProcessName })
                    .Select(group => new
                    {
                        ProcessName = group.Key.ExtractedProcessName,
                        group.Key.RemotePort,
                        TotalConnectionsCount = group.Count()
                    }).OrderByDescending(result => result.TotalConnectionsCount).ToList();

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = groupBy;
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
