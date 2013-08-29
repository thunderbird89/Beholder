using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using messaging;
using messagesorting;

namespace Beholder
{

    class Program
    {
        static void Main(string[] args)
        {
            Boolean breakFlag = false;
            Queue<defaultDatagramImpl> sortingQueue = new Queue<defaultDatagramImpl>();

            string buffer = "thermo1.thermal.11,22,33.44,55,66.11235";
            int ranNo = 0;
            while (!breakFlag)
            {
                /*
                 * function to retrieve data from the serial interface, into buffer
                 */                
                string[] inputs = buffer.Split(new Char[] { '.' });

                //// Create new sensor node objects, name, transmit message
                //MessageQueuing.SensorNode n1 = new MessageQueuing.SensorNode();
                //n1.setname(sensorID);
                //n1.sendID(n1.name);
                //n1.setlocation(sensorLocation);
                //n1.sendLocation(n1.location);
                //n1.readValue(sensorReading);
                //n1.sendMessage(n1.reading);

                //// start processing queue
                //MessageQueuing.CentralMessageProcessor cmp = new MessageQueuing.CentralMessageProcessor();
                //cmp.startProcessing();

                //Create defaultDatagramImpl object and sorting queue

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
                        Console.WriteLine("Datagram contents: " + dataout.id + "; " + dataout.type + "; " + dataout.position + "; " + dataout.attitude + "; " + dataout.value);
                    }
                }

                if (breakFlag == true)
                    break;
            }
        }
    }
}