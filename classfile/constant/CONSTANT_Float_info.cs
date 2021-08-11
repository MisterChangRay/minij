using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
CONSTANT_Float_info {
    u1 tag;
    u4 bytes;
}
**/
namespace minij.classfile.constant
{
    class CONSTANT_Float_info : Constant
    {
        public uint bytes;
        public float val;


        public override Reader parse(ClassReader classReader, ClassFile cf)
        {
            this.bytes = classReader.readUInt32();

            ulong va = (ulong)(this.bytes) << 32;
            long val2 = unchecked((long)va);
            this.val = BitConverter.DoubleToInt64Bits(val2);
            return this;
        }
    }
}
