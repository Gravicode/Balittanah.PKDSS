using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PKDSS.MonoApp.Helper
{
    public class NamedPipesCom:IDisposable
    {
        public delegate void DataReceivedHandler(string Message);
        public event DataReceivedHandler DataReceived;
        public bool IsConnected { get; set; } = false;
        NamedPipeServerStream pipeServer;
        Thread thRead;
        readonly string PipeName = "testpipe";
        public NamedPipesCom()
        {
            Setup();
        }

        void ReadIncomingData()
        {
            StreamReader sr = new StreamReader(pipeServer);
            while (true)
            {
                var msg = sr.ReadLine();
                if (msg != null)
                {
                    //invoke handler
                    DataReceived?.Invoke(msg);
                }
                Thread.Sleep(500);
            }
        }
        async Task Setup()
        {
            pipeServer = new NamedPipeServerStream(PipeName, PipeDirection.Out);

            Console.WriteLine("NamedPipeServerStream object created.");

            // Wait for a client to connect
            Console.Write("Waiting for client connection...");
            await pipeServer.WaitForConnectionAsync();
           
            Console.WriteLine("Client connected.");
            IsConnected = true;
            thRead = new Thread(new ThreadStart(ReadIncomingData));
            thRead.Start();
        }

        public void SendMessage(string Message)
        {
            if (!IsConnected) return;
            try
            {
                // Read user input and send that to the client process.
                using (StreamWriter sw = new StreamWriter(pipeServer))
                {
                    sw.AutoFlush = true;
                    //Console.Write("Enter text: ");
                    sw.WriteLine(Message);
                }
            }
            // Catch the IOException that is raised if the pipe is broken
            // or disconnected.
            catch (IOException e)
            {
                Console.WriteLine("ERROR SEND MSG: {0}", e.Message);
            }
        }

        public void Dispose()
        {
            if (IsConnected)
            {
                pipeServer.Disconnect();
                thRead.Abort();
            }
            pipeServer.Dispose();
        }
    }
}
