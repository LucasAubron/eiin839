using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace MRC
{
    public class MyReflectionClass
    {
        Type type = typeof(MyReflectionClass);
        string[] parameters;
        string param1;
        string param2;
        string param3;


        public string callRightMethod(string m, string[] parameters)
        {
            string result = "400 BAD REQUEST\nNo adapted answer";
            MethodInfo method = this.type.GetMethod(m);
            this.parameters = parameters;
            this.param1 = this.parameters[0];
            this.param2 = this.parameters[1];
            this.param3 = this.parameters[2];
            if (method != null)
            {
               result = (string)method.Invoke(this, null);
            } 

            return result;


        }
        public string MyMethod()
        {
            Console.WriteLine("Call MyMethod 1");
            return String.Concat("200 OK\n<HTML><BODY>Hello ", this.param1, " et ", this.param2, "</BODY></HTML>");
        }

        public string MyMethod2()
        {
            Console.WriteLine("Call MyMethod 2");
            return "200 OK\nThis method is useless !";
        }
    }
}
