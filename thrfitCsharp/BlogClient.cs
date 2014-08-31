using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thrift.Protocol;
using Thrift.Transport;

namespace thrfitCsharp
{
    class BlogClient
    {



        static Dictionary<String, String> map = new Dictionary<String, String>();
        static List<Blog> blogs = new List<Blog>();

        public void startClient()
        {
            TTransport transport = new TSocket("localhost", 7911);
            TProtocol protocol = new TBinaryProtocol(transport);
            ThriftCase.Client client = new ThriftCase.Client(protocol);
            transport.Open();
            Console.WriteLine("Client calls .....");
            map.Clear();
            map.Add("blog", "http://amosli.cnblogs.com");

            client.testCase1(10, 21, "3");
            client.testCase2(map);
            client.testCase3();

            Blog blog = new Blog();
            //blog.setContent("this is blog content".getBytes()); 
            blog.CreatedTime = DateTime.Now.Ticks;
            blog.Id = "123456";
            blog.IpAddress = "127.0.0.1";
            blog.Topic = "this is blog topic";
            blogs.Add(blog);

            client.testCase4(blogs);

            transport.Close();

            //Console.ReadKey(); 
        }
    }
}
