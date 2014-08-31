using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thrfitCsharp
{
    class HelloWroldImpl : HelloWorldService.Iface
    {

        public  string sayHello(string username){
            Console.WriteLine("hello"+username);
            return "hello" + username;
        }

    }
}
