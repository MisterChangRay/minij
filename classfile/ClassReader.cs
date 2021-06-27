using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minij.classfile
{
    interface Reader {
        Reader parse(ClassReader classReader, ClassFile cf);
    }

    class ClassReader
    {
        private BinaryReader reader;

        public ClassReader(byte[] tmp2) {
            MemoryStream ms = new MemoryStream(tmp2);
            this.reader = new BinaryReader(ms);
        }

        public byte readUint8() {
            return reader.ReadByte();
        }


        public UInt16 readUInt16()
        {
            return BitConverter.ToUInt16( this.readBytes(2, false), 0);
        }

        public UInt16[] readUInt16s(int len)
        {
            UInt16[] res = new UInt16[len];

            for (int i = 0; i < len; i++)
            {
                res[i] = reader.ReadUInt16();
            }

            return res;
        }

        internal byte[] readBytes(int length, bool raw)
        {
            byte[] res = reader.ReadBytes(length);
            if (!raw) {
                Array.Reverse(res); ;

            }
            return res;
        }

   

        public UInt32 readUInt32()
        {
            return BitConverter.ToUInt32(this.readBytes(4, false), 0);
        }
    }
}
