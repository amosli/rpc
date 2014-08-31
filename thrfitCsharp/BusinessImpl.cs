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
            Console.WriteLine("num1:" + num1 + " num2:" + num2 + " num3:" + num3);
            Console.WriteLine("testCase1  num1+num2 is :" + i);
            return i;
        }

        public List<String> testCase2(Dictionary<String, String> num1)
        {
            Console.WriteLine("testCase2 ...");
            List<String> list = new List<String>();
            foreach (var item in num1)
            {
                 list.Add(item.Key+" : "+item.Value);
                 Console.WriteLine(item.Key + " : " + item.Value);
             }
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
                Console.WriteLine("id:" + blog.Id);
                Console.WriteLine("IpAddress:" + blog.IpAddress);
                Console.WriteLine("Content:" + System.Text.Encoding.UTF8.GetString(blog.Content));
                Console.WriteLine("topic:" + blog.Topic);
                Console.WriteLine("time:" + blog.CreatedTime);
            }
            Console.WriteLine("\n");
        }
    }
}
