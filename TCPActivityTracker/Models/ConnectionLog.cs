using System;
using System.Collections.Generic;

namespace NetworkConnections_Extractor
{
    /// <summary>
    /// Represents each log (.csv) file generated for at regular interval
    /// </summary>
    public class ConnectionLog
    {
        public string FileName { get; set; }

        public DateTime DateTime { get; set; }

        public List<TcpConnection> Connections { get; set; }

        public ConnectionLog()
        {
            Connections = new List<TcpConnection>();
        }
    }
}
