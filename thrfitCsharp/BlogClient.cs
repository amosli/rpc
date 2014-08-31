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
            try
            {

                TProtocol protocol = new TBinaryProtocol(transport);
                ThriftCase.Client client = new ThriftCase.Client(protocol);
                transport.Open();
                Console.WriteLine("csharp client open .....");
                if (map != null)
                {
                    map.Clear();
                }
                map.Add("url", "http://amosli.cnblogs.com");
                map.Add("username", "amosli");

                //case1
                client.testCase1(10, 21, "3");

                //case2
                client.testCase2(map);

                //case3            
                client.testCase3();

                Blog blog = new Blog();
                blog.Content = Encoding.UTF8.GetBytes("this is blog content");
                blog.CreatedTime = DateTime.Now.Ticks;
                blog.Id = "543322";
                blog.IpAddress = "127.0.0.1";
                blog.Topic = "this is blog topic";
                blogs.Add(blog);
                //case4
                client.testCase4(blogs);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (transport != null)
                    transport.Close();//close
            }

        }
    }
}
