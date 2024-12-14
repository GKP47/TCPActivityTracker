using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkConnections_Extractor.Utilities
{
    public class TcpConnectionComparer : IEqualityComparer<TcpConnection>
    {
        public bool Equals(TcpConnection x, TcpConnection y)
        {
            return x.ExtractedProcessName == y.ExtractedProcessName;
        }

        public int GetHashCode(TcpConnection obj)
        {
            return obj.ExtractedProcessName.GetHashCode();
        }
    }
}
