using System;

namespace ExecCreation
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            Console.WriteLine(String.Concat("200 OK\n<HTML><BODY>Hello ", args[0], " et ", args[1], "</BODY></HTML>"));
        }
    }
}
