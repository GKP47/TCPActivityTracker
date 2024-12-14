using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkConnections_Extractor
{
    public class FileByTcpConnections
    {
        public string FileName { get; set; }

        public DateTime DateTime { get; set; }

        public List<TcpConnection> Connections { get; set; }

        public FileByTcpConnections()
        {
            Connections = new List<TcpConnection>();
        }
    }
}
