using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minij.classfile.attributes
{
    abstract class Attribute : Reader
    {
        public UInt16 attribute_name_index;
        public UInt32 attribute_length;

        public abstract Reader parse(ClassReader classReader, ClassFile cf);
    }
}
