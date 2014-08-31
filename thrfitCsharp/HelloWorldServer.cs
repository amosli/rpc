using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thrift.Server;
using Thrift.Transport;

namespace thrfitCsharp
{


    class HelloWorldServer
    {
        public const int SERVERPORT = 8090;

        public void startServer()
        {
            try
            {
                Console.WriteLine(" CSharp server is start...");
                HelloWorldService.Processor processor = new HelloWorldService.Processor(new HelloWroldImpl());
                TServerSocket serverTransport = new TServerSocket(SERVERPORT);
                TServer server = new TSimpleServer(processor, serverTransport);
                Console.WriteLine("CSharp server ,启动成功！");
                server.Serve();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }





    }
}
