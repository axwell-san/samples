using System;
using System.ServiceModel.Web;

namespace WCFService
{
    public class Program
    {
        public static Uri ServiceUri = new Uri("http://localhost:8000");

        static void Main(string[] args)
        {
            Service myService = new Service();
            WebServiceHost myServiceHost = new WebServiceHost(myService, ServiceUri);
            myServiceHost.Open();
            Console.WriteLine("Service is running...");
            Console.ReadKey();
            myServiceHost.Close();
        }
    }
}
