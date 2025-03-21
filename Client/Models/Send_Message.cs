using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class Send_Message
    {
        public byte MsgId { get; set; }
        public User UserInfo { get; set; }
        public Model ModelInfo { get; set; }
        public byte[] TestImage { get; set; }
        public List<string> Labels { get; set; }
    }
}
