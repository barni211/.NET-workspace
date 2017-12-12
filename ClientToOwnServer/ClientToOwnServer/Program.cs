﻿using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientToServer
{
    class Program
    {
        private static Logger.Logger log;
        static void Main(string[] args)
        {
            int num = 143;
            createLogger();
            TcpClient socketForServer;
            try
            {
                socketForServer = new TcpClient("localHost", 1800);
            }
            catch
            {
                log.WriteLog(Level.ERROR,
                "Failed to connect to server at {0}:999" + "localhost");
                return;
            }

            NetworkStream networkStream = socketForServer.GetStream();
            System.IO.StreamReader streamReader =
            new System.IO.StreamReader(networkStream);
            System.IO.StreamWriter streamWriter =
            new System.IO.StreamWriter(networkStream);
            log.WriteLog(Level.INFO, "*******This is client program who is connected to localhost on port No:10*****");

            try
            {
                string outputString;
                // read the data from the host and display it
                {
                    //outputString = streamReader.ReadLine();
                    //Console.WriteLine("Message Recieved by server:" + outputString);

                    //Console.WriteLine("Type your message to be recieved by server:");
                    Console.WriteLine("type:");
                    string str = Console.ReadLine();
                    while (str != "exit")
                    {
                        streamWriter.WriteLine(str);
                        streamWriter.Flush();
                        Console.WriteLine("type:");
                        str = Console.ReadLine();
                    }
                    if (str == "exit")
                    {
                        streamWriter.WriteLine(str);
                        streamWriter.Flush();

                    }

                }
            }
            catch
            {
                log.WriteLog(Level.ERROR, "Exception reading from Server");
            }
            // tidy up
            networkStream.Close();
            Console.WriteLine("Press any key to exit from client program");
            Console.ReadKey();
            
        }

        private static string GetData()
        {
            //Ack from sql server
            return "ack";
        }

        static void createLogger()
        {
            log = new Logger.Logger();
            Logger.ConsoleOutputter cons = new ConsoleOutputter();
            Logger.FileOutputter file = new FileOutputter();
            log.SetLoggerLevel(Level.DEBUG);
            log.SetLoggerOutput(cons);
            log.SetLoggerOutput(file);
        }

    }
}
