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
        public UInt32 bytes;
        public float val;


        public override Reader parse(ClassReader classReader, ClassFile cf)
        {
            this.bytes = classReader.readUInt32();

            ulong va = Convert.ToUInt64(this.bytes) << 32;
            long val2 = Convert.ToInt64(va);
            this.val = BitConverter.DoubleToInt64Bits(val2);
            return this;
        }
    }
}
