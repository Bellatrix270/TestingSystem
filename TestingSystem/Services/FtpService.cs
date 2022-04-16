using System.IO;
using System.Net;

namespace TestingSystem.Services
{
    public class FtpService
    {
        public string IpAddress { get; }
        public string UserName { get; }
        private readonly string password;
        
        public FtpService(string ipAddress, string userName, string password)
        {
            IpAddress = ipAddress;
            UserName = userName;
            this.password = password;
        }

        public Stream GetResponseStream(string path, string method, long dataSize = 0)
        {
            return CreateFtpRequest(path, method, dataSize).GetResponse().GetResponseStream();
        }
        
        private FtpWebRequest CreateFtpRequest(string path, string method, long dataSize = 0)
        {
            path = IpAddress + path;

            FtpWebRequest request = WebRequest.Create(path) as FtpWebRequest;

            request.Credentials = new NetworkCredential(UserName, password);
            request.KeepAlive = false;
            request.UseBinary = true;
            request.Method = method;

            request.ContentLength = dataSize;
            
            return request;
        }
    }
}