using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minij.rtda.heap.constantpool
{
    class InterfaceMethodref : ConstantPool
    {
        public Class clazz;
        public string clazzName;
        
        public NameAndType nameAndType;
        public string name;
        public string descriptor;

        public InterfaceMethodref resolveMethodref()
        {
            this.clazz = this.cpClz.thisClazz.loader.load(this.clazzName);
            return this;
        }

        public Class resolveClass()
        {
            this.resolveMethodref();
            return this.clazz;
        }
    }
}
