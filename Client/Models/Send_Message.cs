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
        public Model modelInfo { get; set; }
        public Image imageInfo { get; set; }
    }
}
