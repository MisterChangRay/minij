using minij.classfile;
using minij.classfile.attributes;
using minij.classfile.constant;
using minij.rtda.heap.constantpool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minij.rtda.heap
{
    public class ClassRef : ConstantPool
    {
        public string name;

        public Class resloveClass()
        {
            return this.cpClz.loader.load(this.name);
        }
    }





}
