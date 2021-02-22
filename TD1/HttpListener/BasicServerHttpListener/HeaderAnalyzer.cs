using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BasicServerHTTPlistener;

namespace ConsoleApp3
{
    public class HeaderAnalyzer
    {
        public HttpListenerContext context;
        public HttpListenerRequest request;

        public HeaderAnalyzer(HttpListenerContext cnt)
        {
            context = cnt;
            request = cnt.Request;
        }
        public void printMime()
        {
            // Display the MIME types that can be used in the response.
            string[] types = request.AcceptTypes;
            if (types != null)
            {
                Console.WriteLine("Acceptable MIME types:");
                foreach (string s in types)
                {
                    Console.WriteLine(s);
                }
            }
            // Display the language preferences for the response.
            types = request.UserLanguages;
            if (types != null)
            {
                Console.WriteLine("Acceptable natural languages:");
                foreach (string l in types)
                {
                    Console.WriteLine(l);
                }
            }

            // Display the URL used by the client.
            Console.WriteLine("URL: {0}", request.Url.OriginalString);
            Console.WriteLine("Raw URL: {0}", request.RawUrl);
            Console.WriteLine("Query: {0}", request.QueryString);

            // Display the referring URI.
            Console.WriteLine("Referred by: {0}", request.UrlReferrer);

            //Display the HTTP method.
            Console.WriteLine("HTTP Method: {0}", request.HttpMethod);
            //Display the host information specified by the client;
            Console.WriteLine("Host name: {0}", request.UserHostName);
            Console.WriteLine("Host address: {0}", request.UserHostAddress);
            Console.WriteLine("User agent: {0}", request.UserAgent);
        }

        public void printEncoding()
        {
            if (!request.HasEntityBody)
            {
                Console.WriteLine("No client data was sent with the request.");
                return;
            }
            System.IO.Stream body = request.InputStream;
            System.Text.Encoding encoding = request.ContentEncoding;
            System.IO.StreamReader reader = new System.IO.StreamReader(body, encoding);
            if (request.ContentType != null)
            {
                Console.WriteLine("Client data content type {0}", request.ContentType);
            }
            Console.WriteLine("Client data content length {0}", request.ContentLength64);

            Console.WriteLine("Start of client data:");
            // Convert the data to a string and display it on the console.
            string s = reader.ReadToEnd();
            Console.WriteLine(s);
            Console.WriteLine("End of client data:");
            body.Close();
            reader.Close();
            // If you are finished with the request, it should be closed also.
        }

        public void printCookies()
        {
            // Print the properties of each cookie.
            foreach (Cookie cook in request.Cookies)
            {
                Console.WriteLine("Cookie:");
                Console.WriteLine("{0} = {1}", cook.Name, cook.Value);
                Console.WriteLine("Domain: {0}", cook.Domain);
                Console.WriteLine("Path: {0}", cook.Path);
                Console.WriteLine("Port: {0}", cook.Port);
                Console.WriteLine("Secure: {0}", cook.Secure);

                Console.WriteLine("When issued: {0}", cook.TimeStamp);
                Console.WriteLine("Expires: {0} (expired? {1})",
                    cook.Expires, cook.Expired);
                Console.WriteLine("Don't save: {0}", cook.Discard);
                Console.WriteLine("Comment: {0}", cook.Comment);
                Console.WriteLine("Uri for comments: {0}", cook.CommentUri);
                Console.WriteLine("Version: RFC {0}", cook.Version == 1 ? "2109" : "2965");

                // Show the string representation of the cookie.
                Console.WriteLine("String: {0}", cook.ToString());
            }
        }
        public void printHttp()
        {
            Console.WriteLine("KeepAlive: {0}", request.KeepAlive);
            Console.WriteLine("Local end point: {0}", request.LocalEndPoint.ToString());
            Console.WriteLine("Remote end point: {0}", request.RemoteEndPoint.ToString());
            Console.WriteLine("Is local? {0}", request.IsLocal);
            Console.WriteLine("HTTP method: {0}", request.HttpMethod);
            Console.WriteLine("Protocol version: {0}", request.ProtocolVersion);
            Console.WriteLine("Is authenticated: {0}", request.IsAuthenticated);
            Console.WriteLine("Is secure: {0}", request.IsSecureConnection);
        }

    }
}
