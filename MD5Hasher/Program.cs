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
            Console.WriteLine(hasher.DoFullHashWithStringUTF8("A"));
            Console.WriteLine(hasher.DoFullHashWithByteArray(new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D }));
        }
    }
}
