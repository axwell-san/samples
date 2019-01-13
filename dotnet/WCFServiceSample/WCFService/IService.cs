using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WCFService
{
    [ServiceContract]
    public interface IService
    {
        [WebGet(UriTemplate = Routing.UserRoute)]
        [OperationContract]
        User GetUser();


        [WebInvoke(Method = "POST", UriTemplate = Routing.UserRoute)]
        [OperationContract]
        void PostUser(Stream data);
    }
}
