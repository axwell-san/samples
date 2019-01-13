using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using WCFService;

namespace Application
{
    class Program
    {
        private static Uri uri = new Uri(WCFService.Program.ServiceUri, Routing.UserRoute);

        static void Main(string[] args)
        {
            var process = new Process();

            try
            {
                process.StartInfo.FileName = @"..\..\..\WCFService\bin\Debug\WCFService.exe";
                process.Start();
                GetUser();
                PostUser(new User { Name = "Billie Jean", Age = 33 });
                GetUser();
                Console.ReadKey();
            }
            finally
            {
                try
                {
                    if (!process.HasExited)
                        process.Kill();
                }
                catch { }
            }
        }

        static void GetUser()
        {
            User user;

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
            request.Method = "GET";

            Console.WriteLine($"Do {request.Method} {uri}");

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                DataContractSerializer dcs = new DataContractSerializer(typeof(User));
                user = dcs.ReadObject(response.GetResponseStream()) as User;
            }

            Console.WriteLine($"User's name = {user.Name}, age = {user.Age}");
        }

        static void PostUser(User user)
        {
            Uri uri = new Uri(WCFService.Program.ServiceUri, Routing.UserRoute);

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
            request.Method = "POST";

            Console.WriteLine($"Do {request.Method} {uri} - User's name = {user.Name}, age = {user.Age}");

            var serializer = new XmlSerializer(typeof(User));
            var memoryStream = new MemoryStream();
            var streamWriter = new StreamWriter(memoryStream, System.Text.Encoding.UTF8);
            serializer.Serialize(streamWriter, user);
            byte[] bytes = memoryStream.ToArray();
            request.ContentLength = bytes.Length;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();
            Console.WriteLine(((HttpWebResponse)request.GetResponse()).StatusCode);
        }
    }
}
