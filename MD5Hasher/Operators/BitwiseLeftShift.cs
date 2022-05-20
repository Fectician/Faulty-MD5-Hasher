using System;
using System.Numerics;

namespace MD5Hasher.Operators
{
    public class BitwiseLeftRotate
    {
        public byte[] DoOperation(byte[] bytearray, int rotateamount)
        {
            if (bytearray.Length == 0) { return null; }

            Array.Reverse(bytearray);
            uint bitsandbytes = BitConverter.ToUInt32(bytearray, 0);

            bitsandbytes = BitOperations.RotateLeft(bitsandbytes, rotateamount);

            byte[] arrayresult = BitConverter.GetBytes(bitsandbytes);
            Array.Reverse(arrayresult);

            return arrayresult;
        }
    }
}
