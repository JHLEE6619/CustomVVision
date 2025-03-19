using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class Model
    {
        public string ModelId { get; set; }
        public bool Classification { get; set; }
        public byte Epoch { get; set; }
        public uint ImageWidth { get; set; }
        public uint ImageHeight { get; set; }
    }
}
