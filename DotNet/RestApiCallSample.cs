using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;

namespace NetworkCommunication {


///Simple and useful - calls REST API function using HTTP client. 
///Resources worth reading: https://blogs.msdn.microsoft.com/henrikn/2012/02/16/httpclient-is-here/

    public class ConnectionManager
    {
        public int PortNumber { get; private set; }
        public string HostName { get; private set; }
        public ConnectionManager(string hostName, int portNumber) {
            this.HostName = hostName;
            this.PortNumber = portNumber;
            }      

        public void SpecificFunctionCall() {
            var response = ApiRestHandler("SomeRestFunction");
            Debug.WriteLine("Function returned: " + response);
            }

        private string ApiRestHandler(string function) {
            string result; 
            using (var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate })) {                
                client.BaseAddress = new UriBuilder("http", this.HostName, this.PortNumber).Uri;                
                HttpResponseMessage response = client.GetAsync(function).Result;
                response.EnsureSuccessStatusCode();
                result = response.Content.ReadAsStringAsync().Result;                
                }
            return result;
            }
    }
}
