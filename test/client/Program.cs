using System.IO;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;

namespace client
{
    internal class Program
    {
        public class User
        {
            public string Name;
            public string Password;
        }

        public class Send_Message
        {
            public byte MsgId { get; set; }
            public User UserInfo { get; set; }
        }

        static void Main(string[] args)
        {
            TcpClient tc = new TcpClient("127.0.0.1", 10000);
            NetworkStream stream = tc.GetStream();
            stream.Socket.SendBufferSize = 5242880;
            Console.WriteLine(stream.Socket.SendBufferSize);
            string fileDir = "archive.zip";
            Console.WriteLine("파일 전송 시작");
            string msg = "1";
            byte[] buffer = Encoding.UTF8.GetBytes(msg);
            stream.WriteAsync(buffer);
            stream.Socket.SendFile(fileDir);
            Console.WriteLine("파일 전송 완료");
            Console.Read();
            //string msg;
            //while (true)
            //{
            //    Console.Write("입력 : ");
            //    msg = Console.ReadLine();
            //    byte[] buffer = Encoding.UTF8.GetBytes(msg);
            //    stream.Write(buffer);

            //}

            //Send_Message msg = new() { MsgId = 1, UserInfo = new User() { Name = "이정협", Password = "1234" } };
            //string json = JsonConvert.SerializeObject(msg);
            //Console.WriteLine(json);


        }
    }
}
