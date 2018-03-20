using System;
using System.Diagnostics;
using System.Net.NetworkInformation;


///Simple and useful - pings remote host programmically 

namespace NetworkCommunication {
    public class ConnectionManager
    {
        public int PortNumber { get; private set; }
        public string HostName { get; private set; }
        public ConnectionManager(string hostName, int portNumber) {
            this.HostName = hostName;
            this.PortNumber = portNumber;
            }

        public int TestConnection() {
            using (var ping = new Ping()) {
                try {
                    var pingReply = ping.Send(HostName, 2000);
                    if (pingReply.Status.Equals(IPStatus.Success)){
                        return 0;
                        }
                    else {
                        return 1;
                        }
                    }
                catch (Exception ex) {
                    Debug.WriteLine("Exception while trying to ping: {0}", ex);
                    return 1;
                    }
                }
            }
    }
}