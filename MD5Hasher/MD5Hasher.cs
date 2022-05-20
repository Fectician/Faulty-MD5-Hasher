using MD5Hasher.Operators;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MD5Hasher
{
    public class MD5Hasher
    {
        BitwiseAnd bitand = new BitwiseAnd();
        BitwiseOr bitor = new BitwiseOr();
        BitwiseXOR bitxor = new BitwiseXOR();
        BitwiseLeftRotate bitrotate = new BitwiseLeftRotate();
        BitwiseNot bitnot = new BitwiseNot();
        byte[] A, B, C, D, OIVA, OIVB, OIVC, OIVD;
        static List<byte[]> KList;
        static int[] Sarray;
        public MD5Hasher() 
        {
            KListInitializer();
            SarrayInitializer();
        }
        private void SarrayInitializer() 
        {
            if (Sarray != null) 
            {
                return;
            }
            Sarray = new int[64];
            for (int i = 0; i <= 12; i += 4)
            {
                Sarray[i] = 7;
                Sarray[i + 1] = 12;
                Sarray[i + 2] = 17;
                Sarray[i + 3] = 22;

                Sarray[i + 16] = 5;
                Sarray[i + 17] = 9;
                Sarray[i + 18] = 14;
                Sarray[i + 19] = 20;

                Sarray[i + 32] = 4;
                Sarray[i + 33] = 11;
                Sarray[i + 34] = 16;
                Sarray[i + 35] = 23;

                Sarray[i + 48] = 6;
                Sarray[i + 49] = 10;
                Sarray[i + 50] = 15;
                Sarray[i + 51] = 21;
            }
        }
        private void KListInitializer() 
        {
            if (KList != null) 
            {
                return;
            }
            KList = new List<byte[]>()
            {
                new byte[] { 0xd7, 0x6a, 0xa4, 0x78 },
                new byte[] { 0xe8, 0xc7, 0xb7, 0x56 },
                new byte[] { 0x24, 0x20, 0x70, 0xdb },
                new byte[] { 0xc1, 0xbd, 0xce, 0xee },
                new byte[] { 0xf5, 0x7c, 0x00, 0xfa },
                new byte[] { 0x47, 0x87, 0xc6, 0x2a },
                new byte[] { 0xa8, 0x30, 0x46, 0x13 },
                new byte[] { 0xfd, 0x46, 0x95, 0x01 },
                new byte[] { 0x69, 0x80, 0x98, 0xd8 },
                new byte[] { 0x8b, 0x44, 0xf7, 0xaf },
                new byte[] { 0xff, 0xff, 0x5b, 0xb1 },
                new byte[] { 0x89, 0x5c, 0xd7, 0xbe },
                new byte[] { 0x6b, 0x90, 0x11, 0x22 },
                new byte[] { 0xfd, 0x98, 0x71, 0x93 },
                new byte[] { 0xa6, 0x79, 0x43, 0x8e },
                new byte[] { 0x49, 0xb4, 0x08, 0x21 },
                new byte[] { 0xf6, 0x1e, 0x25, 0x62 },
                new byte[] { 0xc0, 0x40, 0xb3, 0x40 },
                new byte[] { 0x26, 0x5e, 0x5a, 0x51 },
                new byte[] { 0xe9, 0xb6, 0xc7, 0xaa },
                new byte[] { 0xd6, 0x2f, 0x10, 0x5d },
                new byte[] { 0x02, 0x44, 0x14, 0x53 },
                new byte[] { 0xd8, 0xa1, 0xe6, 0x81 },
                new byte[] { 0xe7, 0xd3, 0xfb, 0xc8 },
                new byte[] { 0x21, 0xe1, 0xcd, 0xe6 },
                new byte[] { 0xc3, 0x37, 0x07, 0xd6 },
                new byte[] { 0xf4, 0xd5, 0x0d, 0x87 },
                new byte[] { 0x45, 0x5a, 0x14, 0xed },
                new byte[] { 0xa9, 0xe3, 0xe9, 0x05 },
                new byte[] { 0xfc, 0xef, 0xa3, 0xf8 },
                new byte[] { 0x67, 0x6f, 0x02, 0xd9 },
                new byte[] { 0x8d, 0x2a, 0x4c, 0x8a },
                new byte[] { 0xff, 0xfa, 0x39, 0x42 },
                new byte[] { 0x87, 0x71, 0xf6, 0x81 },
                new byte[] { 0x69, 0x9d, 0x61, 0x22 },
                new byte[] { 0xfd, 0xe5, 0x38, 0x0c },
                new byte[] { 0xa4, 0xbe, 0xea, 0x44 },
                new byte[] { 0x4b, 0xde, 0xcf, 0xa9 },
                new byte[] { 0xf6, 0xbb, 0x4b, 0x60 },
                new byte[] { 0xbe, 0xbf, 0xbc, 0x70 },
                new byte[] { 0x28, 0x9b, 0x7e, 0xc6 },
                new byte[] { 0xea, 0xa1, 0x27, 0xfa },
                new byte[] { 0xd4, 0xef, 0x30, 0x85 },
                new byte[] { 0x04, 0x88, 0x1d, 0x05 },
                new byte[] { 0xd9, 0xd4, 0xd0, 0x39 },
                new byte[] { 0xe6, 0xdb, 0x99, 0xe5 },
                new byte[] { 0x1f, 0xa2, 0x7c, 0xf8 },
                new byte[] { 0xc4, 0xac, 0x56, 0x65 },
                new byte[] { 0xf4, 0x29, 0x22, 0x44 },
                new byte[] { 0x43, 0x2a, 0xff, 0x97 },
                new byte[] { 0xab, 0x94, 0x23, 0xa7 },
                new byte[] { 0xfc, 0x93, 0xa0, 0x39 },
                new byte[] { 0x65, 0x5b, 0x59, 0xc3 },
                new byte[] { 0x8f, 0x0c, 0xcc, 0x92 },
                new byte[] { 0xff, 0xef, 0xf4, 0x7d },
                new byte[] { 0x85, 0x84, 0x5d, 0xd1 },
                new byte[] { 0x6f, 0xa8, 0x7e, 0x4f },
                new byte[] { 0xfe, 0x2c, 0xe6, 0xe0 },
                new byte[] { 0xa3, 0x01, 0x43, 0x14 },
                new byte[] { 0x4e, 0x08, 0x11, 0xa1 },
                new byte[] { 0xf7, 0x53, 0x7e, 0x82 },
                new byte[] { 0xbd, 0x3a, 0xf2, 0x35 },
                new byte[] { 0x2a, 0xd7, 0xd2, 0xbb },
                new byte[] { 0xeb, 0x86, 0xd3, 0x91 }
            };
        }
        public string DoFullHashWithStringUTF8(string input) 
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            return DoFullHashWithByteArray(bytes);
        }
        public string DoFullHashWithByteArray(byte[] bytes) 
        {
            long bitlength = bytes.Length * 8;
            bytes = bytearrayresizer(bytes, 1);
            bitsetter(bytes, bytes.Length * 8, true);

            int buffer = 0;
            int moddedbit = ((int)bitlength + 8) % 512;

            if (moddedbit > 448) { buffer = 512; }

            int DECIDER = ((448 + buffer) - moddedbit) / 8;
            if (DECIDER > 0)
            { bytes = bytearrayresizer(bytes, DECIDER); }

            byte[] bytese = BitConverter.GetBytes(bitlength);
            Array.Reverse(bytese);
            bytes = bytes.Concat(bytese).ToArray();

            List<byte[]> bytelist = new List<byte[]>();
            for (int i = 0; i < bytes.Length; i += 4)
            {
                byte[] newb = new byte[4];
                Array.Copy(bytes, i, newb, 0, 4);
                bytelist.Add(newb);
            }

            return DoFullHash(bytelist);
        }
        private string DoFullHash(List<byte[]> input)
        {
            byte[] A = new byte[] { 0x01, 0x23, 0x45, 0x67 };
            byte[] B = new byte[] { 0x89, 0xAB, 0xCD, 0xEF };
            byte[] C = new byte[] { 0xfe, 0xdc, 0xba, 0x98 };
            byte[] D = new byte[] { 0x76, 0x54, 0x32, 0x10 };


            OIVA = new byte[A.Length];
            OIVB = new byte[B.Length];
            OIVC = new byte[C.Length];
            OIVD = new byte[D.Length];

            OIVA = A;
            OIVB = B;
            OIVC = C;
            OIVD = D;
            for (int j = 0; j < input.Count; j += 16)
            {
                OIVA = A;
                OIVB = B;
                OIVC = C;
                OIVD = D;
                List<byte[]> firstround = new List<byte[]>();
                List<byte[]> secondround = new List<byte[]>();
                List<byte[]> thirdround = new List<byte[]>();
                List<byte[]> fourthround = new List<byte[]>();

                for (int i = 0; i < 16; i++)
                {
                    firstround.Add(input[i + j]);
                    secondround.Add(input[((i * 5 + 1) % (16)) + j]);
                    thirdround.Add(input[((i * 3 + 5) % (16)) + j]);
                    fourthround.Add(input[((i * 7) % (16)) + j]);
                }

                byte[] RoundResult = new byte[8];
                for (int i = 0; i < 16; i++)
                {
                    byte[] FFunc = bitor.DoOperation(bitand.DoOperation(B, C), bitand.DoOperation(bitnot.DoOperation(B), D));
                    RoundResult = SingleRound(A, B, C, D, firstround[i % 16], KList[i], Sarray[i], FFunc);
                    A = D;
                    D = C;
                    C = B;
                    B = RoundResult;
                }

                for (int i = 16; i < 32; i++)
                {
                    byte[] GFunc = bitor.DoOperation(bitand.DoOperation(B, D), bitand.DoOperation(C, bitnot.DoOperation(D)));
                    RoundResult = SingleRound(A, B, C, D, secondround[i % 16], KList[i], Sarray[i], GFunc);
                    A = D;
                    D = C;
                    C = B;
                    B = RoundResult;
                }

                for (int i = 32; i < 48; i++)
                {
                    byte[] HFunc = bitxor.DoOperation(bitxor.DoOperation(B, C), D);
                    RoundResult = SingleRound(A, B, C, D, thirdround[i % 16], KList[i], Sarray[i], HFunc);
                    A = D;
                    D = C;
                    C = B;
                    B = RoundResult;
                }

                for (int i = 48; i < 64; i++)
                {
                    byte[] IFunc = bitxor.DoOperation(C, bitor.DoOperation(B, bitnot.DoOperation(D)));
                    RoundResult = SingleRound(A, B, C, D, fourthround[i % 16], KList[i], Sarray[i], IFunc);
                    A = D;
                    D = C;
                    C = B;
                    B = RoundResult;
                }
                A = PackAndMod(A, OIVA);
                B = PackAndMod(B, OIVB);
                C = PackAndMod(C, OIVC);
                D = PackAndMod(D, OIVD);
            }


            string a = BitConverter.ToString(A).Replace("-", "");
            string b = BitConverter.ToString(B).Replace("-", "");
            string c = BitConverter.ToString(C).Replace("-", "");
            string d = BitConverter.ToString(D).Replace("-", "");
            string FinalResult = a + b + c + d;


            return FinalResult.ToLower();
        }
        private byte[] SingleRound(byte[] A, byte[] B, byte[] C, byte[] D, byte[] M, byte[] K, int S, byte[] Func)
        {
            //return PackAndMod(B, bitrotate.DoOperation(PackAndMod(K, PackAndMod(M, PackAndMod(A, Func))), S));
            byte[] Round1Result = PackAndMod(A, Func);
            byte[] Round1point5Result = PackAndMod(M, Round1Result);
            byte[] Round1point6Result = PackAndMod(K, Round1point5Result);
            Round1point6Result = bitrotate.DoOperation(Round1point6Result, S);
            byte[] Round1point7Result = PackAndMod(B, Round1point6Result);

            return Round1point7Result;
        }
        private void bitsetter(byte[] bytearray, int whichbit, bool bitstate)
        {

            BitArray bitArray = new BitArray(bytearray);

            bitArray.Set(whichbit - 8, bitstate);

            bitArray.CopyTo(bytearray, 0);
        }

        uint Pack(uint x, uint y, uint z, uint w)
        {
            uint newx = x, newy = y, newz = z, neww = w;
            uint pos2 = (neww << 24) | (newz << 16) | (newy << 8) | newx;
            return pos2;
        }

        private byte[] bytearrayresizer(byte[] bytearray, int bytesadded)
        {
            Array.Resize<byte>(ref bytearray, bytearray.Length + bytesadded);
            return bytearray;
        }
        private byte[] PackAndMod(byte[] bytearray1, byte[] bytearray2)
        {
            long ModNumber = 4294967296;

            uint packedInt = Pack(bytearray1[3], bytearray1[2], bytearray1[1], bytearray1[0]);
            uint packedInt2 = Pack(bytearray2[3], bytearray2[2], bytearray2[1], bytearray2[0]);
            long resultlong = (packedInt + packedInt2) % ModNumber;
            byte[] resultByteA = BitConverter.GetBytes(Convert.ToUInt32(resultlong));
            Array.Reverse(resultByteA);
            return resultByteA;
        }
    }
}
