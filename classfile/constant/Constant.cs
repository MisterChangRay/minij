using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minij.classfile.constant
{
    abstract class Constant : Reader
    {
        public byte tag;

        public abstract Reader parse(ClassReader classReader, ClassFile cf);
    }
}
