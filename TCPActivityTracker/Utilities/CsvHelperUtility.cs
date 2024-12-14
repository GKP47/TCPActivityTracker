using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace NetworkConnections_Extractor
{
    public class CsvHelperUtility
    {
        private static CsvHelperUtility instance;
        private CsvHelperUtility()
        {

        }

        public static CsvHelperUtility Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CsvHelperUtility();
                }

                return instance;
            }
        }

        List<ConnectionLog> connectionLogs;

        public List<ConnectionLog> ReadCsvFiles(string[] filePaths)
        {

            try
            {
                connectionLogs = new List<ConnectionLog>();
                foreach (string filePath in filePaths)
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string line;
                        bool isHeader = true;
                        var tcpConnections = new List<TcpConnection>();
                        var connectionLog = new ConnectionLog();
                        connectionLog.FileName = ExtractFileName(filePath, out var parsedDateTime);
                        connectionLog.DateTime = parsedDateTime;

                        while ((line = reader.ReadLine()) != null)
                        {
                            if (isHeader)
                            {
                                // Skip the header row
                                isHeader = false;
                                continue;
                            }

                            string[] values = line.Split(',');

                            if (values.Length >= 6) // Ensure there are enough columns
                            {
                                try
                                {
                                    var localPortNumber = values[1].Replace("\\", "").Replace("\"", "");
                                    var remotePortNumber = values[3].Replace("\\", "").Replace("\"", "");
                                    var processIdNumber = values[5].Replace("\\", "").Replace("\"", "");
                                    TcpConnection connection = new TcpConnection
                                    {
                                        Timestamp = parsedDateTime,
                                        LocalAddress = values[0],
                                        LocalPort = int.Parse(localPortNumber),
                                        RemoteAddress = values[2],
                                        RemotePort = int.Parse(remotePortNumber),
                                        State = values[4],
                                        ProcessId = int.Parse(processIdNumber),
                                        ProcessName = values[6]
                                    };
                                    tcpConnections.Add(connection);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"Error parsing line: {line}\n{ex.Message}", "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }

                        connectionLog.Connections = tcpConnections;
                        connectionLogs.Add(connectionLog);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} {ex.StackTrace}");
            }

            return connectionLogs;
        }

        public void GetSelectedPortTotalCount(IEnumerable<TcpConnection> tcpConnections, int remotePortNumber, out int remotePortCount)
        {
            remotePortCount = default;
            if (tcpConnections != null)
            {
                remotePortCount = tcpConnections.Where(x => x.RemotePort == remotePortNumber).Count();
            }
        }

        public void GetConsulRMQPortCount(IEnumerable<TcpConnection> tcpConnections, out int consulPortCount, out int rmqPortCount)
        {
            consulPortCount = 0;
            rmqPortCount = 0;

            if (tcpConnections != null)
            {
                consulPortCount = tcpConnections.Where(x => x.RemotePort == 8500).Count();
                rmqPortCount = tcpConnections.Where(x => x.RemotePort == 5672).Count();
            }
        }

        public void GetAllActivePortCount(IEnumerable<TcpConnection> tcpConnections, out int totalPortCount)
        {
            totalPortCount = 0;

            if (tcpConnections != null)
            {
                totalPortCount = tcpConnections.Where(x => x.RemotePort != 0).Count();
            }
        }

        private string ExtractFileName(string fileFullPath, out DateTime parsedDateTime)
        {
            // Extract the file name without the extension
            string fileName = Path.GetFileNameWithoutExtension(fileFullPath);

            // Split the file name into parts
            string[] parts = fileName.Split('_');
            parsedDateTime = DateTime.Now;

            if (parts.Length == 3)
            {
                // Extract date and time from the file name
                string datePart = parts[1];
                string timePart = parts[2];

                // Parse the date and time into a DateTime object
                DateTime.TryParseExact(datePart + timePart, "yyyyMMddHHmmss", null, System.Globalization.DateTimeStyles.None, out parsedDateTime);
            }
            else
            {
                Console.WriteLine("File name format is incorrect.");
            }

            return fileName;
        }

        public List<ConnectionLog> GetConnectionLogs()
        {
            return connectionLogs;
        }

        public List<string> GetTotalUniqueProcessNamesPorts(out List<int> allPorts)
        {
            var connectionLogs = GetConnectionLogs();
            var allConnections = connectionLogs.SelectMany(x => x.Connections);
            var uniqueProcessName = ExtractUniqueProcessNames(allConnections);

            allPorts = allConnections.Select(x => x.RemotePort).Distinct().OrderBy(x => x).ToList();
            allPorts.Insert(0, -1);

            return uniqueProcessName;
        }

        public List<string> GetUniqueProcessNamesBySelectedLogFile(string selectedLogFile)
        {
            var tcpConnections = GetTcpConnectionsFromLogFile(selectedLogFile);
            if (tcpConnections != null)
            {
                return ExtractUniqueProcessNames(tcpConnections);
            }

            return null;
        }

        private List<string> ExtractUniqueProcessNames(IEnumerable<TcpConnection> tcpConnections)
        {
            return tcpConnections.Select(x => x.ExtractedProcessName).Distinct().OrderBy(x => x).ToList();
        }

        public IEnumerable<TcpConnection> GetTcpConnectionsFromLogFile(string selectedLogFile)
        {
            var connectionLogs = GetConnectionLogs();
            var tcpConnections = connectionLogs.Where(x => x.FileName == selectedLogFile).SelectMany(x => x.Connections);
            return tcpConnections;
        }
    }
}
