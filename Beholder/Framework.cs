using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
// Own namespaces
using messagesorting;
using sonics;

namespace Beholder
{
    class Framework
    {
        static void Main()
        {
            Boolean breakFlag = false;
            Queue<defaultDatagramImpl> sortingQueue = new Queue<defaultDatagramImpl>(); //Create message sorting queue
            sonicDatagramImpl dataSonic = new sonicDatagramImpl();
            sonicCrackDetect cracking = new sonicCrackDetect();

            // Sockets commented out because it's fucked up
            #region sockets
            ////Declare Scanner data socket - TCP for reliable, secure transmission of readings
            //Socket PANData = new Socket(SocketType.Stream, ProtocolType.Tcp);

            ////Declare Scanner video socket - UDP for efficient streaming
            //Socket PANVideo = new Socket(SocketType.Dgram, ProtocolType.Udp);

            ////Bind sockets to interface
            ////Bindings may be accomplished through hardcoded IPs, as the PANs are not intended to have more than two devices (scanner+endpoint) at any one time
            //IPAddress AddressSelf = new IPAddress(3232235777); //long format integer stands for 192.168.1.1
            //IPEndPoint EndpointSelf = new IPEndPoint(AddressSelf, 1123);
            //PANData.Bind(EndpointSelf);
            #endregion

            string buffer = "thermo1.thermal.11,22,33.44,55,66.11235";
            int ranNo = 0;

            while (!breakFlag)
            {
                /*
                 * function to retrieve data from the serial interface, into buffer
                 */
                string[] inputs = buffer.Split(new Char[] { '.' });

                //Parse data into defaultDatagramImpl and enqueue
                defaultDatagramImpl data = new defaultDatagramImpl();
                data.id = inputs[0];
                data.type = inputs[1];
                data.position = inputs[2];
                data.attitude = inputs[3];
                data.value = inputs[4];
                sortingQueue.Enqueue(data);

                ranNo++;
                buffer += ranNo;

                System.Console.WriteLine("Value: " + inputs[4]);
                System.Console.WriteLine("Count: " + sortingQueue.Count);


                if (sortingQueue.Count == 5)
                {
                    while (sortingQueue.Count > 0)
                    {
                        defaultDatagramImpl dataout = new defaultDatagramImpl(sortingQueue.Dequeue());
                        switch(dataout.type)
                        {
                            case "sonic":
                                {
                                    //transfer control to sonics
                                    break;
                                }
                            case "thermal":
                                {
                                    //thermal block
                                    break;
                                }
                            case "spectral":
                                {
                                    //spectral block
                                    break;
                                }
                            case "vision":
                                {
                                    //visual
                                    break;
                                }
                        }
                    }
                }

                if (breakFlag == true)
                    break;
            }
        }
    }

}