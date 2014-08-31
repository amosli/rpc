using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thrift.Server;
using Thrift.Transport;

namespace thrfitCsharp
{
    class BlogServer
    {
        public void StartServer()
        {
            try
            {
                TServerSocket serverTransport = new TServerSocket(7911, 0, false);
                ThriftCase.Processor processor = new ThriftCase.Processor(new BusinessImpl());
                TServer server = new TSimpleServer(processor, serverTransport);
                Console.WriteLine("Starting server on port 7911 ...");
                server.Serve();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
