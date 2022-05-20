using MD5Hasher.Operators;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MD5Hasher
{
    class Program
    {
        
        static void Main(string[] args)
        {
            MD5Hasher hasher = new MD5Hasher();
            string Result = hasher.DoFullHashWithStringUTF8("");
            Console.WriteLine(Result);
        }
        
    }
}
