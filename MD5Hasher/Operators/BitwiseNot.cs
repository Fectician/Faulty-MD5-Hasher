using System;
using System.Collections;

namespace MD5Hasher.Operators
{
    public class BitwiseNot
    {
        public byte[] DoOperation(byte[] bytearray) 
        {
            int length = bytearray.Length;
            if (length == 0) { return null; }
            byte[] bytarray = new byte[length];
            bytearray.CopyTo(bytarray, 0);
            Array.Reverse(bytarray);

            BitArray bitArray = new BitArray(bytarray);
            
            BitArray bitArray2 = new BitArray(bitArray);
            bitArray.Not();
            
            for (int i = bitArray2.Length-1; i > 0; i--) 
            {
                if (bitArray2.Get(i) == true) 
                {
                    break;
                }
                bitArray.Set(i, false);
            }
            
            bitArray.CopyTo(bytarray, 0);
            Array.Reverse(bytarray);
            return bytarray;
        }
    }
}
