using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
CONSTANT_Integer_info {
    u1 tag;
    u4 bytes;
}
**/
namespace minij.classfile.constant
{
    class CONSTANT_Integer_info : Constant
    {
        public UInt32 bytes;
        public int val;

        public override Reader parse(ClassReader classReader, ClassFile cf)
        {
            this.bytes = classReader.readUInt32();
            this.val = Convert.ToInt32(this.bytes);
            return this;
        }
    }
}
