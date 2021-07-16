using minij.classfile;
using minij.rtda.heap.constantpool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minij.rtda.heap
{
    class Method : ConstantPool
    {
        public AccessFlags accessFlags;
        public string name;
        public string descriptor;
        public NameAndType nameAndType;
        public List<minij.classfile.attributes.Attribute> attrs;
        public Class clazz;
        public Method method;


        public minij.classfile.attributes.Attribute getAttribute(string name) {
            foreach(var attr in attrs)
            {
                if(attr.name == name)
                {
                    return attr;
                }
            }
            return null;

        }

    }
}
