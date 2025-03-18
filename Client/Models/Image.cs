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
        public object Img { get; set; } // 자료형?
        public string Label { get; set; } = "새 레이블";
    }
}
