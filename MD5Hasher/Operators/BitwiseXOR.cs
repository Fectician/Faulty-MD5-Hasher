namespace MD5Hasher.Operators
{
    public class BitwiseXOR : BitwiseAbstract
    {
        protected override byte OperationHere(byte bytearray1, byte bytearray2)
        {
            return (byte)(bytearray1 ^ bytearray2);
        }
    }
}
