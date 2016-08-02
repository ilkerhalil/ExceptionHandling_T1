using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Proxies;
using ExceptionHandling_T1.Core.ExceptionHandling;
using ExceptionHandling_T1.Core.Interfaces;
using ExceptionHandling_T1.Core.LoggerImpl;

namespace ExceptionHandling_T1
{
    class Program
    {
        static void Main(string[] args)
        {
            var myProxy = new MyProxy(typeof(Bisiklet));
            var bisiklet = myProxy.GetTransparentProxy() as Bisiklet;
            var tResult = bisiklet.Sorgula("bisiklet");


            var urun = new Bisiklet();
            var result = urun.Sorgula("pabuc");
            var resultTranslate = result ? "Var" : "Yok";
            Console.WriteLine($"Urun {resultTranslate}..!");
            Console.ReadLine();
        }


    }
}
