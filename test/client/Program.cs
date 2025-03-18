using System.IO;
using System.Net.Sockets;
using System.Text;

namespace client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpClient tc = new TcpClient("127.0.0.1", 10000);
            NetworkStream stream = tc.GetStream();
            stream.Socket.SendBufferSize = 5242880;
            Console.WriteLine(stream.Socket.SendBufferSize);
            string fileDir = "archive.zip";
            Console.WriteLine("파일 전송 시작");
            //string msg = "1";
            //byte[] buffer= Encoding.UTF8.GetBytes(msg);
            //stream.WriteAsync(buffer);
            stream.Socket.SendFile(fileDir);
            Console.WriteLine("파일 전송 완료");
            Console.Read();
        }
    }
}
