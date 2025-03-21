using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class Image
    {
        public string ModelId { get; set; }
        public byte[] ImgFile { get; set; }
        public string Label { get; set; }
        public string ImgUri { get; set; }
    }
}
