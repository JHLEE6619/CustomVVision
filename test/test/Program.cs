using System.Net.Sockets;
using System.Net;
using System.Runtime.Intrinsics.X86;
using System;

namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpListener listener = new TcpListener(IPAddress.Any, 10000);
            Console.WriteLine(" 서버 시작 ");
            listener.Start();
            TcpClient client = listener.AcceptTcpClient();
            TcpClient tc = client;
            NetworkStream stream = tc.GetStream();
            string fileDir = "test.zip";

            int cnt = 0;
            stream.Socket.ReceiveBufferSize = 5242880;
            Console.WriteLine(stream.Socket.ReceiveBufferSize);

            using (FileStream fs = new FileStream(fileDir, FileMode.Create, FileAccess.Write))
            {
                byte[] buffer = new byte[stream.Socket.ReceiveBufferSize];
                int size;
                try
                {
                    while ((size = stream.Socket.Receive(buffer)) > 0)
                    {
                        Console.WriteLine(size);
                        fs.Write(buffer, 0, size);
                        cnt++;
                    }
                }
                catch (Exception ex) 
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            Console.WriteLine($"파일 수신 완료: {cnt}");

        }
    }
}
