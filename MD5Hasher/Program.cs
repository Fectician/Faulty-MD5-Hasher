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
            Console.WriteLine(hasher.DoFullHashWithStringUTF8(""));
            Console.WriteLine(hasher.DoFullHashWithByteArray(new byte[] { 0x61 }));
        }
    }
}
