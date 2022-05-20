namespace MD5Hasher.Operators
{
    public abstract class BitwiseAbstract
    {
        public byte[] DoOperation(byte[] bytearray1, byte[] bytearray2)
        {
            int length = bytearray1.Length;
            if (length != bytearray2.Length) { return null; }
            byte[] result = new byte[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = (byte)(OperationHere(bytearray1[i], bytearray2[i]));
            }
            return result;
        }
        protected abstract byte OperationHere(byte bytearray1, byte byrtearray2);
    }
}
