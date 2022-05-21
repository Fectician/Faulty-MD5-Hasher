using System;
using System.Numerics;

namespace MD5Hasher.Operators
{
    public class BitwiseLeftRotate
    {
        public byte[] DoOperation(byte[] bytearray, int rotateamount)
        {
            int length = bytearray.Length;
            if (length == 0) { return null; }
            byte[] bytarray = new byte[length];
            bytearray.CopyTo(bytarray, 0);

            Array.Reverse(bytarray);
            uint bitsandbytes = BitConverter.ToUInt32(bytarray, 0);

            bitsandbytes = BitOperations.RotateLeft(bitsandbytes, rotateamount);

            byte[] arrayresult = BitConverter.GetBytes(bitsandbytes);
            Array.Reverse(arrayresult);

            return arrayresult;
        }
    }
}
