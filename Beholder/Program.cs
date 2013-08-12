using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using messaging;

namespace Beholder
    {
    public struct bufferQueue
        {

        private string _datagram;

        public string data
            {
            get
                {
                return _datagram;
                }
            set
                {
                this._datagram = value;
                }
            }

        public bufferQueue(string datagram)
            {
            _datagram = datagram;
            }
        }


        class Program
            {
            static void Main(string[] args)
                {
                int meh;

                Boolean breakFlag = false;
                while (!breakFlag)
                    {
                    //function to retrieve data from the serial interface, into buffer
                    string buffer = " ";

                    string[] inputs = buffer.Split(new Char[] { '.' });
                    string sensorID = inputs[0];
                    string sensorLocation = inputs[1];
                    string sensorReading = inputs[2];

                    // Create new sensor node objects, name, transmit message
                    MessageQueuing.SensorNode n1 = new MessageQueuing.SensorNode();
                    n1.setname(sensorID);
                    n1.sendID(n1.name);
                    n1.setlocation(sensorLocation);
                    n1.sendLocation(n1.location);
                    n1.readValue(sensorReading);
                    n1.sendMessage(n1.reading);

                    // start processing queue
                    MessageQueuing.CentralMessageProcessor cmp = new MessageQueuing.CentralMessageProcessor();
                    cmp.startProcessing();

                    meh = Console.Read();
                    string ch = Convert.ToString(meh);
                    if (ch == "x")
                        breakFlag = true;
                    if (breakFlag == true)
                        break;
                    }
                }
            }
        }