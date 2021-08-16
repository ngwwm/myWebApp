using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using myWebApp.Interface;

namespace myWebApp
{
    public class Dependency: IDependency
    {
        public void SayHello()
        {
            Console.WriteLine("Hi");
        }
           
    }
}