using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketTest
{
    public class Program
    {
        public void Main(string[] args)
        {
            // Make a simple HTTP request
            var url = new Uri(args[0]);

            var socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(url.Host, url.Port);

            using (var stream = GetStream(socket, url))
            {
                // Send the request
                var request = $"GET {url.PathAndQuery} HTTP/1.1\r\nHost: {url.Host}\r\nConnection: close\r\n\r\n";
                var buffer = Encoding.UTF8.GetBytes(request);
                stream.Write(buffer, 0, buffer.Length);

                // Read the response
		byte[] readbuffer = new byte[1024];
		int read = 0;
	        Console.WriteLine("Response:");
		while((read = stream.Read(readbuffer, 0, buffer.Length)) != 0) {
			var converted = Encoding.UTF8.GetString(readbuffer, 0, read);
			Console.Write(converted);
		}
            }
        }

        private static Stream GetStream(Socket socket, Uri uri)
        {
            var stream = new NetworkStream(socket);
            if(uri.Scheme.Equals("https"))
            {
                var ssl = new SslStream(stream);
                ssl.AuthenticateAsClient(uri.Host);
                return ssl;
            }
            return stream;
        }
    }
}
