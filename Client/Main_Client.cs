﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Threading;
using Client.Models;
using Newtonsoft.Json;

namespace Client
{
    public static class Main_Client
    {
        static TcpClient tc = new TcpClient("127.0.0.1", 10000);
        static NetworkStream stream = tc.GetStream();
        //static TcpClient tc = new();
        //static NetworkStream stream;
        private static readonly object thisLock = new();
        public static List<string> ModelList { get; set; } = [];
        public static string TestResult { get; set; }
        public static Test_model test_model;
        public static string FilePath { get; set; }


        public static string UserId { get; set; }

        public enum MsgId : byte
        {
            JOIN, LOGIN, CREATE_MODEL, SHOW_MODEL_LIST, TEST_MODEL, DOWNLOAD_MODEL
        }

        public static void ConnectServer()
        {
            Task.Run(() => Receive_msg(tc));
        }



        private static async Task Receive_msg(TcpClient tc)
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

        private static async Task Handler(Receive_Message msg)
        {
            switch (msg.MsgId)
            {
                case (byte)MsgId.SHOW_MODEL_LIST:
                    Receive_modelList(msg.ModelList);
                    break;
                case (byte)MsgId.TEST_MODEL:
                    Receive_testResult(msg.TestResult);
                    break;
                case (byte)MsgId.DOWNLOAD_MODEL:
                    Receive_modelFile(msg.ModelFile);
                    break;
            }

        }


        private static byte[] SerializeToJson(Send_Message msg)
        {
            string json = JsonConvert.SerializeObject(msg);
            byte[] sendMsg = Encoding.UTF8.GetBytes(json);
            return sendMsg;
        }

        public static async Task Send_msgAsync(Send_Message msg)
        {
            byte[] sendMsg = SerializeToJson(msg);
            await stream.WriteAsync(sendMsg, 0, sendMsg.Length).ConfigureAwait(false);
        }

        private static void Receive_modelList(List<string> modelList)
        {
            ModelList = modelList;
        }

        private static void Receive_testResult(string testResult)
        {
            test_model.testResult.Result = testResult;
        }

        private static void Receive_modelFile(string modelfile)
        {
            byte[] model = Convert.FromBase64String(modelfile);
            using (var stream = new FileStream(FilePath+"/model.keras" , FileMode.Create, FileAccess.Write))
            {              
                // 파일 쓰기
                stream.Write(model, 0, model.Length);
            }
        }
    }
}
