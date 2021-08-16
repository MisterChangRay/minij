using minij.rtda.heap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
CONSTANT_Utf8_info {
    u1 tag;
    u2 length;
    u1 bytes[length];
}
**/
namespace minij.classfile.constant
{
    class CONSTANT_Utf8_info : Constant
    {
        public UInt16 length;
        public byte[] bytes;
        public string str;

        public override Reader parse(ClassReader classReader, ClassFile cf)
        {

            this.length = classReader.readUInt16();
            this.bytes = classReader.readBytes(this.length, true);
            Encoding encodingUTF8 = new UTF8Encoding(true);

            this.str = UnicodeEncoding.UTF8.GetString(this.bytes);

            return this;
        }
    }
}
