using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace NetworkConnections_Extractor
{
    public partial class ChartByProcessForm : Form
    {
        public ChartByProcessForm()
        {
            InitializeComponent();
        }

        private void ChartByProcessForm_Load(object sender, EventArgs e)
        {
            try
            {
                var uniqueProcessName = CsvHelperUtility.Instance.GetTotalUniqueProcessNamesPorts(out var allPorts);

                AllProcessComboBox.DataSource = uniqueProcessName;
                AllPortComboBox.DataSource = allPorts;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} {ex.StackTrace}");
            }
        }

        private void GenerateChartButton_Click(object sender, EventArgs e)
        {
            var timelyConnectionCount = new Dictionary<string, int>();
            try
            {
                string selectedProcess = string.Empty;
                int remotePortNumber = 0;

                var selectedProcessName = AllProcessComboBox.SelectedItem.ToString();
                if (!string.IsNullOrWhiteSpace(selectedProcessName))
                {
                    selectedProcess = selectedProcessName;
                }

                var selectedRemotePort = AllPortComboBox.SelectedItem.ToString();
                if (!string.IsNullOrWhiteSpace(selectedRemotePort))
                {
                    remotePortNumber = Convert.ToInt32(selectedRemotePort);
                }

                var fileTcpConnections = CsvHelperUtility.Instance.GetTcpConnectionsList();
                if (fileTcpConnections != null && fileTcpConnections.Count > 0)
                {
                    foreach (var fileTcpConnection in fileTcpConnections)
                    {
                        var tcpConnections = fileTcpConnection.Connections;
                        if (tcpConnections != null)
                        {
                            int connectionCount;
                            if (remotePortNumber == -1)
                            {
                                connectionCount = tcpConnections.Where(x => x.ExtractedProcessName == selectedProcess).Count();
                            }
                            else
                            {
                                connectionCount = tcpConnections.Where(x => x.ExtractedProcessName == selectedProcess && x.RemotePort == remotePortNumber).Count();
                            }

                            timelyConnectionCount.Add(fileTcpConnection.DateTime.ToString(), connectionCount);
                        }
                    }
                }

                var processName = GetProcessNameByRemotePort(remotePortNumber);
                var portNumerText = remotePortNumber == -1 ? "all ports" : $"selected port number {remotePortNumber}";
                InformationLabel.Text = $"Graph generated for the selected process name - {selectedProcess} and {portNumerText}";
                GenerateChart(timelyConnectionCount, processName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} {ex.StackTrace}");
            }
        }

        private void GenerateChart(Dictionary<string, int> timelyConnectionCount, string yaxisTitle)
        {
            chart1.ChartAreas.Clear();
            chart1.Series.Clear();

            ChartArea chartArea = new ChartArea("MainArea");
            chart1.ChartAreas.Add(chartArea);

            Series series = new Series("Data")
            {
                ChartType = SeriesChartType.Column, // Change to Bar, Pie, etc., as needed
                BorderWidth = 2
            };

            AddDataToSeriesPoints(timelyConnectionCount, series);

            chart1.Series.Add(series);

            foreach (Series series1 in chart1.Series)
            {
                series1.ChartType = SeriesChartType.Column;
            }

            chart1.ChartAreas[0].AxisX.Title = "Date & Time";
            chart1.ChartAreas[0].AxisY.Title = yaxisTitle;
            chart1.ChartAreas[0].AxisX.Interval = 1;
        }

        private string GetProcessNameByRemotePort(int remotePortNumber)
        {
            switch (remotePortNumber)
            {
                case 8500:
                    return "Consul (:8500) Port Count";

                case 5672:
                    return "Consul (:5672) Port Count";

                default:
                    return "All/Other Port Count";
            }
        }

        private void AddDataToSeriesPoints(Dictionary<string, int> consulPortCountList, Series series)
        {
            foreach (var item in consulPortCountList)
            {
                var point = series.Points.AddXY(item.Key, item.Value);
                series.Points[point].ToolTip = $"DateTime - {item.Key} Count - {item.Value}";
            }
        }
    }
}
