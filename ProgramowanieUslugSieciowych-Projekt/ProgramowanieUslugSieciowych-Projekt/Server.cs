using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramowanieUslugSieciowych_Projekt
{
    public partial class Server : Form
    {
        static TcpListener tcpListener = new TcpListener(10);
        static TcpListener listenerForLogger = new TcpListener(1800);
        static int clientCounter = 0;
        //static Logger.Logger log;
        public Server()
        {
            InitializeComponent();

            tcpListener.Start();
            listenerForLogger.Start();
            Thread threadForServer = new Thread(RunServer);
            threadForServer.Start();

            SetCounterView();
        }

        public static void RunServer()
        {
            for (;;)
            {
                Socket socketForClient = tcpListener.AcceptSocket();
                Thread thread = new Thread(() => ConnectedClient(socketForClient));           
                thread.Start();
            }
        }

        public void SetCounterView()
        {
            threadCounter.Text = clientCounter.ToString();
        }

        static void ConnectedClient(Socket socketForClient)
        {
            Debugger.Break();
            //Console.ReadKey();
            Debug.Print("Client is connected, hello");
            if (socketForClient.Connected)
            {
                clientCounter++;
                //log.WriteLog(Level.DEBUG, "Client:" + socketForClient.RemoteEndPoint + " now connected to server.");
                NetworkStream networkStream = new NetworkStream(socketForClient);
                System.IO.StreamWriter streamWriter =
                new System.IO.StreamWriter(networkStream);
                System.IO.StreamReader streamReader =
                new System.IO.StreamReader(networkStream);

                //here we recieve client's text if any.
                while (true)
                {
                    string theString = streamReader.ReadLine();
                    if (theString.Length > 10)
                    {
                        //log.WriteLog(Level.ALERT, "Message recieved by client: " + socketForClient.RemoteEndPoint + ": " + theString);
                    }
                    else
                    {
                        //log.WriteLog(Level.DEBUG, "Message recieved by client: " + socketForClient.RemoteEndPoint + ": " + theString);
                    }
                    if (theString == "exit")
                        break;
                }
                streamReader.Close();
                networkStream.Close();
                streamWriter.Close();
            }
            socketForClient.Close();
           
            //log.WriteLog(Level.INFO, "Press any key to exit from server program");
            Console.ReadKey();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SetCounterView();
        }
    }


}
