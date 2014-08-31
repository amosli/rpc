using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thrift.Protocol;
using Thrift.Transport;
using Thrift;

namespace thrfitCsharp
{
    class HelloWorldServiceClient
    {
        public const string SERVERIP = "localhost";
        public static int SERVERPORT = 8090;
        public static int TIMEOUT = 3000;

        public void startClient(String username)
        {
            TTransport transport = null;
            try
            {
                transport = new TSocket(SERVERIP, SERVERPORT, TIMEOUT);
                //协议要和服务端一致
                TProtocol protocol = new TCompactProtocol(transport);
                HelloWorldService.Client client = new HelloWorldService.Client(protocol);
                transport.Open();
                String result = client.sayHello(username);
                Console.WriteLine("Thrift client result =: " + result);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                if (null != transport)
                {
                    //close
                    transport.Close();
                }
            }
        }


    }
}
