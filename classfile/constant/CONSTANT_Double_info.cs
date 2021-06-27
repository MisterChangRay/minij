using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
CONSTANT_Double_info {
    u1 tag;
    u4 high_bytes;
    u4 low_bytes;
}
**/
namespace minij.classfile.constant
{
    class CONSTANT_Double_info : Constant
    {
        public UInt32 hightBytes;
        public UInt32 lowBytes;
        public double val;


        public override Reader parse(ClassReader classReader, ClassFile cf)
        {
            this.hightBytes = classReader.readUInt32();
            this.lowBytes = classReader.readUInt32();

            ulong va = Convert.ToUInt64(this.hightBytes) << 32;
            va = va | lowBytes;
            long va2 = Convert.ToInt64(va);

            this.val = BitConverter.Int64BitsToDouble(va2);
            return this;
        }
    }
}
