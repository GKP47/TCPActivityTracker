using System;

namespace NetworkConnections_Extractor
{
    /// <summary>
    /// Represents a TCP Connection details
    /// </summary>
    public class TcpConnection
    {
        public DateTime Timestamp { get; set; }
        public string LocalAddress { get; set; }
        public int LocalPort { get; set; }
        public string RemoteAddress { get; set; }
        public int RemotePort { get; set; }
        public string State { get; set; }
        public int ProcessId { get; set; }
        public string ProcessName { get; set; }
        public int ConnectionCount { get; set; }

        public string ExtractedProcessName
        {
            get
            {
                return ProcessName.Replace("\\", "").Replace("\"", "");
            }
        }
    }
}
