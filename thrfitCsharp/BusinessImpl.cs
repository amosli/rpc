using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thrfitCsharp
{
    public class BusinessImpl : ThriftCase.Iface
    {
        public int testCase1(int num1, int num2, String num3)
        {
            int i = num1 + num2;
            Console.Write("testCase1  num1+num2 is :" + i);
            Console.WriteLine("   num3 is :" + num3);
            return i;
        }

        public List<String> testCase2(Dictionary<String, String> num1)
        {
            Console.WriteLine("testCase2 num1 :" + num1);
            List<String> list = new List<String>();
            list.Add("num1");
            return list;
        }

        public void testCase3()
        {
            Console.WriteLine("testCase3 ..........." + DateTime.Now);
        }

        public void testCase4(List<Blog> blogs)
        {
            Console.WriteLine("testCase4 ...........");

            for (int i = 0; i < blogs.Count; i++)
            {
                Blog blog = blogs[i];
                Console.Write("id:" + blog.Id);
                Console.Write(",IpAddress:" + blog.IpAddress);
                //Console.Write (",Content:" + new String(blog.Content)); 
                Console.Write(",topic:" + blog.Topic);
                Console.Write(",time:" + blog.CreatedTime);
            }
            Console.WriteLine("\n");
        }
    }
}
