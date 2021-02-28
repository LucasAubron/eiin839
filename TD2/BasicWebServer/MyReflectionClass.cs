using System;
using System.Reflection;
using System.Diagnostics;
using System.IO;

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

        public string ExecCreation()
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = @"C:\Users\laubr\OneDrive\Bureau\SI4_S8\SOC\TDs\eiin839\TD2\ExecCreation\bin\Debug\netcoreapp3.1\ExecCreation.exe"; // Specify exe name.
            start.Arguments = String.Concat(this.param1, " ", this.param2); // Specify arguments.
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            //
            // Start the process.
            //
            string result;
            using (Process process = Process.Start(start))
            {
                //
                // Read in all the text from the process with the StreamReader.
                //
                using (StreamReader reader = process.StandardOutput)
                {
                    result = reader.ReadToEnd();
                    Console.WriteLine(result);
                    Console.ReadLine();
                }
            }
            return result;
        }

        public string incr()
        {
            string filepath = @"C:\Users\laubr\OneDrive\Bureau\SI4_S8\SOC\TDs\eiin839\TD2\BasicWebServer\incr.txt";
            string result;
            StreamReader sr = new StreamReader(filepath);
            string current = sr.ReadLine();
            sr.Close();
            result = (int.Parse(current) + int.Parse(param1)).ToString();
            StreamWriter sw = new StreamWriter(filepath);
            sw.WriteLine(result);
            sw.Close();
            return String.Concat("200 OK\nincr=",result);
        }
    }

}

