using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;

namespace NetworkCommunication {

///Simple and useful - Sometimes it may be neccessary to read a statically served file from remote host and store it into specific location. 
///Short snippet calling for such file and storing it in specified location

    public class ConnectionManager
    {
        public int PortNumber { get; private set; }
        public string HostName { get; private set; }
        public ConnectionManager(string hostName, int portNumber) {
            this.HostName = hostName;
            this.PortNumber = portNumber;
            }      

        public int DownloadFilesFromRemoteHost(string nameOfFileToDownload, string desiredFileLocation) {
			WebClient webClient = new WebClient();
                var httpQuery = "http://"+ this.HostName + ":" + this.PortNumber + "/" + nameOfFileToDownload;                
                using (MemoryStream stream = new MemoryStream(webClient.DownloadData(httpQuery))) {
                    using (FileStream file = new FileStream(desiredFileLocation+nameOfFileToDownload, FileMode.Create, FileAccess.Write)) {
                        stream.WriteTo(file);
                        }
                    }
            return 0;
            }
    }
}
