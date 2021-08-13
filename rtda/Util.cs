using minij.rtda.heap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/**
byte short char int long float double object
**/
namespace minij.rtda
{
    public class Util
    {
        public static minij.classfile.attributes.Attribute getAttr(List<minij.classfile.attributes.Attribute> attrs, string v)
        {
            if (null == attrs) return null;
            minij.classfile.attributes.Attribute res = null;
            attrs.ForEach(item =>
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
