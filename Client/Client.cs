using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Threading;
using Client.Models;
using Newtonsoft.Json;

namespace Client
{
    public class Client
    {
        static TcpClient tc = new TcpClient("127.0.0.1", 10000);
        NetworkStream stream = tc.GetStream();
        private readonly object thisLock = new();

        public static string UserId { get; set; }

        public enum MsgId : byte
        {
            JOIN, LOGIN, CREATE_MODEL, SHOW_MODEL_LIST, TEST_MODEL, DOWNLOAD_MODEL
        }

        public void ConnectServer()
        {
            Task.Run(() => Receive_msg(tc));
        }



        private async Task Receive_msg(TcpClient tc)
        {
            Receive_Message msg = new();
            byte[] buf = new byte[5000];
            try
            {
                while (true)
                {
                    int len = await stream.ReadAsync(buf, 0, buf.Length);
                    string json = Encoding.UTF8.GetString(buf, 0, len);
                    msg = JsonConvert.DeserializeObject<Receive_Message>(json);
                    // 데이터를 수신하면 스레드를 생성해 처리
                    await Handler(msg);
                }
            }
            catch { }
            finally
            {
                stream.Close();
                tc.Close();
            }
        }

        //

        private async Task Handler(Receive_Message msg)
        {
            switch (msg.MsgId)
            {
                case (byte)MsgId.SHOW_MODEL_LIST: // 할당
                    break;
                case (byte)MsgId.TEST_MODEL: // 할당
                    break;
                case (byte)MsgId.DOWNLOAD_MODEL: // 할당
                    break;
            }

        }


        private byte[] SerializeToJson(Send_Message msg)
        {
            string json = JsonConvert.SerializeObject(msg);
            byte[] sendMsg = Encoding.UTF8.GetBytes(json);
            return sendMsg;
        }

        public async Task Send_msgAsync(Send_Message msg)
        {
            byte[] sendMsg = SerializeToJson(msg);
            await stream.WriteAsync(sendMsg, 0, sendMsg.Length).ConfigureAwait(false);
        }
    }
}
