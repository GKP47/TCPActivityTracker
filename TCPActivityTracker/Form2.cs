using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace NetworkConnections_Extractor
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            //panel1.Dock = DockStyle.Fill;   // Panel occupies the entire form
            //chart1.Dock = DockStyle.Fill;
            //GenerateConsulPortTrendChart();
        }

        private void GenerateConsulPortTrendChart()
        {
            try
            {
                CalculatePortCountByFileName(out var consulPortCountList, out var rmqPortCountList);

                ChartArea chartArea = new ChartArea("MainArea");
                chart1.ChartAreas.Add(chartArea);

                Series series = new Series("Consul Port Generation Data")
                {
                    ChartType = SeriesChartType.Column, // Change to Bar, Pie, etc., as needed
                    BorderWidth = 2
                };

                AddDataToSeriesPoints(consulPortCountList, series);

                chart1.Series.Add(series);

                foreach (Series series1 in chart1.Series)
                {
                    series1.ChartType = SeriesChartType.Column;
                }

                chart1.ChartAreas[0].AxisX.Title = "Date & Time";
                chart1.ChartAreas[0].AxisY.Title = "Consul (:8500) Port Count";
                chart1.ChartAreas[0].AxisX.Interval = 1;

                // Add Chart to Form
                //panel1.Controls.Add(chart1);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} {ex.StackTrace}");
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

        private void CalculatePortCountByFileName(out Dictionary<string, int> consulPortCountList, out Dictionary<string, int> rmqPortCountList)
        {
            consulPortCountList = new Dictionary<string, int>();
            rmqPortCountList = new Dictionary<string, int>();

            var fileTcpConnections = CsvHelperUtility.Instance.GetConnectionLogs();
            if (fileTcpConnections != null && fileTcpConnections.Count > 0)
            {
                foreach (var fileTcpConnection in fileTcpConnections)
                {
                    var tcpConnections = fileTcpConnection.Connections;
                    if (tcpConnections != null)
                    {
                        CsvHelperUtility.Instance.GetSelectedPortTotalCount(tcpConnections, 8500, out var consulPortCount);
                        CsvHelperUtility.Instance.GetSelectedPortTotalCount(tcpConnections, 8500, out var rmqPortCount);

                        consulPortCountList.Add(fileTcpConnection.DateTime.ToString(), consulPortCount);
                        rmqPortCountList.Add(fileTcpConnection.DateTime.ToString(), rmqPortCount);
                    }
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                GenerateConsulPortTrendChart();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message} {ex.StackTrace}");
            }
        }
    }
}
