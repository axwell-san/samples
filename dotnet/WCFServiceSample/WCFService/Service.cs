using System;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.Xml.Serialization;

namespace WCFService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service : IService
    {
        private static User User = new User { Name = "no user created yet", Age = 0 };

        public User GetUser()
        {
            LogConsole();
            return User;
        }

        public void PostUser(Stream stream)
        {
            LogConsole();

            try
            {
                var xmlSerializer = new XmlSerializer(typeof(User));
                User = (User)xmlSerializer.Deserialize(stream);
            }
            catch (Exception e)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                WebOperationContext.Current.OutgoingResponse.StatusDescription = e.Message;
            }
        }

        private void LogConsole()
        {
            MessageProperties properties = OperationContext.Current.IncomingMessageProperties;
            RemoteEndpointMessageProperty endpoint = properties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
            HttpRequestMessageProperty requestMessage = properties[HttpRequestMessageProperty.Name] as HttpRequestMessageProperty;

            Console.WriteLine($"{requestMessage.Method} {properties.Via.OriginalString} from {endpoint.Address} port {endpoint.Port}");
        }
    }
}
