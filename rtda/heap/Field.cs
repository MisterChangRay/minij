using minij.classfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minij.rtda.heap
{
    public class Field
    {
        public int slotId;
        public AccessFlags accessFlags;

        public string name;
        public UInt16 name_index;

        public string descriptor;
        public UInt16 descriptor_index;
        public UInt16 attributes_count;
        public List<minij.classfile.attributes.Attribute> attrs;
        public Class clazz;




        public bool isDoubleOrLong() {
            return this.descriptor == "D" || this.descriptor == "J";
        }

        public minij.classfile.attributes.Attribute getAttr(string v)
        {
            minij.classfile.attributes.Attribute res = null;
            this.attrs.ForEach(item =>
            {
                if (item == null) return;
                if (res == null && item.name == v)
                {
                    res = item;
                }
            });
            return res;
        }
    }
}
