using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace messaging
{

    interface SubsystemInterface
    {
        int sendMessage(String message);
        CMPMessage receiveMessage();
    }

    public struct CMPMessage
    {
        private String _message;
        private Type _sender;

        public String message
        {
            get
            {
                return _message;
            }
            set
            {
                this._message = value;
            }
        }

        public Type sender
        {
            get
            {
                return _sender;
            }
            set
            {
                this._sender = value;
            }
        }

        public CMPMessage(String msg, Type s)
        {
            _message = msg;
            _sender = s;
        }
    }


    class MessageQueuing
    {
        public static Queue<CMPMessage> messageQueue = new Queue<CMPMessage>();

        public class SensorNode : SubsystemInterface
        {

            public string name;
            public string reading;
            public string location;
            private void processHardwareInput()
            {
                // extremely hardcore algorithm
                // sends the message to the CMP
            }

            /// <summary>
            /// Send message to CMP - only public for debugging purposes
            /// </summary>
            /// <param name="message">Message to send to CMP</param>
            /// <returns></returns>
            public int sendMessage(String message)
            {
                CMPMessage m = new CMPMessage(message, this.GetType());
                MessageQueuing.messageQueue.Enqueue(m);
                return m.message.Length;
            }

            public int sendID(String id)
                {
                    CMPMessage sensorid = new CMPMessage(id, this.GetType());
                    MessageQueuing.messageQueue.Enqueue(sensorid);
                    return sensorid.message.Length;
                }

            public int sendLocation(String locus)
                {
                CMPMessage sensorlocus = new CMPMessage(locus, this.GetType());
                MessageQueuing.messageQueue.Enqueue(sensorlocus);
                return sensorlocus.message.Length;
                }


            public void setname(string Sensorname)
                {
                name = Sensorname;
                }

            public void setlocation(string loc)
                {
                location = loc;
                }

            public void readValue(string value)
                {
                reading = value;
                }
                        
            public CMPMessage receiveMessage()
            {
                return MessageQueuing.messageQueue.Dequeue();
            }


        }

        public class CentralMessageProcessor
        {
            public void startProcessing()
            {
                while (messageQueue.Count > 0)
                {
                    CMPMessage msg = messageQueue.Dequeue();
                    CMPMessage id = messageQueue.Dequeue();
                    CMPMessage loc = messageQueue.Dequeue();
                    Console.WriteLine(msg.sender.Name + " " + msg.message + " " + id.message + " " + loc.message); //Why the fuck are these displayed in reverse order?!
                }
            }
        }

        static void processMessages(string[] args)
        {
            //int c;

            //SensorNode n1 = new SensorNode();
            //n1.setname("thermo1"); //Set sensor name for queue
            //n1.sendID(n1.name); //Queue up sensor ID
            //n1.readValue("hot!");
            //n1.sendMessage(n1.reading); //Queue up sensor value

            //SensorNode cam1 = new SensorNode();
            //cam1.setname("cam1");
            //cam1.sendID(cam1.name);
            //cam1.readValue("bleargh");
            //cam1.sendMessage(cam1.reading);

            CentralMessageProcessor cmp = new CentralMessageProcessor();
            cmp.startProcessing();

            //c = Console.Read();
        }
    }
}
