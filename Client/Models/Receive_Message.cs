using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class Receive_Message
    {
        public byte MsgId { get; set; }
        public List<string> ModelList { get; set; } = [];
        public string TestResult { get; set; }
    }
}
