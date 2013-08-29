using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace messagesorting
{
    interface IDatagram
    {
        // Property signatures: 
        string id
        {
            get;
            set;
        }

        //string type
        //{
        //    get;
        //    set;
        //}

        //string position
        //{
        //    get;
        //    set;
        //}

        //string attitude
        //{
        //    get;
        //    set;
        //}

        string value
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Default datagram implementation: this is the basic form of a datagram as received from any of the interfaces, ready for sorting into the various worker threads
    /// </summary>
    public class defaultDatagramImpl : IDatagram
    {
        // Fields: 
        private string _id;
        private string _type;
        private string _position;
        private string _attitude;
        private string _value;
        public int i;

        // Constructors: 
        public defaultDatagramImpl(string id, string type, string position, string attitude, string value) //fully qualified cosntructor takes all properties as arguments
        {
            _id = id;
            _type = type;
            _position = position;
            _attitude = attitude;
            _value = value;
        }
        public defaultDatagramImpl() //zero cosntructor intitalizes a blank instance, with properties being injected later
        {
            _id = "";
            _type = "";
            _position = "";
            _attitude = "";
            _value = "";
        }
        //Copy constructor used to create a new instance of the object to allow queued instances to retain their contents while others are modified
        public defaultDatagramImpl(defaultDatagramImpl data)
        {
            this.i = data.i;
            _id = data.id;
            _type = data.type;
            _position = data.position;
            _attitude = data.attitude;
            _value = data.value;
        }

        // Property implementation: 
        public string id
        {
            get
            {
                return _id;
            }

            set
            {
                if (value == null)
                    throw new Exception("");
                _id = value;
            }
        }
        public string type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }
        public string position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
            }
        }
        public string attitude
        {
            get
            {
                return _attitude;
            }
            set
            {
                _attitude = value;
            }
        }
        public string value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }
    }

    public class sonicDatagramImpl : IDatagram
    {
        private string _id;
        private string _value;

        /// <summary>
        /// Blank constructor initializes the object with blanked properties, which are injected later.
        /// </summary>
        public sonicDatagramImpl()
        {
            _id = "";
            _value = "";
        }

        /// <summary>
        /// Copy constructor takes datagram output from the main sorting queue, strips unneccessary fields, and passes sensor ID and value to sonicDatagram object for further analysis.
        /// </summary>
        /// <param name="dataout"></param>
        public sonicDatagramImpl(defaultDatagramImpl dataout)
        {
            _id = dataout.id;
            _value = dataout.value;
        }

        public string id
        {
            get
            {
                return _id;
            }

            set
            {
                if (value == null)
                    throw new Exception("");
                _id = value;
            }
        }
        public string value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

    }
}
