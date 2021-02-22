using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace Mm
{
    public class Mymethods
    {

        public string param1;
        public string param2;
        public Mymethods(string param1, string param2)
        {
            this.param1 = param1;
            this.param2 = param2;
        }

        public string generateOutput()
        {
            return String.Concat("<HTML><BODY>Hello ", param1, " et ", param2, "</BODY></HTML>");
        }


    }
}