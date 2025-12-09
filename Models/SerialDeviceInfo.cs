using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialScannerApp.Models
{
    public class SerialDeviceInfo
    {
        public string PortName { get; set; }
        public string Description { get; set; }
        public bool IsScanner { get; set; }
    }
}
