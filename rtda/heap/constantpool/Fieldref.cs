using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minij.rtda.heap.constantpool
{
    class Fieldref : ConstantPool
    {
        public Class clazz;
        public string clazzName;

        public Field field;
        public NameAndType nameAndType;
        public string name;
        public string descriptor;


        public Class resloveClass()
        {

            this.clazz = this.cpClz.loader.load(this.clazzName);
            return this.clazz;
        }

        public Field resloveFieldref() {
            this.resloveClass();

            this.field = this.clazz.findField(this.name, this.descriptor);
            this.field.clazz = this.clazz;
            return this.field;
        }

    }
}
