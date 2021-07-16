using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
CONSTANT_Long_info {
    u1 tag;
    u4 high_bytes;
    u4 low_bytes;
}
**/
namespace minij.classfile.constant
{
    class CONSTANT_Long_info : Constant
    {
        public UInt32 hightBytes;
        public UInt32 lowBytes;
        public long val;

        public override Reader parse(ClassReader classReader, ClassFile cf)
        {
 
            this.hightBytes = classReader.readUInt32();
            this.lowBytes = classReader.readUInt32();

            ulong va =((ulong)this.hightBytes) << 32;
            va = va | lowBytes;
            this.val = unchecked((long)va);

            return this;
        }
    }
}
