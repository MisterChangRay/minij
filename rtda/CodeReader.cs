using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minij.classfile
{

    public class CodeReader
    {
        private BinaryReader reader;

        public CodeReader(byte[] tmp2) {
            MemoryStream ms = new MemoryStream(tmp2);
            this.reader = new BinaryReader(ms);
        }

        public byte read() {
            return reader.ReadByte();
        }

        public int readUint16()
        {
            byte[] res = readBytes(2, true);
            return BitConverter.ToUInt16(res, 0);
        }


        public int readUint32()
        {
            byte[] res = readBytes(4, true);
            return BitConverter.ToUInt16(res, 0);
        }

        public byte[] readBytes(int i, bool reverse)
        {
            var c = reader.ReadBytes(i); 
            if (reverse) {
                Array.Reverse(c);
            }

            return c;
        }

        public int pc() {
            return (int) reader.BaseStream.Position;
        }

        public   void  reset(int i)
        {
            reader.BaseStream.Position = i;
        }

    }
}
