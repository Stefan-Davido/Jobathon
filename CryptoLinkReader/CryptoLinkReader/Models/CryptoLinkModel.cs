using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoLinkReader.Models
{
    public class CryptoLinkModel
    {
        public string Title{ get; set; }
        public string img { get; set; }
        public string Crypto { get; set; }
        public int RaisingCounter{ get; set; }
        public int FallingCounter{ get; set; }
        public string URL{ get; set; }
    }
}
